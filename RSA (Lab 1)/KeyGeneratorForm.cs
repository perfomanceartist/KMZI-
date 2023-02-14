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
            if (keySize < 384 || keySize > 16384)
            {
                MessageBox.Show("Длина ключа может быть от 384 до 16384 бит!");
                return;
            }

            string N, P, Q, E, D;
            CryptoEnvelope envelope = new CryptoEnvelope();

            if (checkBoxFixN.Checked)
            {
                N = textBoxN.Text; // Всегда подходящее число, т.к. нельзя ввести вручную
                P = textBoxP.Text;
                Q = textBoxQ.Text;
                envelope.GenerateRSAKeys(P, Q, out E, out D);
                textBoxE.Text = E;
                textBoxD.Text = D;
            }
            else {
                envelope.GenerateRSAKeys(keySize, out N, out P, out Q, out E, out D);
                textBoxN.Text = N;
                textBoxP.Text = P;
                textBoxQ.Text = Q;
                textBoxE.Text = E;
                textBoxD.Text = D;
            }
        }

        private void checkBoxFixN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFixN.Checked)
            {
                textBoxKeyLength.Enabled = false;
                textBoxN.Enabled = false;
            }
            else
            {
                textBoxKeyLength.Enabled = true;
                textBoxN.Enabled = true;
            }
        }

        private void buttonExportPublicKey_Click(object sender, EventArgs e)
        {
            string N = textBoxN.Text;
            string E = textBoxE.Text;
            string D = textBoxD.Text;

            saveFileDialogKey.Title = "Открытый ключ";
            if (saveFileDialogKey.ShowDialog() == DialogResult.Cancel) return;
            string path = saveFileDialogKey.FileName;
            CryptoEnvelope envelope = new CryptoEnvelope();
            envelope.ExportPublicKey(path, N, E);
        }

        private void buttonExportPrivateKey_Click(object sender, EventArgs e)
        {
            string N = textBoxN.Text;
            string E = textBoxE.Text;
            string D = textBoxD.Text;

            saveFileDialogKey.Title = "Закрытый ключ";
            if (saveFileDialogKey.ShowDialog() == DialogResult.Cancel) return;
            string path = saveFileDialogKey.FileName;
            CryptoEnvelope envelope = new CryptoEnvelope();
            envelope.ExportPrivateKey(path, N, D);
        }

        private void textBoxKeyLength_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
