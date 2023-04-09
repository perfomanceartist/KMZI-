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
            string[] keys = new string[flowLayoutPanel.Controls.Count];
            string[] messages = new string[flowLayoutPanel.Controls.Count];

            for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
            {
                CommonEPanel panel = (CommonEPanel)flowLayoutPanel.Controls[i];
                keys[i] = panel.keyFilename;
                messages[i] = panel.cipherTextFilename;
            }


            bool result = true;


            if (result)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Атака успешна! Сохранить дешифрованное сообщение?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes) { }
                else { }
            }

        }
    }
}
