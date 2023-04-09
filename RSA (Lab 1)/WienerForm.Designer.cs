namespace RSA__Lab_1_
{
    partial class WienerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WienerForm));
            this.groupBoxWienerParameters = new System.Windows.Forms.GroupBox();
            this.labelWienerN = new System.Windows.Forms.Label();
            this.labelWienerE = new System.Windows.Forms.Label();
            this.textBoxWienerN = new System.Windows.Forms.TextBox();
            this.textBoxWienerE = new System.Windows.Forms.TextBox();
            this.buttonGetFromFile = new System.Windows.Forms.Button();
            this.labelWienerD = new System.Windows.Forms.Label();
            this.textBoxWienerD = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxWienerParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxWienerParameters
            // 
            this.groupBoxWienerParameters.Controls.Add(this.buttonStart);
            this.groupBoxWienerParameters.Controls.Add(this.buttonSave);
            this.groupBoxWienerParameters.Controls.Add(this.textBoxWienerD);
            this.groupBoxWienerParameters.Controls.Add(this.labelWienerD);
            this.groupBoxWienerParameters.Controls.Add(this.buttonGetFromFile);
            this.groupBoxWienerParameters.Controls.Add(this.textBoxWienerE);
            this.groupBoxWienerParameters.Controls.Add(this.textBoxWienerN);
            this.groupBoxWienerParameters.Controls.Add(this.labelWienerE);
            this.groupBoxWienerParameters.Controls.Add(this.labelWienerN);
            this.groupBoxWienerParameters.Location = new System.Drawing.Point(12, 12);
            this.groupBoxWienerParameters.Name = "groupBoxWienerParameters";
            this.groupBoxWienerParameters.Size = new System.Drawing.Size(471, 125);
            this.groupBoxWienerParameters.TabIndex = 0;
            this.groupBoxWienerParameters.TabStop = false;
            this.groupBoxWienerParameters.Text = "Параметры";
            // 
            // labelWienerN
            // 
            this.labelWienerN.AutoSize = true;
            this.labelWienerN.Location = new System.Drawing.Point(19, 29);
            this.labelWienerN.Name = "labelWienerN";
            this.labelWienerN.Size = new System.Drawing.Size(70, 15);
            this.labelWienerN.TabIndex = 0;
            this.labelWienerN.Text = "Модуль (N)";
            // 
            // labelWienerE
            // 
            this.labelWienerE.AutoSize = true;
            this.labelWienerE.Location = new System.Drawing.Point(19, 58);
            this.labelWienerE.Name = "labelWienerE";
            this.labelWienerE.Size = new System.Drawing.Size(145, 15);
            this.labelWienerE.TabIndex = 1;
            this.labelWienerE.Text = "Открытый показатель (E)";
            // 
            // textBoxWienerN
            // 
            this.textBoxWienerN.Location = new System.Drawing.Point(174, 26);
            this.textBoxWienerN.Name = "textBoxWienerN";
            this.textBoxWienerN.Size = new System.Drawing.Size(174, 23);
            this.textBoxWienerN.TabIndex = 2;
            // 
            // textBoxWienerE
            // 
            this.textBoxWienerE.Location = new System.Drawing.Point(174, 55);
            this.textBoxWienerE.Name = "textBoxWienerE";
            this.textBoxWienerE.Size = new System.Drawing.Size(174, 23);
            this.textBoxWienerE.TabIndex = 3;
            // 
            // buttonGetFromFile
            // 
            this.buttonGetFromFile.Location = new System.Drawing.Point(366, 25);
            this.buttonGetFromFile.Name = "buttonGetFromFile";
            this.buttonGetFromFile.Size = new System.Drawing.Size(75, 23);
            this.buttonGetFromFile.TabIndex = 4;
            this.buttonGetFromFile.Text = "Открыть...";
            this.buttonGetFromFile.UseVisualStyleBackColor = true;
            this.buttonGetFromFile.Click += new System.EventHandler(this.buttonGetFromFile_Click);
            // 
            // labelWienerD
            // 
            this.labelWienerD.AutoSize = true;
            this.labelWienerD.Location = new System.Drawing.Point(19, 87);
            this.labelWienerD.Name = "labelWienerD";
            this.labelWienerD.Size = new System.Drawing.Size(127, 15);
            this.labelWienerD.TabIndex = 5;
            this.labelWienerD.Text = "Закрытый показатель";
            // 
            // textBoxWienerD
            // 
            this.textBoxWienerD.Location = new System.Drawing.Point(174, 84);
            this.textBoxWienerD.Name = "textBoxWienerD";
            this.textBoxWienerD.Size = new System.Drawing.Size(174, 23);
            this.textBoxWienerD.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(366, 83);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStart.Location = new System.Drawing.Point(366, 54);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // WienerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 151);
            this.Controls.Add(this.groupBoxWienerParameters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WienerForm";
            this.Text = "Атака Винера";
            this.groupBoxWienerParameters.ResumeLayout(false);
            this.groupBoxWienerParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxWienerParameters;
        private Button buttonSave;
        private TextBox textBoxWienerD;
        private Label labelWienerD;
        private Button buttonGetFromFile;
        private TextBox textBoxWienerE;
        private TextBox textBoxWienerN;
        private Label labelWienerE;
        private Label labelWienerN;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private Button buttonStart;
    }
}