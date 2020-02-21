using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R22
{
    public partial class frmMain : Form
    {
        NetworkStream nwStream;
        TcpClient client;
        private bool connected = false;
        byte[] bytes = new byte[1024];
        static byte[] bytesToRead;
        static int bytesRead;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(txtIP.Text, (int)nudPort.Value);
                connected = true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGetScripts_Click(object sender, EventArgs e)
        {
            if(connected)
            {
                string[] scripts;
                try
                {
                    SendData("get_scripts()");

                    nwStream = client.GetStream();

                    bytesToRead = new byte[client.ReceiveBufferSize];
                    bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                    string files = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);

                    scripts = files.Split(',');
                    foreach(string script in scripts)
                    {
                        if(script != "")
                        {
                            cmbScripts.Items.Add(script);
                        }
                        
                    }
                    Console.WriteLine("Received : " + files);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void SendData(string data)
        {
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(data);
            nwStream = client.GetStream();
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(connected)
            {
                try
                {
                    client.Close();
                    nwStream.Close();
                } catch { }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            SendData("execute");
            SendData(cmbScripts.SelectedItem.ToString());
        }
    }
}
