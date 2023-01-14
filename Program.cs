using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace HTTPServerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                
                using var client = new TcpClient();


                
                var hostName = txtBoxHOST.Text;
                int portValue = int.Parse(txtBoxPort.Text);

                File.WriteAllText("Target.txt", hostName);

                client.Connect(hostName, portValue);

                using NetworkStream networkStream = client.GetStream();
                networkStream.ReadTimeout = 2000;

                using var reader = new StreamReader(networkStream, Encoding.UTF8);
                byte[] bytes = Encoding.UTF8.GetBytes(string.Empty);

                networkStream.Write(bytes, 0, bytes.Length);

                

                txtBox2.Text += "Conected to " + hostName + "\r\n";

                txtBox2.Text += reader.ReadToEnd();


            }

            catch (Exception ex)
            {
                if (ex.Message == $"No connection could be made because the target machine actively refused it. [::ffff:{txtBoxHOST.Text}]:{txtBoxPort.Text}")
                {
                    txtBox2.Text += $"Access Denied! ({txtBoxHOST.Text}:{txtBoxPort.Text})\r\n";
                }
                else
                {
                    txtBox2.Text += ex.Message + "\r\n";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtBox2.Text = string.Empty;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txtBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                txtBox2.Text += "Unavailable!\r\n";
                /*btn1.Enabled = false;

                string fileName = @"Program.py";

                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(@"C:\Python311\python.exe", fileName)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                txtBox2.Text += $"{output}\r\n";

                btn1.Enabled = true;*/
            }

            catch (Exception ex)
            {
                if (btn1.Enabled == false)
                {
                    btn1.Enabled = true;
                }

                else if (btn1.Enabled == true)
                {
                    throw;
                }
            }
        }
    }
}
