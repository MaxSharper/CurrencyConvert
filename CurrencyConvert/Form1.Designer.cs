namespace CurrencyConvert
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.secondCount = new System.Windows.Forms.TextBox();
            this.firstCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.secondValue = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstValue = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currency = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.topMost = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // secondCount
            // 
            this.secondCount.BackColor = System.Drawing.Color.White;
            this.secondCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.secondCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondCount.ForeColor = System.Drawing.Color.SteelBlue;
            this.secondCount.Location = new System.Drawing.Point(398, 196);
            this.secondCount.Multiline = true;
            this.secondCount.Name = "secondCount";
            this.secondCount.ReadOnly = true;
            this.secondCount.Size = new System.Drawing.Size(322, 26);
            this.secondCount.TabIndex = 17;
            this.secondCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirstCount_KeyPress);
            // 
            // firstCount
            // 
            this.firstCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.firstCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstCount.ForeColor = System.Drawing.Color.DarkCyan;
            this.firstCount.Location = new System.Drawing.Point(16, 196);
            this.firstCount.MaxLength = 307;
            this.firstCount.Multiline = true;
            this.firstCount.Name = "firstCount";
            this.firstCount.Size = new System.Drawing.Size(322, 26);
            this.firstCount.TabIndex = 16;
            this.firstCount.Text = "1";
            this.firstCount.TextChanged += new System.EventHandler(this.FirstCount_TextChanged);
            this.firstCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirstCount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(496, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Получаю";
            // 
            // secondValue
            // 
            this.secondValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondValue.FormattingEnabled = true;
            this.secondValue.Items.AddRange(new object[] {
            "UAH - гривна",
            "RUB - рубль",
            "USD - доллар",
            "EUR - евро",
            "GBP - фунт стерлингов",
            "XAU - 1 тр.унция золота",
            "BYN - белорусский рубль"});
            this.secondValue.Location = new System.Drawing.Point(398, 125);
            this.secondValue.Name = "secondValue";
            this.secondValue.Size = new System.Drawing.Size(322, 24);
            this.secondValue.TabIndex = 14;
            this.secondValue.SelectedIndexChanged += new System.EventHandler(this.SecondValue_SelectedIndexChanged);
            this.secondValue.TextChanged += new System.EventHandler(this.SecondValue_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(128, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Отдаю";
            // 
            // firstValue
            // 
            this.firstValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstValue.FormattingEnabled = true;
            this.firstValue.Items.AddRange(new object[] {
            "UAH - гривна",
            "RUB - рубль",
            "USD - доллар",
            "EUR - евро",
            "GBP - фунт стерлингов",
            "XAU - 1 тр.унция золота",
            "BYN - белорусский рубль"});
            this.firstValue.Location = new System.Drawing.Point(16, 125);
            this.firstValue.Name = "firstValue";
            this.firstValue.Size = new System.Drawing.Size(322, 24);
            this.firstValue.TabIndex = 12;
            this.firstValue.SelectedIndexChanged += new System.EventHandler(this.SecondValue_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(257, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Конвертер валют";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(146)))), ((int)(((byte)(117)))));
            this.checkBox1.Location = new System.Drawing.Point(12, 245);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(719, 21);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "При следующем запуске не считывать новый курс (рекомендуется если часто запускает" +
    "е приложение)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckBox1_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.currency});
            this.statusStrip1.Location = new System.Drawing.Point(0, 271);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(762, 23);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(170, 17);
            this.toolStripStatusLabel1.Text = "Основные курсы валют: ";
            // 
            // currency
            // 
            this.currency.ForeColor = System.Drawing.Color.SteelBlue;
            this.currency.Name = "currency";
            this.currency.Size = new System.Drawing.Size(0, 17);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMost,
            this.fileSave,
            this.exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 70);
            // 
            // topMost
            // 
            this.topMost.Name = "topMost";
            this.topMost.Size = new System.Drawing.Size(205, 22);
            this.topMost.Text = "Поверх всех окон";
            this.topMost.Click += new System.EventHandler(this.TopMost_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(205, 22);
            this.exit.Text = "Выйти";
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // fileSave
            // 
            this.fileSave.Name = "fileSave";
            this.fileSave.Size = new System.Drawing.Size(205, 22);
            this.fileSave.Text = "Сохранить в файл";
            this.fileSave.Click += new System.EventHandler(this.FileSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 294);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.secondCount);
            this.Controls.Add(this.firstCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secondValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstValue);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер валют";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TextBox secondCount;
        internal System.Windows.Forms.TextBox firstCount;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox secondValue;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox firstValue;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel currency;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem topMost;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem fileSave;
    }
}

