namespace RSA__Lab_1_
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlGOSTVerify = new System.Windows.Forms.TabControl();
            this.tabPageCipher = new System.Windows.Forms.TabPage();
            this.groupBoxDecrypt = new System.Windows.Forms.GroupBox();
            this.labelRSAPrivateKey = new System.Windows.Forms.Label();
            this.buttonRSAPrivateKey = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.buttonMessageDecrypt = new System.Windows.Forms.Button();
            this.labelMessageDecrypt = new System.Windows.Forms.Label();
            this.groupBoxEncrypt = new System.Windows.Forms.GroupBox();
            this.checkBoxRandomAES = new System.Windows.Forms.CheckBox();
            this.labelAESKey = new System.Windows.Forms.Label();
            this.labelRSAOpenKey = new System.Windows.Forms.Label();
            this.labelMessageEncrypt = new System.Windows.Forms.Label();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonAESKey = new System.Windows.Forms.Button();
            this.buttonRSAKey = new System.Windows.Forms.Button();
            this.buttonMessageRSA = new System.Windows.Forms.Button();
            this.tabPageSignature = new System.Windows.Forms.TabPage();
            this.groupBoxVerify = new System.Windows.Forms.GroupBox();
            this.labelSignmentVerify = new System.Windows.Forms.Label();
            this.labelMessageVerify = new System.Windows.Forms.Label();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.buttonSignmentVerify = new System.Windows.Forms.Button();
            this.buttonMessageVerify = new System.Windows.Forms.Button();
            this.groupBoxSign = new System.Windows.Forms.GroupBox();
            this.buttonRSAPublicKeySign = new System.Windows.Forms.Button();
            this.labelPublicKeySign = new System.Windows.Forms.Label();
            this.labelRSAPrivateKeySign = new System.Windows.Forms.Label();
            this.labelMessageSign = new System.Windows.Forms.Label();
            this.buttonSign = new System.Windows.Forms.Button();
            this.buttonRSAPrivateKeySign = new System.Windows.Forms.Button();
            this.buttonMessageSign = new System.Windows.Forms.Button();
            this.tabPageGOST = new System.Windows.Forms.TabPage();
            this.buttonGOSTSignMsg = new System.Windows.Forms.Button();
            this.labelGOSTSignFilename = new System.Windows.Forms.Label();
            this.buttonGOSTSign = new System.Windows.Forms.Button();
            this.textBoxGOSTD = new System.Windows.Forms.TextBox();
            this.labelGOSTD = new System.Windows.Forms.Label();
            this.groupBoxCurveParams = new System.Windows.Forms.GroupBox();
            this.textBoxGOSTP = new System.Windows.Forms.TextBox();
            this.textBoxGOSTB = new System.Windows.Forms.TextBox();
            this.textBoxGOSTA = new System.Windows.Forms.TextBox();
            this.groupBoxBasePoint = new System.Windows.Forms.GroupBox();
            this.textBoxGOSTQ = new System.Windows.Forms.TextBox();
            this.textBoxGOSTyP = new System.Windows.Forms.TextBox();
            this.textBoxGOSTxP = new System.Windows.Forms.TextBox();
            this.labelBasePointQ = new System.Windows.Forms.Label();
            this.labelBasePointY = new System.Windows.Forms.Label();
            this.labeBasePointX = new System.Windows.Forms.Label();
            this.labelCurveModule = new System.Windows.Forms.Label();
            this.labelCurveB = new System.Windows.Forms.Label();
            this.labelCurveA = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonGOSTVerify = new System.Windows.Forms.Button();
            this.buttonGOSTSignFile = new System.Windows.Forms.Button();
            this.buttonGOSTMsg = new System.Windows.Forms.Button();
            this.labelGOSTSign = new System.Windows.Forms.Label();
            this.labelGOSTMessage = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьКлючToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.атакаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ключиСОбщимМодулемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.атакаВинераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.малыйОбщийПоказательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlGOSTVerify.SuspendLayout();
            this.tabPageCipher.SuspendLayout();
            this.groupBoxDecrypt.SuspendLayout();
            this.groupBoxEncrypt.SuspendLayout();
            this.tabPageSignature.SuspendLayout();
            this.groupBoxVerify.SuspendLayout();
            this.groupBoxSign.SuspendLayout();
            this.tabPageGOST.SuspendLayout();
            this.groupBoxCurveParams.SuspendLayout();
            this.groupBoxBasePoint.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlGOSTVerify
            // 
            this.tabControlGOSTVerify.Controls.Add(this.tabPageCipher);
            this.tabControlGOSTVerify.Controls.Add(this.tabPageSignature);
            this.tabControlGOSTVerify.Controls.Add(this.tabPageGOST);
            this.tabControlGOSTVerify.Controls.Add(this.tabPage1);
            this.tabControlGOSTVerify.Location = new System.Drawing.Point(12, 27);
            this.tabControlGOSTVerify.Name = "tabControlGOSTVerify";
            this.tabControlGOSTVerify.SelectedIndex = 0;
            this.tabControlGOSTVerify.Size = new System.Drawing.Size(312, 404);
            this.tabControlGOSTVerify.TabIndex = 0;
            // 
            // tabPageCipher
            // 
            this.tabPageCipher.Controls.Add(this.groupBoxDecrypt);
            this.tabPageCipher.Controls.Add(this.groupBoxEncrypt);
            this.tabPageCipher.Location = new System.Drawing.Point(4, 24);
            this.tabPageCipher.Name = "tabPageCipher";
            this.tabPageCipher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCipher.Size = new System.Drawing.Size(304, 376);
            this.tabPageCipher.TabIndex = 0;
            this.tabPageCipher.Text = "Шифрование";
            this.tabPageCipher.UseVisualStyleBackColor = true;
            // 
            // groupBoxDecrypt
            // 
            this.groupBoxDecrypt.Controls.Add(this.labelRSAPrivateKey);
            this.groupBoxDecrypt.Controls.Add(this.buttonRSAPrivateKey);
            this.groupBoxDecrypt.Controls.Add(this.buttonDecrypt);
            this.groupBoxDecrypt.Controls.Add(this.buttonMessageDecrypt);
            this.groupBoxDecrypt.Controls.Add(this.labelMessageDecrypt);
            this.groupBoxDecrypt.Location = new System.Drawing.Point(18, 208);
            this.groupBoxDecrypt.Name = "groupBoxDecrypt";
            this.groupBoxDecrypt.Size = new System.Drawing.Size(269, 160);
            this.groupBoxDecrypt.TabIndex = 1;
            this.groupBoxDecrypt.TabStop = false;
            this.groupBoxDecrypt.Text = "Расшифрование";
            // 
            // labelRSAPrivateKey
            // 
            this.labelRSAPrivateKey.AutoSize = true;
            this.labelRSAPrivateKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelRSAPrivateKey.Location = new System.Drawing.Point(21, 75);
            this.labelRSAPrivateKey.Name = "labelRSAPrivateKey";
            this.labelRSAPrivateKey.Size = new System.Drawing.Size(120, 15);
            this.labelRSAPrivateKey.TabIndex = 4;
            this.labelRSAPrivateKey.Text = "Закрытый ключ RSA";
            // 
            // buttonRSAPrivateKey
            // 
            this.buttonRSAPrivateKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonRSAPrivateKey.Location = new System.Drawing.Point(176, 71);
            this.buttonRSAPrivateKey.Name = "buttonRSAPrivateKey";
            this.buttonRSAPrivateKey.Size = new System.Drawing.Size(75, 23);
            this.buttonRSAPrivateKey.TabIndex = 3;
            this.buttonRSAPrivateKey.Text = "Выбрать";
            this.buttonRSAPrivateKey.UseVisualStyleBackColor = true;
            this.buttonRSAPrivateKey.Click += new System.EventHandler(this.buttonRSAPrivateKey_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDecrypt.Location = new System.Drawing.Point(21, 111);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(230, 32);
            this.buttonDecrypt.TabIndex = 2;
            this.buttonDecrypt.Text = "Расшифровать";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // buttonMessageDecrypt
            // 
            this.buttonMessageDecrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonMessageDecrypt.Location = new System.Drawing.Point(176, 32);
            this.buttonMessageDecrypt.Name = "buttonMessageDecrypt";
            this.buttonMessageDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonMessageDecrypt.TabIndex = 1;
            this.buttonMessageDecrypt.Text = "Выбрать";
            this.buttonMessageDecrypt.UseVisualStyleBackColor = true;
            this.buttonMessageDecrypt.Click += new System.EventHandler(this.buttonMessageDecrypt_Click);
            // 
            // labelMessageDecrypt
            // 
            this.labelMessageDecrypt.AutoSize = true;
            this.labelMessageDecrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMessageDecrypt.Location = new System.Drawing.Point(21, 36);
            this.labelMessageDecrypt.Name = "labelMessageDecrypt";
            this.labelMessageDecrypt.Size = new System.Drawing.Size(105, 15);
            this.labelMessageDecrypt.TabIndex = 0;
            this.labelMessageDecrypt.Text = "Сообщение ASN.1";
            // 
            // groupBoxEncrypt
            // 
            this.groupBoxEncrypt.Controls.Add(this.checkBoxRandomAES);
            this.groupBoxEncrypt.Controls.Add(this.labelAESKey);
            this.groupBoxEncrypt.Controls.Add(this.labelRSAOpenKey);
            this.groupBoxEncrypt.Controls.Add(this.labelMessageEncrypt);
            this.groupBoxEncrypt.Controls.Add(this.buttonEncrypt);
            this.groupBoxEncrypt.Controls.Add(this.buttonAESKey);
            this.groupBoxEncrypt.Controls.Add(this.buttonRSAKey);
            this.groupBoxEncrypt.Controls.Add(this.buttonMessageRSA);
            this.groupBoxEncrypt.Location = new System.Drawing.Point(18, 20);
            this.groupBoxEncrypt.Name = "groupBoxEncrypt";
            this.groupBoxEncrypt.Size = new System.Drawing.Size(270, 180);
            this.groupBoxEncrypt.TabIndex = 0;
            this.groupBoxEncrypt.TabStop = false;
            this.groupBoxEncrypt.Text = "Зашифрование";
            // 
            // checkBoxRandomAES
            // 
            this.checkBoxRandomAES.AutoSize = true;
            this.checkBoxRandomAES.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.checkBoxRandomAES.Location = new System.Drawing.Point(90, 101);
            this.checkBoxRandomAES.Name = "checkBoxRandomAES";
            this.checkBoxRandomAES.Size = new System.Drawing.Size(55, 19);
            this.checkBoxRandomAES.TabIndex = 7;
            this.checkBoxRandomAES.Text = "Случ.";
            this.checkBoxRandomAES.UseVisualStyleBackColor = true;
            this.checkBoxRandomAES.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // labelAESKey
            // 
            this.labelAESKey.AutoSize = true;
            this.labelAESKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelAESKey.Location = new System.Drawing.Point(21, 102);
            this.labelAESKey.Name = "labelAESKey";
            this.labelAESKey.Size = new System.Drawing.Size(58, 15);
            this.labelAESKey.TabIndex = 6;
            this.labelAESKey.Text = "Ключ AES";
            // 
            // labelRSAOpenKey
            // 
            this.labelRSAOpenKey.AutoSize = true;
            this.labelRSAOpenKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelRSAOpenKey.Location = new System.Drawing.Point(21, 64);
            this.labelRSAOpenKey.Name = "labelRSAOpenKey";
            this.labelRSAOpenKey.Size = new System.Drawing.Size(126, 15);
            this.labelRSAOpenKey.TabIndex = 5;
            this.labelRSAOpenKey.Text = "Открытый ключ RSA";
            // 
            // labelMessageEncrypt
            // 
            this.labelMessageEncrypt.AutoSize = true;
            this.labelMessageEncrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMessageEncrypt.Location = new System.Drawing.Point(21, 26);
            this.labelMessageEncrypt.Name = "labelMessageEncrypt";
            this.labelMessageEncrypt.Size = new System.Drawing.Size(100, 15);
            this.labelMessageEncrypt.TabIndex = 4;
            this.labelMessageEncrypt.Text = "Файл сообщения";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEncrypt.Location = new System.Drawing.Point(21, 136);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(230, 30);
            this.buttonEncrypt.TabIndex = 3;
            this.buttonEncrypt.Text = "Зашифровать";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonAESKey
            // 
            this.buttonAESKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonAESKey.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonAESKey.Location = new System.Drawing.Point(176, 98);
            this.buttonAESKey.Name = "buttonAESKey";
            this.buttonAESKey.Size = new System.Drawing.Size(75, 23);
            this.buttonAESKey.TabIndex = 2;
            this.buttonAESKey.Text = "Выбрать";
            this.buttonAESKey.UseVisualStyleBackColor = true;
            this.buttonAESKey.Click += new System.EventHandler(this.buttonAESKey_Click);
            // 
            // buttonRSAKey
            // 
            this.buttonRSAKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonRSAKey.Location = new System.Drawing.Point(176, 60);
            this.buttonRSAKey.Name = "buttonRSAKey";
            this.buttonRSAKey.Size = new System.Drawing.Size(75, 23);
            this.buttonRSAKey.TabIndex = 1;
            this.buttonRSAKey.Text = "Выбрать";
            this.buttonRSAKey.UseVisualStyleBackColor = true;
            this.buttonRSAKey.Click += new System.EventHandler(this.buttonRSAKey_Click);
            // 
            // buttonMessageRSA
            // 
            this.buttonMessageRSA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonMessageRSA.Location = new System.Drawing.Point(176, 22);
            this.buttonMessageRSA.Name = "buttonMessageRSA";
            this.buttonMessageRSA.Size = new System.Drawing.Size(75, 23);
            this.buttonMessageRSA.TabIndex = 0;
            this.buttonMessageRSA.Text = "Выбрать";
            this.buttonMessageRSA.UseVisualStyleBackColor = true;
            this.buttonMessageRSA.Click += new System.EventHandler(this.buttonMessageRSA_Click);
            // 
            // tabPageSignature
            // 
            this.tabPageSignature.Controls.Add(this.groupBoxVerify);
            this.tabPageSignature.Controls.Add(this.groupBoxSign);
            this.tabPageSignature.Location = new System.Drawing.Point(4, 24);
            this.tabPageSignature.Name = "tabPageSignature";
            this.tabPageSignature.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSignature.Size = new System.Drawing.Size(304, 376);
            this.tabPageSignature.TabIndex = 1;
            this.tabPageSignature.Text = "RSA ЭЦП";
            this.tabPageSignature.UseVisualStyleBackColor = true;
            // 
            // groupBoxVerify
            // 
            this.groupBoxVerify.Controls.Add(this.labelSignmentVerify);
            this.groupBoxVerify.Controls.Add(this.labelMessageVerify);
            this.groupBoxVerify.Controls.Add(this.buttonVerify);
            this.groupBoxVerify.Controls.Add(this.buttonSignmentVerify);
            this.groupBoxVerify.Controls.Add(this.buttonMessageVerify);
            this.groupBoxVerify.Location = new System.Drawing.Point(16, 217);
            this.groupBoxVerify.Name = "groupBoxVerify";
            this.groupBoxVerify.Size = new System.Drawing.Size(269, 153);
            this.groupBoxVerify.TabIndex = 2;
            this.groupBoxVerify.TabStop = false;
            this.groupBoxVerify.Text = "Проверка подписи";
            // 
            // labelSignmentVerify
            // 
            this.labelSignmentVerify.AutoSize = true;
            this.labelSignmentVerify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelSignmentVerify.Location = new System.Drawing.Point(21, 64);
            this.labelSignmentVerify.Name = "labelSignmentVerify";
            this.labelSignmentVerify.Size = new System.Drawing.Size(86, 15);
            this.labelSignmentVerify.TabIndex = 5;
            this.labelSignmentVerify.Text = "Файл подписи";
            // 
            // labelMessageVerify
            // 
            this.labelMessageVerify.AutoSize = true;
            this.labelMessageVerify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMessageVerify.Location = new System.Drawing.Point(21, 26);
            this.labelMessageVerify.Name = "labelMessageVerify";
            this.labelMessageVerify.Size = new System.Drawing.Size(100, 15);
            this.labelMessageVerify.TabIndex = 4;
            this.labelMessageVerify.Text = "Файл сообщения";
            // 
            // buttonVerify
            // 
            this.buttonVerify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonVerify.Location = new System.Drawing.Point(21, 106);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(230, 30);
            this.buttonVerify.TabIndex = 3;
            this.buttonVerify.Text = "Проверить подпись";
            this.buttonVerify.UseVisualStyleBackColor = true;
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
            // 
            // buttonSignmentVerify
            // 
            this.buttonSignmentVerify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonSignmentVerify.Location = new System.Drawing.Point(176, 60);
            this.buttonSignmentVerify.Name = "buttonSignmentVerify";
            this.buttonSignmentVerify.Size = new System.Drawing.Size(75, 23);
            this.buttonSignmentVerify.TabIndex = 1;
            this.buttonSignmentVerify.Text = "Выбрать";
            this.buttonSignmentVerify.UseVisualStyleBackColor = true;
            this.buttonSignmentVerify.Click += new System.EventHandler(this.buttonSignmentVerify_Click);
            // 
            // buttonMessageVerify
            // 
            this.buttonMessageVerify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonMessageVerify.Location = new System.Drawing.Point(176, 22);
            this.buttonMessageVerify.Name = "buttonMessageVerify";
            this.buttonMessageVerify.Size = new System.Drawing.Size(75, 23);
            this.buttonMessageVerify.TabIndex = 0;
            this.buttonMessageVerify.Text = "Выбрать";
            this.buttonMessageVerify.UseVisualStyleBackColor = true;
            this.buttonMessageVerify.Click += new System.EventHandler(this.buttonMessageVerify_Click);
            // 
            // groupBoxSign
            // 
            this.groupBoxSign.Controls.Add(this.buttonRSAPublicKeySign);
            this.groupBoxSign.Controls.Add(this.labelPublicKeySign);
            this.groupBoxSign.Controls.Add(this.labelRSAPrivateKeySign);
            this.groupBoxSign.Controls.Add(this.labelMessageSign);
            this.groupBoxSign.Controls.Add(this.buttonSign);
            this.groupBoxSign.Controls.Add(this.buttonRSAPrivateKeySign);
            this.groupBoxSign.Controls.Add(this.buttonMessageSign);
            this.groupBoxSign.Location = new System.Drawing.Point(16, 18);
            this.groupBoxSign.Name = "groupBoxSign";
            this.groupBoxSign.Size = new System.Drawing.Size(270, 180);
            this.groupBoxSign.TabIndex = 1;
            this.groupBoxSign.TabStop = false;
            this.groupBoxSign.Text = "Создание подписи";
            // 
            // buttonRSAPublicKeySign
            // 
            this.buttonRSAPublicKeySign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonRSAPublicKeySign.Location = new System.Drawing.Point(176, 60);
            this.buttonRSAPublicKeySign.Name = "buttonRSAPublicKeySign";
            this.buttonRSAPublicKeySign.Size = new System.Drawing.Size(75, 23);
            this.buttonRSAPublicKeySign.TabIndex = 7;
            this.buttonRSAPublicKeySign.Text = "Выбрать";
            this.buttonRSAPublicKeySign.UseVisualStyleBackColor = true;
            this.buttonRSAPublicKeySign.Click += new System.EventHandler(this.buttonRSAPublicKeySign_Click);
            // 
            // labelPublicKeySign
            // 
            this.labelPublicKeySign.AutoSize = true;
            this.labelPublicKeySign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelPublicKeySign.Location = new System.Drawing.Point(21, 64);
            this.labelPublicKeySign.Name = "labelPublicKeySign";
            this.labelPublicKeySign.Size = new System.Drawing.Size(126, 15);
            this.labelPublicKeySign.TabIndex = 6;
            this.labelPublicKeySign.Text = "Открытый ключ RSA";
            // 
            // labelRSAPrivateKeySign
            // 
            this.labelRSAPrivateKeySign.AutoSize = true;
            this.labelRSAPrivateKeySign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelRSAPrivateKeySign.Location = new System.Drawing.Point(21, 100);
            this.labelRSAPrivateKeySign.Name = "labelRSAPrivateKeySign";
            this.labelRSAPrivateKeySign.Size = new System.Drawing.Size(120, 15);
            this.labelRSAPrivateKeySign.TabIndex = 5;
            this.labelRSAPrivateKeySign.Text = "Закрытый ключ RSA";
            // 
            // labelMessageSign
            // 
            this.labelMessageSign.AutoSize = true;
            this.labelMessageSign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMessageSign.Location = new System.Drawing.Point(21, 26);
            this.labelMessageSign.Name = "labelMessageSign";
            this.labelMessageSign.Size = new System.Drawing.Size(100, 15);
            this.labelMessageSign.TabIndex = 4;
            this.labelMessageSign.Text = "Файл сообщения";
            // 
            // buttonSign
            // 
            this.buttonSign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSign.Location = new System.Drawing.Point(21, 136);
            this.buttonSign.Name = "buttonSign";
            this.buttonSign.Size = new System.Drawing.Size(230, 30);
            this.buttonSign.TabIndex = 3;
            this.buttonSign.Text = "Подписать";
            this.buttonSign.UseVisualStyleBackColor = true;
            this.buttonSign.Click += new System.EventHandler(this.buttonSign_Click);
            // 
            // buttonRSAPrivateKeySign
            // 
            this.buttonRSAPrivateKeySign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonRSAPrivateKeySign.Location = new System.Drawing.Point(176, 96);
            this.buttonRSAPrivateKeySign.Name = "buttonRSAPrivateKeySign";
            this.buttonRSAPrivateKeySign.Size = new System.Drawing.Size(75, 23);
            this.buttonRSAPrivateKeySign.TabIndex = 1;
            this.buttonRSAPrivateKeySign.Text = "Выбрать";
            this.buttonRSAPrivateKeySign.UseVisualStyleBackColor = true;
            this.buttonRSAPrivateKeySign.Click += new System.EventHandler(this.buttonRSAPrivateKeySign_Click);
            // 
            // buttonMessageSign
            // 
            this.buttonMessageSign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonMessageSign.Location = new System.Drawing.Point(176, 22);
            this.buttonMessageSign.Name = "buttonMessageSign";
            this.buttonMessageSign.Size = new System.Drawing.Size(75, 23);
            this.buttonMessageSign.TabIndex = 0;
            this.buttonMessageSign.Text = "Выбрать";
            this.buttonMessageSign.UseVisualStyleBackColor = true;
            this.buttonMessageSign.Click += new System.EventHandler(this.buttonMessageSign_Click);
            // 
            // tabPageGOST
            // 
            this.tabPageGOST.Controls.Add(this.buttonGOSTSignMsg);
            this.tabPageGOST.Controls.Add(this.labelGOSTSignFilename);
            this.tabPageGOST.Controls.Add(this.buttonGOSTSign);
            this.tabPageGOST.Controls.Add(this.textBoxGOSTD);
            this.tabPageGOST.Controls.Add(this.labelGOSTD);
            this.tabPageGOST.Controls.Add(this.groupBoxCurveParams);
            this.tabPageGOST.Location = new System.Drawing.Point(4, 24);
            this.tabPageGOST.Name = "tabPageGOST";
            this.tabPageGOST.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGOST.Size = new System.Drawing.Size(304, 376);
            this.tabPageGOST.TabIndex = 2;
            this.tabPageGOST.Text = "ГОСТ ЭЦП";
            this.tabPageGOST.UseVisualStyleBackColor = true;
            // 
            // buttonGOSTSignMsg
            // 
            this.buttonGOSTSignMsg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonGOSTSignMsg.Location = new System.Drawing.Point(210, 281);
            this.buttonGOSTSignMsg.Name = "buttonGOSTSignMsg";
            this.buttonGOSTSignMsg.Size = new System.Drawing.Size(75, 23);
            this.buttonGOSTSignMsg.TabIndex = 11;
            this.buttonGOSTSignMsg.Text = "Выбрать";
            this.buttonGOSTSignMsg.UseVisualStyleBackColor = true;
            this.buttonGOSTSignMsg.Click += new System.EventHandler(this.buttonGOSTSignMsg_Click);
            // 
            // labelGOSTSignFilename
            // 
            this.labelGOSTSignFilename.AutoSize = true;
            this.labelGOSTSignFilename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelGOSTSignFilename.Location = new System.Drawing.Point(12, 285);
            this.labelGOSTSignFilename.Name = "labelGOSTSignFilename";
            this.labelGOSTSignFilename.Size = new System.Drawing.Size(100, 15);
            this.labelGOSTSignFilename.TabIndex = 10;
            this.labelGOSTSignFilename.Text = "Файл сообщения";
            // 
            // buttonGOSTSign
            // 
            this.buttonGOSTSign.Location = new System.Drawing.Point(18, 323);
            this.buttonGOSTSign.Name = "buttonGOSTSign";
            this.buttonGOSTSign.Size = new System.Drawing.Size(273, 23);
            this.buttonGOSTSign.TabIndex = 9;
            this.buttonGOSTSign.Text = "Подписать";
            this.buttonGOSTSign.UseVisualStyleBackColor = true;
            this.buttonGOSTSign.Click += new System.EventHandler(this.buttonGOSTSign_Click);
            // 
            // textBoxGOSTD
            // 
            this.textBoxGOSTD.Location = new System.Drawing.Point(111, 239);
            this.textBoxGOSTD.Name = "textBoxGOSTD";
            this.textBoxGOSTD.Size = new System.Drawing.Size(174, 23);
            this.textBoxGOSTD.TabIndex = 8;
            this.textBoxGOSTD.Text = "55441196065363246126355624130324183196576709222340016572108097750006097525544";
            // 
            // labelGOSTD
            // 
            this.labelGOSTD.AutoSize = true;
            this.labelGOSTD.Location = new System.Drawing.Point(12, 242);
            this.labelGOSTD.Name = "labelGOSTD";
            this.labelGOSTD.Size = new System.Drawing.Size(79, 15);
            this.labelGOSTD.TabIndex = 1;
            this.labelGOSTD.Text = "Закр. ключ d";
            // 
            // groupBoxCurveParams
            // 
            this.groupBoxCurveParams.Controls.Add(this.textBoxGOSTP);
            this.groupBoxCurveParams.Controls.Add(this.textBoxGOSTB);
            this.groupBoxCurveParams.Controls.Add(this.textBoxGOSTA);
            this.groupBoxCurveParams.Controls.Add(this.groupBoxBasePoint);
            this.groupBoxCurveParams.Controls.Add(this.labelCurveModule);
            this.groupBoxCurveParams.Controls.Add(this.labelCurveB);
            this.groupBoxCurveParams.Controls.Add(this.labelCurveA);
            this.groupBoxCurveParams.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCurveParams.Name = "groupBoxCurveParams";
            this.groupBoxCurveParams.Size = new System.Drawing.Size(292, 217);
            this.groupBoxCurveParams.TabIndex = 0;
            this.groupBoxCurveParams.TabStop = false;
            this.groupBoxCurveParams.Text = "Параметры Кривой";
            // 
            // textBoxGOSTP
            // 
            this.textBoxGOSTP.Location = new System.Drawing.Point(112, 74);
            this.textBoxGOSTP.Name = "textBoxGOSTP";
            this.textBoxGOSTP.Size = new System.Drawing.Size(174, 23);
            this.textBoxGOSTP.TabIndex = 6;
            this.textBoxGOSTP.Text = "57896044622894643241131754937450315750132642216230685504884320870273678881443";
            // 
            // textBoxGOSTB
            // 
            this.textBoxGOSTB.Location = new System.Drawing.Point(112, 45);
            this.textBoxGOSTB.Name = "textBoxGOSTB";
            this.textBoxGOSTB.Size = new System.Drawing.Size(174, 23);
            this.textBoxGOSTB.TabIndex = 5;
            this.textBoxGOSTB.Text = "41431894589448105498289586872587560387979247722721848579560344157562082667257";
            // 
            // textBoxGOSTA
            // 
            this.textBoxGOSTA.Location = new System.Drawing.Point(112, 16);
            this.textBoxGOSTA.Name = "textBoxGOSTA";
            this.textBoxGOSTA.Size = new System.Drawing.Size(174, 23);
            this.textBoxGOSTA.TabIndex = 4;
            this.textBoxGOSTA.Text = "1";
            // 
            // groupBoxBasePoint
            // 
            this.groupBoxBasePoint.Controls.Add(this.textBoxGOSTQ);
            this.groupBoxBasePoint.Controls.Add(this.textBoxGOSTyP);
            this.groupBoxBasePoint.Controls.Add(this.textBoxGOSTxP);
            this.groupBoxBasePoint.Controls.Add(this.labelBasePointQ);
            this.groupBoxBasePoint.Controls.Add(this.labelBasePointY);
            this.groupBoxBasePoint.Controls.Add(this.labeBasePointX);
            this.groupBoxBasePoint.Location = new System.Drawing.Point(6, 103);
            this.groupBoxBasePoint.Name = "groupBoxBasePoint";
            this.groupBoxBasePoint.Size = new System.Drawing.Size(279, 108);
            this.groupBoxBasePoint.TabIndex = 3;
            this.groupBoxBasePoint.TabStop = false;
            this.groupBoxBasePoint.Text = "Базовая точка";
            // 
            // textBoxGOSTQ
            // 
            this.textBoxGOSTQ.Location = new System.Drawing.Point(99, 74);
            this.textBoxGOSTQ.Name = "textBoxGOSTQ";
            this.textBoxGOSTQ.Size = new System.Drawing.Size(174, 23);
            this.textBoxGOSTQ.TabIndex = 7;
            this.textBoxGOSTQ.Text = "28948022311447321620565877468725157875067316353637126186229732812867492750347";
            // 
            // textBoxGOSTyP
            // 
            this.textBoxGOSTyP.Location = new System.Drawing.Point(99, 45);
            this.textBoxGOSTyP.Name = "textBoxGOSTyP";
            this.textBoxGOSTyP.Size = new System.Drawing.Size(174, 23);
            this.textBoxGOSTyP.TabIndex = 6;
            this.textBoxGOSTyP.Text = "42098178416750523198643432544018510845496542305814546233883323764837032783338";
            // 
            // textBoxGOSTxP
            // 
            this.textBoxGOSTxP.Location = new System.Drawing.Point(99, 16);
            this.textBoxGOSTxP.Name = "textBoxGOSTxP";
            this.textBoxGOSTxP.Size = new System.Drawing.Size(174, 23);
            this.textBoxGOSTxP.TabIndex = 5;
            this.textBoxGOSTxP.Text = "54672615043105947691210796380713598019547553171137275980323095812145568854782";
            // 
            // labelBasePointQ
            // 
            this.labelBasePointQ.AutoSize = true;
            this.labelBasePointQ.Location = new System.Drawing.Point(6, 77);
            this.labelBasePointQ.Name = "labelBasePointQ";
            this.labelBasePointQ.Size = new System.Drawing.Size(65, 15);
            this.labelBasePointQ.TabIndex = 2;
            this.labelBasePointQ.Text = "Порядок q";
            // 
            // labelBasePointY
            // 
            this.labelBasePointY.AutoSize = true;
            this.labelBasePointY.Location = new System.Drawing.Point(6, 48);
            this.labelBasePointY.Name = "labelBasePointY";
            this.labelBasePointY.Size = new System.Drawing.Size(20, 15);
            this.labelBasePointY.TabIndex = 1;
            this.labelBasePointY.Text = "yP";
            // 
            // labeBasePointX
            // 
            this.labeBasePointX.AutoSize = true;
            this.labeBasePointX.Location = new System.Drawing.Point(6, 19);
            this.labeBasePointX.Name = "labeBasePointX";
            this.labeBasePointX.Size = new System.Drawing.Size(20, 15);
            this.labeBasePointX.TabIndex = 0;
            this.labeBasePointX.Text = "xP";
            // 
            // labelCurveModule
            // 
            this.labelCurveModule.AutoSize = true;
            this.labelCurveModule.Location = new System.Drawing.Point(6, 77);
            this.labelCurveModule.Name = "labelCurveModule";
            this.labelCurveModule.Size = new System.Drawing.Size(60, 15);
            this.labelCurveModule.TabIndex = 2;
            this.labelCurveModule.Text = "Модуль p";
            // 
            // labelCurveB
            // 
            this.labelCurveB.AutoSize = true;
            this.labelCurveB.Location = new System.Drawing.Point(6, 48);
            this.labelCurveB.Name = "labelCurveB";
            this.labelCurveB.Size = new System.Drawing.Size(14, 15);
            this.labelCurveB.TabIndex = 1;
            this.labelCurveB.Text = "B";
            // 
            // labelCurveA
            // 
            this.labelCurveA.AutoSize = true;
            this.labelCurveA.Location = new System.Drawing.Point(6, 19);
            this.labelCurveA.Name = "labelCurveA";
            this.labelCurveA.Size = new System.Drawing.Size(15, 15);
            this.labelCurveA.TabIndex = 0;
            this.labelCurveA.Text = "A";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonGOSTVerify);
            this.tabPage1.Controls.Add(this.buttonGOSTSignFile);
            this.tabPage1.Controls.Add(this.buttonGOSTMsg);
            this.tabPage1.Controls.Add(this.labelGOSTSign);
            this.tabPage1.Controls.Add(this.labelGOSTMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(304, 376);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "ГОСТ Проверка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonGOSTVerify
            // 
            this.buttonGOSTVerify.Location = new System.Drawing.Point(22, 108);
            this.buttonGOSTVerify.Name = "buttonGOSTVerify";
            this.buttonGOSTVerify.Size = new System.Drawing.Size(255, 23);
            this.buttonGOSTVerify.TabIndex = 4;
            this.buttonGOSTVerify.Text = "Проверить подпись";
            this.buttonGOSTVerify.UseVisualStyleBackColor = true;
            this.buttonGOSTVerify.Click += new System.EventHandler(this.buttonGOSTVerify_Click);
            // 
            // buttonGOSTSignFile
            // 
            this.buttonGOSTSignFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonGOSTSignFile.Location = new System.Drawing.Point(202, 59);
            this.buttonGOSTSignFile.Name = "buttonGOSTSignFile";
            this.buttonGOSTSignFile.Size = new System.Drawing.Size(75, 23);
            this.buttonGOSTSignFile.TabIndex = 3;
            this.buttonGOSTSignFile.Text = "Выбрать";
            this.buttonGOSTSignFile.UseVisualStyleBackColor = true;
            this.buttonGOSTSignFile.Click += new System.EventHandler(this.buttonGOSTSignFile_Click);
            // 
            // buttonGOSTMsg
            // 
            this.buttonGOSTMsg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.buttonGOSTMsg.Location = new System.Drawing.Point(202, 23);
            this.buttonGOSTMsg.Name = "buttonGOSTMsg";
            this.buttonGOSTMsg.Size = new System.Drawing.Size(75, 23);
            this.buttonGOSTMsg.TabIndex = 2;
            this.buttonGOSTMsg.Text = "Выбрать";
            this.buttonGOSTMsg.UseVisualStyleBackColor = true;
            this.buttonGOSTMsg.Click += new System.EventHandler(this.buttonGOSTMsg_Click);
            // 
            // labelGOSTSign
            // 
            this.labelGOSTSign.AutoSize = true;
            this.labelGOSTSign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelGOSTSign.Location = new System.Drawing.Point(22, 67);
            this.labelGOSTSign.Name = "labelGOSTSign";
            this.labelGOSTSign.Size = new System.Drawing.Size(33, 15);
            this.labelGOSTSign.TabIndex = 1;
            this.labelGOSTSign.Text = "ЭЦП";
            // 
            // labelGOSTMessage
            // 
            this.labelGOSTMessage.AutoSize = true;
            this.labelGOSTMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelGOSTMessage.Location = new System.Drawing.Point(22, 27);
            this.labelGOSTMessage.Name = "labelGOSTMessage";
            this.labelGOSTMessage.Size = new System.Drawing.Size(70, 15);
            this.labelGOSTMessage.TabIndex = 0;
            this.labelGOSTMessage.Text = "Сообщение";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.атакаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(334, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьКлючToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьКлючToolStripMenuItem
            // 
            this.создатьКлючToolStripMenuItem.Name = "создатьКлючToolStripMenuItem";
            this.создатьКлючToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.создатьКлючToolStripMenuItem.Text = "Создать ключ...";
            this.создатьКлючToolStripMenuItem.Click += new System.EventHandler(this.создатьКлючToolStripMenuItem_Click);
            // 
            // атакаToolStripMenuItem
            // 
            this.атакаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ключиСОбщимМодулемToolStripMenuItem,
            this.атакаВинераToolStripMenuItem,
            this.малыйОбщийПоказательToolStripMenuItem});
            this.атакаToolStripMenuItem.Name = "атакаToolStripMenuItem";
            this.атакаToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.атакаToolStripMenuItem.Text = "Атака";
            // 
            // ключиСОбщимМодулемToolStripMenuItem
            // 
            this.ключиСОбщимМодулемToolStripMenuItem.Name = "ключиСОбщимМодулемToolStripMenuItem";
            this.ключиСОбщимМодулемToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.ключиСОбщимМодулемToolStripMenuItem.Text = "Ключи с общим модулем";
            this.ключиСОбщимМодулемToolStripMenuItem.Click += new System.EventHandler(this.ключиСОбщимМодулемToolStripMenuItem_Click);
            // 
            // атакаВинераToolStripMenuItem
            // 
            this.атакаВинераToolStripMenuItem.Name = "атакаВинераToolStripMenuItem";
            this.атакаВинераToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.атакаВинераToolStripMenuItem.Text = "Атака Винера";
            this.атакаВинераToolStripMenuItem.Click += new System.EventHandler(this.атакаВинераToolStripMenuItem_Click);
            // 
            // малыйОбщийПоказательToolStripMenuItem
            // 
            this.малыйОбщийПоказательToolStripMenuItem.Name = "малыйОбщийПоказательToolStripMenuItem";
            this.малыйОбщийПоказательToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.малыйОбщийПоказательToolStripMenuItem.Text = "Малый общий показатель";
            this.малыйОбщийПоказательToolStripMenuItem.Click += new System.EventHandler(this.малыйОбщийПоказательToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 437);
            this.Controls.Add(this.tabControlGOSTVerify);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Криптоконверт";
            this.tabControlGOSTVerify.ResumeLayout(false);
            this.tabPageCipher.ResumeLayout(false);
            this.groupBoxDecrypt.ResumeLayout(false);
            this.groupBoxDecrypt.PerformLayout();
            this.groupBoxEncrypt.ResumeLayout(false);
            this.groupBoxEncrypt.PerformLayout();
            this.tabPageSignature.ResumeLayout(false);
            this.groupBoxVerify.ResumeLayout(false);
            this.groupBoxVerify.PerformLayout();
            this.groupBoxSign.ResumeLayout(false);
            this.groupBoxSign.PerformLayout();
            this.tabPageGOST.ResumeLayout(false);
            this.tabPageGOST.PerformLayout();
            this.groupBoxCurveParams.ResumeLayout(false);
            this.groupBoxCurveParams.PerformLayout();
            this.groupBoxBasePoint.ResumeLayout(false);
            this.groupBoxBasePoint.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TabPage tabPageCipher;
        private TabPage tabPageSignature;
        private GroupBox groupBoxDecrypt;
        private Button buttonDecrypt;
        private Button buttonMessageDecrypt;
        private Label labelMessageDecrypt;
        private GroupBox groupBoxEncrypt;
        private Label labelAESKey;
        private Label labelRSAOpenKey;
        private Label labelMessageEncrypt;
        private Button buttonEncrypt;
        private Button buttonAESKey;
        private Button buttonRSAKey;
        private Button buttonMessageRSA;
        private GroupBox groupBoxVerify;
        private Label labelSignmentVerify;
        private Label labelMessageVerify;
        private Button buttonVerify;
        private Button buttonSignmentVerify;
        private Button buttonMessageVerify;
        private GroupBox groupBoxSign;
        private Label labelRSAPrivateKeySign;
        private Label labelMessageSign;
        private Button buttonSign;
        private Button buttonRSAPrivateKeySign;
        private Button buttonMessageSign;
        public TabControl tabControlGOSTVerify;
        private CheckBox checkBoxRandomAES;
        private Label labelRSAPrivateKey;
        private Button buttonRSAPrivateKey;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private Button buttonRSAPublicKeySign;
        private Label labelPublicKeySign;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem создатьКлючToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem атакаToolStripMenuItem;
        private ToolStripMenuItem ключиСОбщимМодулемToolStripMenuItem;
        private ToolStripMenuItem атакаВинераToolStripMenuItem;
        private ToolStripMenuItem малыйОбщийПоказательToolStripMenuItem;
        private TabPage tabPageGOST;
        private GroupBox groupBoxCurveParams;
        private GroupBox groupBoxBasePoint;
        private Label labelBasePointQ;
        private Label labelBasePointY;
        private Label labeBasePointX;
        private Label labelCurveModule;
        private Label labelCurveB;
        private Label labelCurveA;
        private TextBox textBoxGOSTP;
        private TextBox textBoxGOSTB;
        private TextBox textBoxGOSTA;
        private TextBox textBoxGOSTQ;
        private TextBox textBoxGOSTyP;
        private TextBox textBoxGOSTxP;
        private Button buttonGOSTSign;
        private TextBox textBoxGOSTD;
        private Label labelGOSTD;
        private TabPage tabPage1;
        private Label labelGOSTSign;
        private Label labelGOSTMessage;
        private Button buttonGOSTSignFile;
        private Button buttonGOSTMsg;
        private Button buttonGOSTVerify;
        private Label labelGOSTSignFilename;
        private Button buttonGOSTSignMsg;
    }
}