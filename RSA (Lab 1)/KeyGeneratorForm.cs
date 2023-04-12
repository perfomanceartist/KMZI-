using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA__Lab_1_
{
    public partial class KeyGeneratorForm : Form
    {
        public KeyGeneratorForm()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {

            int keySize = 0;
            try
            {
                keySize = Int32.Parse(textBoxKeyLength.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка в длине ключа!");
                return;
            }
            if (keySize < 1024 || keySize > 16384)
            {
                MessageBox.Show("Длина ключа может быть от 1024 до 16384 бит!");
                return;
            }

            string N, P, Q, E, D;

            if (radioButtonDefault.Checked)
            {
                CryptographyLib.RSA.GenerateRSAKeys(keySize, out N, out P, out Q, out E, out D);
                textBoxN.Text = N;
                textBoxP.Text = P;
                textBoxQ.Text = Q;
                textBoxE.Text = E;
                textBoxD.Text = D;
            }
            else if (radioButtonCommonN.Checked)
            {
                P = textBoxP.Text;
                Q = textBoxQ.Text;
                if (P == "" || Q == "")
                {
                    CryptographyLib.RSA.GenerateRSAKeys(keySize, out N, out P, out Q, out E, out D);
                    textBoxN.Text = N;
                    textBoxP.Text = P;
                    textBoxQ.Text = Q;
                    textBoxE.Text = E;
                    textBoxD.Text = D;
                }
                else
                {
                    CryptographyLib.RSA.GenerateRSAKeys(P, Q, out E, out D);
                    textBoxE.Text = E;
                    textBoxD.Text = D;
                }
            }
            else if (radioButtonCommonE.Checked)
            {                
                E = "3";
                CryptographyLib.RSA.GenerateRSAKeys(keySize, E, out N, out P, out Q, out D);
                textBoxN.Text = N;
                textBoxP.Text = P;
                textBoxQ.Text = Q;
                textBoxE.Text = E;
                textBoxD.Text = D;
            }
            if (radioButtonWiener.Checked)
            {
                CryptographyLib.RSA.GenerateRSAKeys(keySize, out N, out P, out Q, out E, out D, false);
                textBoxN.Text = N;
                textBoxP.Text = P;
                textBoxQ.Text = Q;
                textBoxE.Text = E;
                textBoxD.Text = D;
            }



        }

        private void checkBoxFixN_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonExportPublicKey_Click(object sender, EventArgs e)
        {
            string N = textBoxN.Text;
            string E = textBoxE.Text;
            string D = textBoxD.Text;

            saveFileDialogKey.Title = "Открытый ключ";
            saveFileDialogKey.Filter = "Файлы ключей (*.pam)|*.pam";
            if (saveFileDialogKey.ShowDialog() == DialogResult.Cancel) return;
            string path = saveFileDialogKey.FileName;

            CryptographyLib.RSA.ExportPublicKey(path, N, E);
        }

        private void buttonExportPrivateKey_Click(object sender, EventArgs e)
        {
            string N = textBoxN.Text;
            string E = textBoxE.Text;
            string D = textBoxD.Text;

            saveFileDialogKey.Title = "Закрытый ключ";
            saveFileDialogKey.Filter = "Файлы ключей (*.pam)|*.pam";
            if (saveFileDialogKey.ShowDialog() == DialogResult.Cancel) return;
            string path = saveFileDialogKey.FileName;

            CryptographyLib.RSA.ExportPrivateKey(path, N, D);
        }

        private void textBoxKeyLength_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
