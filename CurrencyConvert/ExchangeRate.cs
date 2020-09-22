using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CurrencyConvert
{
    class ExchangeRate
    {
        #region Constructor
        public ExchangeRate(Form1 form) => form1 = form;
        #endregion
        #region Variables
        private string dateWebsite;
        private readonly Form1 form1;
        #endregion   
        #region Main Methods (Calculation, RegistryChecker, DateChecker etc)
        public void RegistryCheck()
        {
            try
            {
                if (form1.registry.OpenSubKey(@"ExchangeRate").GetValue("DoNotDownloadAgain").ToString().ToLower() == "false")
                {
                    CurrencyParse(); // If user don't set check mark to the checkbox we parse new rates
                }
                else
                {
                    form1.rates = File.ReadAllText("ExchangeRate.txt", Encoding.GetEncoding(65001)); // Otherwise the read it from file
                }
            }
            catch (NullReferenceException)
            {
                // If user run our application first we parse rates, write this data to the file and create registry key
                CurrencyParse();
                form1.rates = File.ReadAllText("ExchangeRate.txt");
                form1.registry.CreateSubKey("ExchangeRate", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("DoNotDownloadAgain", false);
            }
        }
        public void RateConvertaion()
        {
            //Initialization convertation varibles
            ConvertationVariables.USDToUA = Convert.ToDouble(Regex.Match(form1.rates, "\"Долар США\",\"rate\":(.*?),\"cc\":\"USD\",\"exchangedate\"", RegexOptions.Compiled).Groups[1].Value.ToString().Replace(".", ","));
            ConvertationVariables.RUBToUA = Convert.ToDouble(Regex.Match(form1.rates, "\"Російський рубль\",\"rate\":(.*?),\"cc\":\"RUB\",\"exchangedate\"", RegexOptions.Compiled).Groups[1].Value.ToString().Replace(".", ","));
            ConvertationVariables.EURToUA = Convert.ToDouble(Regex.Match(form1.rates, "\"Євро\",\"rate\":(.*?),\"cc\":\"EUR\",\"exchangedate\"", RegexOptions.Compiled).Groups[1].Value.ToString().Replace(".", ","));
            ConvertationVariables.XAUToUA = Convert.ToDouble(Regex.Match(form1.rates, "\"Золото\",\"rate\":(.*?),\"cc\":\"XAU\",\"exchangedate\"", RegexOptions.Compiled).Groups[1].Value.ToString().Replace(".", ","));
            ConvertationVariables.GBPToUA = Convert.ToDouble(Regex.Match(form1.rates, "\"Фунт стерлінгів\",\"rate\":(.*?),\"cc\":\"GBP\",\"exchangedate\"", RegexOptions.Compiled).Groups[1].Value.ToString().Replace(".", ","));
            ConvertationVariables.BYNToUA = Convert.ToDouble(Regex.Match(form1.rates, "\"Б.лоруський рубль\",\"rate\":(.*?),\"cc\":\"BYN\",\"exchangedate\"", RegexOptions.Compiled).Groups[1].Value.ToString().Replace(".", ","));
        }
        public void CurrencyParse()
        {
            //Parse the currency rate and date
            WebClient wc = new WebClient();
            wc.DownloadFile($"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date={DateTime.Now:yyyyMMdd}&json", "ExchangeRate.txt");
            dateWebsite = wc.DownloadString("https://bilet.pp.ru/calculator_rus/tochnoe_moskovskoe_vremia.php");
            DateCheck(); //Check date
            form1.rates = File.ReadAllText("ExchangeRate.txt", Encoding.GetEncoding(65001)); //Write currency rate in file
        }  
        private void DateCheck()
        {
            //Check if real date is equal to client date, if no, we show popup messagebox
            string clientDate = DateTime.Now.ToString("d-MM-yyyy");
            string realDate = Regex.Match(dateWebsite, "<b>(.*?)</b></h1>").Groups[1].Value;
            if (clientDate != realDate)
                MessageBox.Show($"Кажется, что ваша дата устарела или вы спешите в будущее. Сейчас {realDate}, а у вас {clientDate}. Но курс будет показан на вашу дату", "Неверная дата", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }
        public void IsTextBoxContainsDot(TextBox textBox)
        {
            //Replace . on , for correct working
            if (textBox.Text.Contains("."))
            {
                textBox.Text = textBox.Text.Remove(textBox.TextLength - 1);
                textBox.Text += ",";
                textBox.SelectionStart = textBox.TextLength;
            }
        }
        public void RateCalculation(TextBox firstCount, TextBox secondCount, int firstSelectedIndex, int secondSelectedIndex)
        {
            // This method is sending all necessary data to calculation method
            var selectedIndexToValue = new Dictionary<string, double>()
            {
                ["6.0"] = ConvertationVariables.BYNToUA,
                ["0.6"] = ConvertationVariables.BYNToUA,
                ["5.0"] = ConvertationVariables.XAUToUA,
                ["0.5"] = ConvertationVariables.XAUToUA,
                ["4.0"] = ConvertationVariables.GBPToUA,
                ["0.4"] = ConvertationVariables.GBPToUA,
                ["3.0"] = ConvertationVariables.EURToUA,
                ["0.3"] = ConvertationVariables.EURToUA,
                ["2.0"] = ConvertationVariables.USDToUA,
                ["0.2"] = ConvertationVariables.USDToUA,
                ["1.0"] = ConvertationVariables.RUBToUA,
                ["0.1"] = ConvertationVariables.RUBToUA,
                ["1.2"] = ConvertationVariables.USDToUA / ConvertationVariables.RUBToUA,
                ["1.3"] = ConvertationVariables.EURToUA / ConvertationVariables.RUBToUA,
                ["1.4"] = ConvertationVariables.GBPToUA / ConvertationVariables.RUBToUA,
                ["1.5"] = ConvertationVariables.XAUToUA / ConvertationVariables.RUBToUA,
                ["1.6"] = ConvertationVariables.BYNToUA / ConvertationVariables.RUBToUA,
                ["2.1"] = ConvertationVariables.RUBToUA / ConvertationVariables.USDToUA,
                ["2.3"] = ConvertationVariables.EURToUA / ConvertationVariables.USDToUA,
                ["2.4"] = ConvertationVariables.GBPToUA / ConvertationVariables.USDToUA,
                ["2.5"] = ConvertationVariables.XAUToUA / ConvertationVariables.USDToUA,
                ["2.6"] = ConvertationVariables.BYNToUA / ConvertationVariables.USDToUA,
                ["3.1"] = ConvertationVariables.RUBToUA / ConvertationVariables.EURToUA,
                ["3.2"] = ConvertationVariables.USDToUA / ConvertationVariables.EURToUA,
                ["3.4"] = ConvertationVariables.GBPToUA / ConvertationVariables.EURToUA,
                ["3.5"] = ConvertationVariables.XAUToUA / ConvertationVariables.EURToUA,
                ["3.6"] = ConvertationVariables.BYNToUA / ConvertationVariables.EURToUA,
                ["4.1"] = ConvertationVariables.RUBToUA / ConvertationVariables.GBPToUA,
                ["4.2"] = ConvertationVariables.USDToUA / ConvertationVariables.GBPToUA,
                ["4.3"] = ConvertationVariables.EURToUA / ConvertationVariables.GBPToUA,
                ["4.5"] = ConvertationVariables.XAUToUA / ConvertationVariables.GBPToUA,
                ["4.6"] = ConvertationVariables.BYNToUA / ConvertationVariables.GBPToUA,
                ["5.1"] = ConvertationVariables.RUBToUA / ConvertationVariables.XAUToUA,
                ["5.2"] = ConvertationVariables.USDToUA / ConvertationVariables.XAUToUA,
                ["5.3"] = ConvertationVariables.EURToUA / ConvertationVariables.XAUToUA,
                ["5.4"] = ConvertationVariables.GBPToUA / ConvertationVariables.XAUToUA,
                ["5.6"] = ConvertationVariables.BYNToUA / ConvertationVariables.XAUToUA,
                ["6.1"] = ConvertationVariables.RUBToUA / ConvertationVariables.BYNToUA,
                ["6.2"] = ConvertationVariables.USDToUA / ConvertationVariables.BYNToUA,
                ["6.3"] = ConvertationVariables.EURToUA / ConvertationVariables.BYNToUA,
                ["6.4"] = ConvertationVariables.GBPToUA / ConvertationVariables.BYNToUA,
                ["6.5"] = ConvertationVariables.XAUToUA / ConvertationVariables.BYNToUA,
            }; // Dictionary with all possible indexes, it defines what we gonna do
            char operation = '*'; //Operation is multiplication, default
            double currentValue = 1; //Specifies the currency or special value to be divided or multiplied by to get the result
            if (selectedIndexToValue.ContainsKey($"{firstSelectedIndex}.{secondSelectedIndex}")) //Check if dictionary contains this index (only need it when form load)
                currentValue = selectedIndexToValue[$"{firstSelectedIndex}.{secondSelectedIndex}"]; //Initialazing the value
            if (secondSelectedIndex > 0) operation = '/'; // If second combobox index > 0 operation will be /
            secondCount.Text = Calculation(firstCount, operation, currentValue).ToString(); // Set the result to our field

        }
        private double Calculation(TextBox firstCount, char operation, double currentValue)
        {
            if (firstCount.Text.Replace(" ", "") != "") // If field isn't empty
            {
                try
                {
                    switch (operation)
                    {
                        case '*':
                            double multiplicationResult = currentValue * Convert.ToDouble(firstCount.Text); // Multiply currency or special value to entry field
                            return multiplicationResult;
                        case '/':
                            double divisionResult = Math.Round(Convert.ToDouble(firstCount.Text) / currentValue, 4); // Divide currency or special value to entry field
                            return divisionResult;
                        default: return 1;
                    }
                }
                catch (FormatException)
                {
                    if (firstCount.Text.Contains(",")) // If user try to write or paste text with two commans
                    {
                        MessageBox.Show("Вы пытаетесь вставить или написать текст, который содержит запятую, в поле ввода, которое также её содержит",
                       "Две запятые", MessageBoxButtons.OK, MessageBoxIcon.Error); // Send popup error messagebox
                        int place = firstCount.Text.LastIndexOf(",");
                        firstCount.Text = firstCount.Text.Remove(place, ",".Length).Insert(place, ""); // Delete the last comma
                        firstCount.SelectionStart = firstCount.TextLength; // Set cursor to the end
                    }
                    else // If user try to paste text with symbols
                    {
                        MessageBox.Show("Настоятельно рекомендуем писать цифры в поле ввода", "Неверные символы", MessageBoxButtons.OK, MessageBoxIcon.Error); // Send popup error
                        int lastIndex = firstCount.Text.LastIndexOf(Clipboard.GetText());
                        firstCount.Text = firstCount.Text.Substring(0, lastIndex); // Delete the paste text
                    }
                    return Calculation(firstCount, operation, currentValue);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Поле ввода имеет длину больше, чем 307 символов", "Cлишком большой текст", MessageBoxButtons.OK, MessageBoxIcon.Error); // Send popup error
                    firstCount.Text = "1";
                    return 1;
                }
            }
            else return 1;
        }
        #endregion
    }
}
