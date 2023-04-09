using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA__Lab_1_
{
    public partial class WienerForm : Form
    {

        
        public WienerForm()
        {
            InitializeComponent();
            
        }

        private void buttonGetFromFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Открытый ключ";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string openKeyfilename = openFileDialog.FileName;
            CryptographyLib.RSAPublicKey key = CryptographyLib.RSAPublicKey.ReadFromFile(openKeyfilename);
            textBoxWienerN.Text = key.N.ToString();
            textBoxWienerE.Text = key.E.ToString();

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            BigInteger N = BigInteger.Parse(textBoxWienerN.Text);
            BigInteger E = BigInteger.Parse(textBoxWienerE.Text);
            CryptographyLib.RSAPublicKey key = new CryptographyLib.RSAPublicKey(E, N);
            CryptographyLib.RSAPrivateKey privKey;

            Cursor.Current = Cursors.AppStarting;
            bool result = CryptographyLib.RSA.WienerAttack(key, out privKey);
            Cursor.Current = Cursors.Default;
            if (result)
            {
                MessageBox.Show("Атака прошла удачно!", "Атака Винера");
                textBoxWienerD.Text = privKey.D.ToString();
                buttonSave.Enabled = true;
            }
            else
            {
                buttonSave.Enabled = false;
                MessageBox.Show("Атака прошла не удачно... Попробуйте ещё раз.", "Атака Винера");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Закрытый ключ";
            saveFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string path = saveFileDialog.FileName;

            CryptographyLib.RSA.ExportPrivateKey(path, textBoxWienerN.Text, textBoxWienerD.Text);
        }
    }
}
