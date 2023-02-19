using Massey_Omura_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Message = Massey_Omura_Lib.Message;

namespace Massey_Omura_Client
{
    internal class MessagePanel : Panel
    {
        SaveFileDialog saveFileDialog;
        byte[] data;
        string date;
        string IP;
        public MessagePanel(Message message) : this(message.date, message.ip, message.data)
        {
            
        }

        public MessagePanel (string date, string IP, byte[] data)
        {
            this.Height = 75;
            this.Width = 230;
            this.BorderStyle = BorderStyle.FixedSingle;

            saveFileDialog = new SaveFileDialog();

            this.data = data;
            this.date = date;
            this.IP = IP;

            Label labelDate = new Label ();
            labelDate.Location = new Point(13, 14);
            labelDate.AutoSize = true;
            labelDate.Text = date;

            Label labelIP = new Label ();
            labelIP.Location = new Point(13, 40);
            labelIP.Text = IP;

            Button saveButton = new Button();
            saveButton.Location = new Point(132, 10);
            saveButton.Text = "Сохранить";
            saveButton.Click += saveButtonClick;

            this.Controls.Add(labelDate);
            this.Controls.Add(labelIP);
            this.Controls.Add(saveButton);
        }
        
        public void saveButtonClick(object sender, EventArgs e)
        {
            saveFileDialog.FileName = (date + "_" + IP).Replace(':', '_');
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            File.WriteAllBytes(filename, data);

        }
    }
}
