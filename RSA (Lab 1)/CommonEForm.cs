using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA__Lab_1_
{
    public partial class CommonEForm : Form
    {
        public CommonEForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CommonEPanel commonEPanel = new CommonEPanel(flowLayoutPanel.Controls.Count + 1);
            flowLayoutPanel.Controls.Add(commonEPanel);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            /* string[] keys = new string[flowLayoutPanel.Controls.Count];
             string[] messages = new string[flowLayoutPanel.Controls.Count];*/

            List<string> keys = new List<string>();
            List<string> messages = new List<string>();

            for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
            {
                CommonEPanel panel = (CommonEPanel)flowLayoutPanel.Controls[i];
                keys.Add(panel.keyFilename);
                messages.Add(panel.cipherTextFilename);
            }


            saveFileDialog.Title = "Дешифрованное сообщение";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string path = saveFileDialog.FileName;


            bool result = CryptographyLib.RSA.CommonEAttack(keys, messages, path);

            if (result)
            {
                MessageBox.Show("Атака прошла удачно!", "Бесключевое дешифрование с общим открытым показателем");
            }
            else
            {
                MessageBox.Show("Атака завершилась неудачей.", "Бесключевое дешифрование с общим открытым показателем");
            }


            /*if (result)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Атака успешна! Сохранить дешифрованное сообщение?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes) { }
                else { }
            }*/

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
