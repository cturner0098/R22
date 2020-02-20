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
        private bool connected = false;

        TcpClient tcpClient = new TcpClient();
        NetworkStream nwStream;
        StreamReader streamReader;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine("test");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendData(txtSend.Text);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(txtIP.Text);
                IPEndPoint endPoint = new IPEndPoint(ip, Convert.ToInt32(nudPort.Value));

                tcpClient.Connect(endPoint);
                nwStream = tcpClient.GetStream();
                streamReader = new StreamReader(nwStream);
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
                List<String> scripts = new List<String>();
                try
                {
                    SendData("get_scripts()");
                    while (true)
                    {
                        var line = streamReader.ReadLine();
                        Console.WriteLine(line);
                    }
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

            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        }
    }
}
