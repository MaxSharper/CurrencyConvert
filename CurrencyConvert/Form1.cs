using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CurrencyConvert
{
    public partial class Form1 : Form
    {
        #region Constructor with some additional commands
        public Form1()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += (s, e) => // If checkbox checked change
            {
                // Checking
                if (checkBox1.Checked) // if it's checked set registry value true
                    registry.OpenSubKey("ExchangeRate", true).SetValue("DoNotDownloadAgain", "true");
                else // Otherwise - false
                    registry.OpenSubKey("ExchangeRate", true).SetValue("DoNotDownloadAgain", "false");
            };
            secondCount.KeyPress += (s, e) => { CopyPaste(secondCount, e.KeyChar); }; // Need for ability to copy and paste
        }
        #endregion
        #region Variables
        public string rates; // Main variable containing rates
        static readonly Form1 f = new Form1(); // Object of Form
        ExchangeRate exchangeRate = new ExchangeRate(f); // Object of class ExchangeRate
        public RegistryKey registry = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\", true); // Open the registry key
        #endregion
        #region Main Methods (Form Load, Helpers, Checkers, data senders etc)
        private void Form1_Load(object sender, EventArgs e)
        {
            firstValue.SelectedIndex = 2; // Set first index to 2 (USD), by default
            secondValue.SelectedIndex = 0; // Set first index to 0 (UAH), by default      
            // Call the necessary methods
            exchangeRate.RegistryCheck();
            if (registry.OpenSubKey(@"ExchangeRate").GetValue("DoNotDownloadAgain").ToString() == "true") 
                checkBox1.Checked = true;
            exchangeRate.RateConvertaion();
            PopUpHelper();
            // Set the status strip text to the general rates
            currency.Text = $"RUB: {ConvertationVariables.RUBToUA}    USD: {ConvertationVariables.USDToUA}    EUR: {ConvertationVariables.EURToUA}";
            secondCount.Text = ConvertationVariables.USDToUA.ToString(); // Set field to the USD to UAH rate
        }
        private void SecondValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            exchangeRate.RateCalculation(firstCount, secondCount, firstValue.SelectedIndex, secondValue.SelectedIndex); // If the combobox index changed we calculate date
        }
        private void FirstCount_TextChanged(object sender, EventArgs e)
        {
            // If user enter new text we at once calculate it
            exchangeRate.IsTextBoxContainsDot(firstCount);
            exchangeRate.RateCalculation(firstCount, secondCount, firstValue.SelectedIndex, secondValue.SelectedIndex);
        }
        private void FirstCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Method which block all keys except numbers, backspace, dot and comma
            char key = e.KeyChar;
            CopyPaste(firstCount, key);
            if (!Char.IsDigit(key) && key != 8 && key != 44 && key != 46)
                e.Handled = true; // If key is not suitable we ignore it        
        }
        private void PopUpHelper()
        {
            string pattern = "\"([0-9]{2}\\.[0-9]{2}\\.[0-9]{4})\""; // Pattern defining date format: 00.00.0000;
            string date = "Курс установленный НБУ на " + System.Text.RegularExpressions.Regex.Match(System.IO.File.ReadAllText("ExchangeRate.txt"),
                $"\"exchangedate\":{pattern}").Groups[1].Value; // The text on hint
            ToolTip hint = new ToolTip { ToolTipIcon = ToolTipIcon.Info, /* Set icon like info */ ToolTipTitle = "Курс валют" /* Set Title */ };
            // Set hint to the fields and comboboxes
            hint.SetToolTip(firstCount, date);
            hint.SetToolTip(secondCount, date);
            hint.SetToolTip(firstValue, date);
            hint.SetToolTip(secondValue, date);
        }
        private void CopyPaste(TextBox textBox, char key)
        {
            if (Clipboard.GetText().Length > 307) // If clipbord text length is more than 307
            {
                key = 'a'; // Change the button to random, we need it to block other if's
            }
            if (key == '') // If key is Ctrl + C   
            {
                Clipboard.SetText(textBox.Text); // Set clipboard text to the field's text          
            }
            if (key == '') // If key is Ctrl + V
            {
                textBox.Text += Clipboard.GetText(); // Set field's text to the clipboard text
                textBox.SelectionStart = textBox.TextLength; // Set cursor to the end
            }
        }
        private void Exit_Click(object sender, EventArgs e) => Close();
        private void TopMost_Click(object sender, EventArgs e)
        {
            topMost.Checked = !topMost.Checked; // Invert the checked (if check mark checked it will unchecked and vice versa)
            TopMost = !TopMost; // Invert the Top most
        }
        private void FileSave_Click(object sender, EventArgs e)
        {
            // Saving general rates to the file
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("Курс валют.txt"))
            {
                streamWriter.WriteLine($"1 RUB - {ConvertationVariables.RUBToUA} UAH\n1 USD - {ConvertationVariables.USDToUA} UAH\n" +
                $"1 EUR - {ConvertationVariables.EURToUA} UAH\n1 GBP - {ConvertationVariables.GBPToUA} UAH\n1 XAU - {ConvertationVariables.XAUToUA} UAH\n" +
                $"1 BYN - {ConvertationVariables.BYNToUA} UAH\n");
            }
            new System.Threading.Thread(() => { MessageBox.Show("Курс успешно сохранён в файле \"Курс валют\"", "Сохранение в файл", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification); }).Start();
            System.Threading.Thread.Sleep(300);
            System.Diagnostics.Process.Start("explorer.exe", "/select," + "Курс валют.txt"); // Open the explorer and select our file
        }
        private void CheckBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) checkBox1.Checked = !checkBox1.Checked;
        }
        #endregion
    }
}
