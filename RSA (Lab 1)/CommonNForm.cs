using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RSA__Lab_1_
{
    public partial class CommonNForm : Form
    {
        public CommonNForm()
        {
            InitializeComponent();
        }

        string filenamePublicA = "";
        string filenamePrivateA = "";
        string filenamePublicB = "";


        private void buttonCommonNAttack_Click(object sender, EventArgs e)
        {
            if (filenamePublicA == "" || filenamePublicB == "" || filenamePrivateA == "")
            {
                MessageBox.Show("Укажите файлы ключей");
                return;
            }

            string P, Q, D;

            bool result = CryptographyLib.RSA.CommonNAttack(filenamePublicA, filenamePrivateA, filenamePublicB, out P, out Q, out D);

            if (result == false)
            {
                MessageBox.Show("Ключи не подходят для данной атаки.");
                return;
            }

            textBoxCommonNP.Text = P;
            textBoxCommonNQ.Text = Q;
            textBoxCommonND.Text = D;
            groupBoxAttackResult.Visible = true;
        }

        private void buttonCommonNSavePrivateB_Click(object sender, EventArgs e)
        {
            string P = textBoxCommonNP.Text;
            string Q = textBoxCommonNQ.Text;
            string D = textBoxCommonND.Text;

            saveFileDialog.Title = "Закрытый ключ жертвы";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string path = saveFileDialog.FileName;
            CryptographyLib.RSA.ExportPrivateKey(path, P, Q, D);
        }

        private void buttonCommonNPublicA_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Открытый ключ А";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл

            filenamePublicA = openFileDialog.FileName;
            string filename = filenamePublicA;

            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelCommonNPublicA.Text = filename;
        }

        private void buttonCommonNPrivateA_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Закрытый ключ А";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл

            filenamePrivateA = openFileDialog.FileName;
            string filename = filenamePrivateA;

            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelCommonNPrivateA.Text = filename;
        }

        private void buttonCommonNPublicB_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Открытый ключ B (жертвы)";
            openFileDialog.Filter = "Файлы ключей (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл

            filenamePublicB = openFileDialog.FileName;
            string filename = filenamePublicB;

            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelCommonNPublicB.Text = filename;
        }
    }
}
