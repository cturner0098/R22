using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        TcpClient tcpClient = new TcpClient();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            IPAddress ip = IPAddress.Parse("10.230.209.87");
            IPEndPoint endPoint = new IPEndPoint(ip, 8080);

            tcpClient.Connect(endPoint);

            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream nwStream = tcpClient.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(txtSend.Text);

            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        }
    }
}
