using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA__Lab_1_
{
    internal class CommonEPanel : Panel
    {
        OpenFileDialog openFileDialog;
        public string keyFilename;
        public string cipherTextFilename;

        public CommonEPanel(int number = 1)
        {
            this.Height = 75;
            this.Width = 295;
            this.BorderStyle = BorderStyle.FixedSingle;


            openFileDialog = new OpenFileDialog();

            

            Label labelPublicKey = new Label();
            labelPublicKey.Location = new Point(13, 14);
            labelPublicKey.AutoSize = true;
            labelPublicKey.Text = "Открытый ключ";

            Label labelCipherText = new Label();
            labelCipherText.Location = new Point(13, 40);
            labelCipherText.Text = "Шифртекст";

            Button openKeyButton = new Button();
            openKeyButton.Location = new Point(132, 10);
            openKeyButton.Text = "Открыть...";
            openKeyButton.Click += openKeyButtonClick;

            Button CipherTextButton = new Button();
            CipherTextButton.Location = new Point(132, 40);
            CipherTextButton.Text = "Открыть...";
            CipherTextButton.Click += openCipherTextButtonClick;

            Label labelNumber = new Label();
            labelNumber.Location = new Point(250, 10);
            labelNumber.Text = "# " + number.ToString();

            this.Controls.Add(labelPublicKey);
            this.Controls.Add(openKeyButton);
            this.Controls.Add(labelCipherText);
            this.Controls.Add(CipherTextButton);
            this.Controls.Add(labelNumber);

        }

        public void openKeyButtonClick(object sender, EventArgs e)
        {
            openFileDialog.Title = "Открытый ключ";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            keyFilename = filename;

            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }


            this.Controls[0].Text = filename;
        }

        public void openCipherTextButtonClick(object sender, EventArgs e)
        {
            openFileDialog.Title = "Шифртекст";
            openFileDialog.Filter = "Файлы шифртекста (*.bin)|*.bin";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            cipherTextFilename = filename;

            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }

            this.Controls[2].Text = filename;
        }
    }

    
}
