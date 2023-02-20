using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Massey_Omura_Client
{
    public partial class MainForm : Form
    {
        private string filename;

        public MainForm()
        {
            InitializeComponent();            
        }


        private void radioButtonMessage_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
        }

        private void radioButtonFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFile.Checked)
            {
                richTextBox1.Visible = false;
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                filename = openFileDialog.FileName;
            }            
        }

        private async void checkBoxListen_CheckedChanged(object sender, EventArgs e)
        {
            string IP = textBoxInboxIP.Text;
            string Port = textBoxInboxPort.Text;


            Server server = new Server(IP, Convert.ToInt32(Port));
            while (checkBoxListen.Checked)
            {
                Message m = await Task.Run(() => server.Listen());
                flowLayoutPanel.Controls.Add(new MessagePanel(m));
                Debug.WriteLine("1 message received");
            }

            /*Server server = new Server(IP, Port);
            server.StartListening();
            Debug.WriteLine("Start listening...");

            while (checkBoxListen.Checked)
            {
                Message m = await Task.Run(() => server.GetMessage());
                flowLayoutPanel.Controls.Add(new MessagePanel(m));
                Debug.WriteLine("1 message received");
            }*/


        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            
            string IP = textBoxNewIP.Text;
            string Port = textBoxNewPort.Text;
            Client client = new Client(IP, Convert.ToInt32(Port));
            if (radioButtonFile.Checked)
            {
                if (filename == "")
                {
                    MessageBox.Show("Выберите файл!");
                    return;
                }
                byte[] data = File.ReadAllBytes(filename);
                client.Send(data);
            }
            else if (radioButtonMessage.Checked)
            {
                string dataString = richTextBox1.Text;
                client.Send(dataString);
            }

            /*Client client = new Client(IP, Port);
            if(!client.Connect())
            {
                MessageBox.Show("Невозможно подключиться", "Massey-Omura");
                return;
            }

            if (!client.Send(Encoding.UTF8.GetBytes(dataString)))
            {
                MessageBox.Show("Невозможно отправить сообщение", "Massey-Omura");
                return;
            }*/

            /*if(!client.Disconnect())
            {
                MessageBox.Show("Невозможно отключиться", "Massey-Omura");
                return;
            }*/
        }
    }
}