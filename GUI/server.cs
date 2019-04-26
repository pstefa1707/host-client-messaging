using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;

namespace messaging_app
{
    public partial class server : Form
    {
        private string ip;
        private int port;
        Boolean run = true;
        public string mostRecentMsg;
        public List<string> connectedUsers;
        public server(string ip, int port)
        {
            connectedUsers = new List<string>();
            mostRecentMsg = "Server Created!";
            this.ip = ip;
            this.port = port;
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            MyWebServer(this.ip, this.port);
        }
        public void MyWebServer(string ip, int port)
        {
            TcpListener myListener;
            try
            {
                IPAddress addr = IPAddress.Parse(ip);
                myListener = new TcpListener(addr, port);
                myListener.Start();
                log("Web Server Started Successfully...");
                //start the thread which calls the method 'StartListen'  
                Thread th = new Thread(new ThreadStart(listenForConnection));
                th.Start();
                
            }
            catch (Exception e)
            {
                log("An Exception Occurred while Listening :" + e.ToString());
            }
            void listenForConnection()
            {
                Byte[] buffer = new Byte[10024];
                String recievedData = null;
                while (run)
                {
                    Socket newSocket = myListener.AcceptSocket();
                    if (!connectedUsers.Contains(newSocket.RemoteEndPoint.ToString()))
                    {
                        log("New user connected: " + newSocket.RemoteEndPoint);
                    }
                    int k = newSocket.Receive(buffer);
                    recievedData = Encoding.ASCII.GetString(buffer, 0, k);
                    if (recievedData.ToLower() == "get messages")
                    {
                        String payload = mostRecentMsg;
                        byte[] bytes = Encoding.ASCII.GetBytes(payload);
                        newSocket.Send(bytes, 0);
                    }
                    else {
                        mostRecentMsg = recievedData;
                        log(mostRecentMsg);
                    }

                }
            }
        }
        void log(string output)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => textBox1.Text = String.Concat(textBox1.Text, Environment.NewLine, output)));
                return;
            }

            this.textBox1.Text += "\n" + output + "\n";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
