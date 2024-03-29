using CryptographyLib;
using System;
using System.Formats.Asn1;
using System.IO;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Windows.Forms;

namespace RSA__Lab_1_
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            
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

        private string signGOSTMessageFilename;
        private string signGOSTSignFilename;
        private string verifyGOSTMessageFilename;
        private string verifyGOSTSignFilename;
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
            openFileDialog.Title = "��������� ��� ������������";
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // �������� ��������� ����

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
            openFileDialog.Title = "�������� ����";
            openFileDialog.Filter = "����� ������ (*.pam)|*.pam";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // �������� ��������� ����

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
            openFileDialog.Title = "���� AES";
            openFileDialog.Filter = "����� ������ (*.key)|*.key";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // �������� ��������� ����

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
            saveFileDialog.Title = "������������� ����";
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


            byte[] encryptedBytes = CryptographyLib.RSA.EncryptFile(
                encryptRSAPublicKeyFilename, AESKeyFilename, encryptMessageFilename);
            File.WriteAllBytes(encryptedFilename, encryptedBytes);

            if (checkBoxRandomAES.Checked)
            {
                File.Delete("aes.key.temp");
            }
        }

        private void buttonMessageDecrypt_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "���� ��� �������������";
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
            openFileDialog.Title = "�������� ����";
            openFileDialog.Filter = "����� ������ (*.pam)|*.pam";
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
            saveFileDialog.Title = "�������������� ����";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string decryptedFilename = saveFileDialog.FileName;

            byte[] decryptedBytes = CryptographyLib.RSA.DecryptFile(decryptRSAPrivateKeyFilename, decryptMessageFilename);
            File.WriteAllBytes(decryptedFilename, decryptedBytes);
        }

        private void buttonMessageSign_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "���� ��� �������";
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
            openFileDialog.Title = "�������� ���� ��� �������� �������";
            openFileDialog.Filter = "����� ������ (*.pam)|*.pam";
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
            openFileDialog.Title = "�������� ���� ��� �������� �������";
            openFileDialog.Filter = "����� ������ (*.pam)|*.pam";
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
            saveFileDialog.Title = "���� �������";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string signmentFilename = saveFileDialog.FileName;

            CryptographyLib.RSA.RSASign(signRSAPublicKeyFilename, signRSAPrivateKeyFilename, signMessageFilename, signmentFilename);
        }

        private void buttonMessageVerify_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "���� ��������� ��� �������� �������";
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
            openFileDialog.Title = "���� ������� ��� ��������";
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
            bool result = CryptographyLib.RSA.RSAVerify(verifyMessageFilename, verifySignmentFilename);
            string text = result ? "������� �����!" : "������! ������� �� ��������!";
            string caption = "�������� �������";
            MessageBox.Show(text, caption);
        }

        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyGeneratorForm form = new KeyGeneratorForm();
            form.Show();
        }

        private void ������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonNForm form = new();
            form.Show();
        }

        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WienerForm form = new();
            form.Show();
        }

        private void ��������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonEForm form = new();
            form.Show();
        }

        private void buttonGOSTMsg_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "���� ��������� ��� �������� �������";
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            verifyGOSTMessageFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelGOSTMessage.Text = filename;
        }

        private void buttonGOSTSignFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "���� �������";
            openFileDialog.Filter = "����� ������� (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            verifyGOSTSignFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelGOSTSign.Text = filename;
        }

        private void buttonGOSTVerify_Click(object sender, EventArgs e)
        {
            GOST gost = new GOST();
            bool result = gost.Verify(verifyGOSTMessageFilename, verifyGOSTSignFilename);

            if (result)
            {
                MessageBox.Show("������� �����!", "�������� ������� ����");
            }
            else
            {
                MessageBox.Show("������! ������� �� �����.", "�������� ������� ����");
            }
        }

       


        private void buttonGOSTSign_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "���� �������";
            saveFileDialog.Filter = "����� ������� (*.bin)|*.bin";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;

            string A, B, p, xP, yP, q;
            string d;

            A = textBoxGOSTA.Text;
            B = textBoxGOSTB.Text;
            p = textBoxGOSTP.Text;
            xP = textBoxGOSTxP.Text;
            yP = textBoxGOSTyP.Text;
            q = textBoxGOSTQ.Text;

            d = textBoxGOSTD.Text;

            GOST gost = new GOST(A, B, p, xP, yP, q);
            gost.Sign(d, signGOSTMessageFilename, filename);

            MessageBox.Show("������� ������!", "������� ����");
        }

        private void buttonGOSTSignMsg_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "���� ��������� ��� ������������ �������";
            openFileDialog.Filter = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            signGOSTMessageFilename = filename;


            filename = Path.GetFileName(filename);
            if (filename.Length > 20)
            {
                filename = filename.Substring(0, 20);
                filename += "...";
            }
            labelGOSTSignFilename.Text = filename;
        }
    }
}