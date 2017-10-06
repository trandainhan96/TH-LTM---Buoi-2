using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class Form1 : Form
    {
        Socket server;
        Socket client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //khoi tao server de lang nghe
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Cac ban truoc khi Bind phai co IPEndPoit
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 12345);
            //Sau do Bind
            server.Bind(ipep);
            // va listen , so socket toi la o day la 1
            server.Listen(10);
            client = server.Accept();
            //dua ra kich ban: sau khi connect, 

            //minh dang dong bo nen phai co client thi moi chay, phai bat dong bo thi moi chay
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(textBox2.Text);
            client.Send(data);
            listBox1.Items.Add("Server: " + textBox2.Text);
            textBox2.Text = "";
          

            //khoi tao moi data de ko bi loi
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Client:" + Encoding.ASCII.GetString(data));
            

        }
        
    }
}
