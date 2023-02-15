using System;
using System.Formats.Asn1;
using System.IO;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Windows.Forms;
using static RSA__Lab_1_.CryptoEnvelope;

namespace RSA__Lab_1_
{
    public partial class MainForm : Form
    {
        private CryptoEnvelope envelope;
        public MainForm()
        {
            InitializeComponent();
            envelope = new CryptoEnvelope();
            
        }

        private string encryptMessageFilename;
        private string encryptRSAPublicKeyFilename;
        private string AESKeyFilename;
        private string decryptMessageFilename;
        private string decryptRSAPrivateKeyFilename;

        private string signMessageFilename;
        private string signRSAPublicKeyFilename;
        private string signRSAPrivateKeyFilename;
        private string verifyMessageFilename;
        private string verifySignmentFilename;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRandomAES.Checked == true)
            {
                buttonAESKey.Enabled = false;
            }
            else
            {
                buttonAESKey.Enabled = true; 
            }
        }

        

        private void buttonMessageRSA_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Сообщение для зашифрования";
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл

            string filename = openFileDialog.FileName;
            encryptMessageFilename = filename;
            
            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelMessageEncrypt.Text = filename;
        }


        private void buttonRSAKey_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Открытый ключ";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл

            string filename = openFileDialog.FileName;
            encryptRSAPublicKeyFilename = filename;

            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelRSAOpenKey.Text = filename;
        }

        private void buttonAESKey_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Ключ AES";
            openFileDialog.Filter = "Файлы ключей (*.key)|*.key";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл

            string filename = openFileDialog.FileName;
            AESKeyFilename = filename;

            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelAESKey.Text = filename;
        }


        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Зашифрованный файл";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string encryptedFilename = saveFileDialog.FileName;

            if (checkBoxRandomAES.Checked)
            {
                byte[] AESKey = new byte[32];
                Random rand = new Random();
                rand.NextBytes(AESKey);
                File.WriteAllBytes("aes.key.temp", AESKey);
                AESKeyFilename = "aes.key.temp";
            }


            byte[] encryptedBytes = envelope.EncryptFile(
                encryptRSAPublicKeyFilename, AESKeyFilename, encryptMessageFilename);
            File.WriteAllBytes(encryptedFilename, encryptedBytes);

            if (checkBoxRandomAES.Checked)
            {
                File.Delete("aes.key.temp");
            }
        }

        private void buttonMessageDecrypt_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Файл для расшифрования";
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            decryptMessageFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelMessageDecrypt.Text = filename;
        }

        private void buttonRSAPrivateKey_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Закрытый ключ";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            decryptRSAPrivateKeyFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelRSAPrivateKey.Text = filename;
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Расшифрованный файл";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string decryptedFilename = saveFileDialog.FileName;

            byte[] decryptedBytes = envelope.DecryptFile(decryptRSAPrivateKeyFilename, decryptMessageFilename);
            File.WriteAllBytes(decryptedFilename, decryptedBytes);
        }

        private void buttonMessageSign_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Файл для подписи";
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            signMessageFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelMessageSign.Text = filename;
        }

        private void buttonRSAPublicKeySign_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Открытый ключ для создания подписи";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            signRSAPublicKeyFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelPublicKeySign.Text = filename;
        }

        private void buttonRSAPrivateKeySign_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Закрытый ключ для создания подписи";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            signRSAPrivateKeyFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelRSAPrivateKeySign.Text = filename;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Файл подписи";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string signmentFilename = saveFileDialog.FileName;

            envelope.Sign(signRSAPublicKeyFilename, signRSAPrivateKeyFilename, signMessageFilename, signmentFilename);
        }

        private void buttonMessageVerify_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Файл сообщения для проверки подписи";
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            verifyMessageFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelMessageVerify.Text = filename;
        }

        private void buttonSignmentVerify_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Файл подписи для проверки";
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            verifySignmentFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelSignmentVerify.Text = filename;
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            bool result = envelope.Verify(verifyMessageFilename, verifySignmentFilename);
            string text = result ? "Подпись верна!" : "ОШИБКА! Подпись не подходит!";
            string caption = "Проверка подписи";
            MessageBox.Show(text, caption);
        }

        private void создатьКлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyGeneratorForm form = new KeyGeneratorForm();
            form.Show();
        }

        private void ключиСОбщимМодулемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralNForm form = new();
            form.Show();
        }

        private void атакаВинераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WienerForm form = new();
            form.Show();
        }

        private void малыйОбщийПоказательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralEForm form = new();
            form.Show();
        }
    }
}