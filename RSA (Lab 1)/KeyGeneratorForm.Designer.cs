namespace RSA__Lab_1_
{
    partial class KeyGeneratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyGeneratorForm));
            this.buttonExportPublicKey = new System.Windows.Forms.Button();
            this.buttonExportPrivateKey = new System.Windows.Forms.Button();
            this.textBoxKeyLength = new System.Windows.Forms.TextBox();
            this.labelKeyLength = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.textBoxE = new System.Windows.Forms.TextBox();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.labelN = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.labelQ = new System.Windows.Forms.Label();
            this.labelE = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.saveFileDialogKey = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.radioButtonWiener = new System.Windows.Forms.RadioButton();
            this.radioButtonCommonN = new System.Windows.Forms.RadioButton();
            this.radioButtonCommonE = new System.Windows.Forms.RadioButton();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.groupBoxParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExportPublicKey
            // 
            this.buttonExportPublicKey.Location = new System.Drawing.Point(302, 130);
            this.buttonExportPublicKey.Name = "buttonExportPublicKey";
            this.buttonExportPublicKey.Size = new System.Drawing.Size(183, 23);
            this.buttonExportPublicKey.TabIndex = 0;
            this.buttonExportPublicKey.Text = "Экспорт";
            this.buttonExportPublicKey.UseVisualStyleBackColor = true;
            this.buttonExportPublicKey.Click += new System.EventHandler(this.buttonExportPublicKey_Click);
            // 
            // buttonExportPrivateKey
            // 
            this.buttonExportPrivateKey.Location = new System.Drawing.Point(302, 159);
            this.buttonExportPrivateKey.Name = "buttonExportPrivateKey";
            this.buttonExportPrivateKey.Size = new System.Drawing.Size(183, 23);
            this.buttonExportPrivateKey.TabIndex = 1;
            this.buttonExportPrivateKey.Text = "Экспорт";
            this.buttonExportPrivateKey.UseVisualStyleBackColor = true;
            this.buttonExportPrivateKey.Click += new System.EventHandler(this.buttonExportPrivateKey_Click);
            // 
            // textBoxKeyLength
            // 
            this.textBoxKeyLength.Location = new System.Drawing.Point(136, 15);
            this.textBoxKeyLength.Name = "textBoxKeyLength";
            this.textBoxKeyLength.Size = new System.Drawing.Size(156, 23);
            this.textBoxKeyLength.TabIndex = 2;
            this.textBoxKeyLength.Text = "1024";
            this.textBoxKeyLength.TextChanged += new System.EventHandler(this.textBoxKeyLength_TextChanged);
            // 
            // labelKeyLength
            // 
            this.labelKeyLength.AutoSize = true;
            this.labelKeyLength.Location = new System.Drawing.Point(16, 18);
            this.labelKeyLength.Name = "labelKeyLength";
            this.labelKeyLength.Size = new System.Drawing.Size(111, 15);
            this.labelKeyLength.TabIndex = 3;
            this.labelKeyLength.Text = "Длина ключа (бит)";
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(137, 44);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.ReadOnly = true;
            this.textBoxN.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxN.Size = new System.Drawing.Size(155, 23);
            this.textBoxN.TabIndex = 4;
            // 
            // textBoxQ
            // 
            this.textBoxQ.Location = new System.Drawing.Point(137, 102);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.ReadOnly = true;
            this.textBoxQ.Size = new System.Drawing.Size(155, 23);
            this.textBoxQ.TabIndex = 6;
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(137, 73);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.ReadOnly = true;
            this.textBoxP.Size = new System.Drawing.Size(155, 23);
            this.textBoxP.TabIndex = 7;
            // 
            // textBoxE
            // 
            this.textBoxE.Location = new System.Drawing.Point(136, 130);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.ReadOnly = true;
            this.textBoxE.Size = new System.Drawing.Size(156, 23);
            this.textBoxE.TabIndex = 8;
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(136, 161);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.ReadOnly = true;
            this.textBoxD.Size = new System.Drawing.Size(156, 23);
            this.textBoxD.TabIndex = 9;
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(16, 47);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(70, 15);
            this.labelN.TabIndex = 10;
            this.labelN.Text = "Модуль (N)";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Location = new System.Drawing.Point(16, 76);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(14, 15);
            this.labelP.TabIndex = 11;
            this.labelP.Text = "P";
            // 
            // labelQ
            // 
            this.labelQ.AutoSize = true;
            this.labelQ.Location = new System.Drawing.Point(16, 105);
            this.labelQ.Name = "labelQ";
            this.labelQ.Size = new System.Drawing.Size(16, 15);
            this.labelQ.TabIndex = 12;
            this.labelQ.Text = "Q";
            // 
            // labelE
            // 
            this.labelE.AutoSize = true;
            this.labelE.Location = new System.Drawing.Point(16, 134);
            this.labelE.Name = "labelE";
            this.labelE.Size = new System.Drawing.Size(114, 15);
            this.labelE.TabIndex = 13;
            this.labelE.Text = "Открытый ключ (E)";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Location = new System.Drawing.Point(16, 163);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(115, 15);
            this.labelD.TabIndex = 14;
            this.labelD.Text = "Закрытый ключ (D)";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(302, 15);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(183, 23);
            this.buttonGenerate.TabIndex = 16;
            this.buttonGenerate.Text = "Сгенерировать";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // groupBoxParams
            // 
            this.groupBoxParams.Controls.Add(this.radioButtonWiener);
            this.groupBoxParams.Controls.Add(this.radioButtonCommonN);
            this.groupBoxParams.Controls.Add(this.radioButtonCommonE);
            this.groupBoxParams.Controls.Add(this.radioButtonDefault);
            this.groupBoxParams.Location = new System.Drawing.Point(302, 44);
            this.groupBoxParams.Name = "groupBoxParams";
            this.groupBoxParams.Size = new System.Drawing.Size(183, 76);
            this.groupBoxParams.TabIndex = 18;
            this.groupBoxParams.TabStop = false;
            this.groupBoxParams.Text = "Параметры";
            // 
            // radioButtonWiener
            // 
            this.radioButtonWiener.AutoSize = true;
            this.radioButtonWiener.Location = new System.Drawing.Point(92, 46);
            this.radioButtonWiener.Name = "radioButtonWiener";
            this.radioButtonWiener.Size = new System.Drawing.Size(59, 19);
            this.radioButtonWiener.TabIndex = 3;
            this.radioButtonWiener.TabStop = true;
            this.radioButtonWiener.Text = "Винер";
            this.radioButtonWiener.UseVisualStyleBackColor = true;
            // 
            // radioButtonCommonN
            // 
            this.radioButtonCommonN.AutoSize = true;
            this.radioButtonCommonN.Location = new System.Drawing.Point(92, 21);
            this.radioButtonCommonN.Name = "radioButtonCommonN";
            this.radioButtonCommonN.Size = new System.Drawing.Size(78, 19);
            this.radioButtonCommonN.TabIndex = 2;
            this.radioButtonCommonN.Text = "Общий N";
            this.radioButtonCommonN.UseVisualStyleBackColor = true;
            // 
            // radioButtonCommonE
            // 
            this.radioButtonCommonE.AutoSize = true;
            this.radioButtonCommonE.Location = new System.Drawing.Point(6, 46);
            this.radioButtonCommonE.Name = "radioButtonCommonE";
            this.radioButtonCommonE.Size = new System.Drawing.Size(75, 19);
            this.radioButtonCommonE.TabIndex = 1;
            this.radioButtonCommonE.Text = "Общий Е";
            this.radioButtonCommonE.UseVisualStyleBackColor = true;
            // 
            // radioButtonDefault
            // 
            this.radioButtonDefault.AutoSize = true;
            this.radioButtonDefault.Checked = true;
            this.radioButtonDefault.Location = new System.Drawing.Point(6, 21);
            this.radioButtonDefault.Name = "radioButtonDefault";
            this.radioButtonDefault.Size = new System.Drawing.Size(80, 19);
            this.radioButtonDefault.TabIndex = 0;
            this.radioButtonDefault.TabStop = true;
            this.radioButtonDefault.Text = "Обычный";
            this.radioButtonDefault.UseVisualStyleBackColor = true;
            // 
            // KeyGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 206);
            this.Controls.Add(this.groupBoxParams);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.labelE);
            this.Controls.Add(this.labelQ);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.textBoxD);
            this.Controls.Add(this.textBoxE);
            this.Controls.Add(this.textBoxP);
            this.Controls.Add(this.textBoxQ);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.labelKeyLength);
            this.Controls.Add(this.textBoxKeyLength);
            this.Controls.Add(this.buttonExportPrivateKey);
            this.Controls.Add(this.buttonExportPublicKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeyGeneratorForm";
            this.Text = "Генерация ключа";
            this.groupBoxParams.ResumeLayout(false);
            this.groupBoxParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonExportPublicKey;
        private Button buttonExportPrivateKey;
        private TextBox textBoxKeyLength;
        private Label labelKeyLength;
        private TextBox textBoxN;
        private TextBox textBoxQ;
        private TextBox textBoxP;
        private TextBox textBoxE;
        private TextBox textBoxD;
        private Label labelN;
        private Label labelP;
        private Label labelQ;
        private Label labelE;
        private Label labelD;
        private Button buttonGenerate;
        private SaveFileDialog saveFileDialogKey;
        private GroupBox groupBoxParams;
        private RadioButton radioButtonCommonN;
        private RadioButton radioButtonCommonE;
        private RadioButton radioButtonDefault;
        private RadioButton radioButtonWiener;
    }
}