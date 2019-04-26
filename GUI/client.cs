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
    public partial class client : Form
    {
        private string ip;
        private int port;
        private string username;
        public string mostRecentMsg;
        public client(string ip, int port, string username)
        {
            this.ip = ip;
            this.port = port;
            this.username = username;
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            Updater.RunWorkerAsync();
        }
        void updateLabel(string output)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => updated.Text = output));
                return;
            }

            this.updated.Text += output;
        }
        void log(string output)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => textChat.Text = String.Concat(textChat.Text, Environment.NewLine, output)));
                return;
            }

            this.textChat.Text += "\n" + output + "\n";
        }
        private void Updater_DoWork(object sender, DoWorkEventArgs e)
        {
            int nextSecond = DateTime.Now.Second;
            log("made it 1: " + nextSecond);
            while (true)
            {
                if (DateTime.Now.Second == nextSecond)
                {
                    log("made it 2: " + nextSecond);
                    try
                    {
                        TcpClient tcpClient = new TcpClient(this.ip, this.port);
                        String payload = "GET messeges";
                        Byte[] buffer = System.Text.Encoding.ASCII.GetBytes(payload);
                        NetworkStream stream = tcpClient.GetStream();

                        stream.Write(buffer, 0, buffer.Length);
                        Byte[] rBuffer = new Byte[10024];
                        String responseData = String.Empty;
                        Int32 bytes = stream.Read(rBuffer, 0, rBuffer.Length);
                        responseData = Encoding.ASCII.GetString(rBuffer, 0, bytes);
                        updated.ForeColor = Color.Green;
                        updateLabel("Updated: " + DateTime.Now.TimeOfDay);
                        if (responseData != mostRecentMsg)
                        {
                            log(responseData);
                            mostRecentMsg = responseData;
                        }
                        
                        

                    }
                    catch (ArgumentNullException except)
                    {
                        updated.ForeColor = Color.Red;
                        updateLabel("Null!");
                    }
                    catch (SocketException except)
                    {
                        updated.ForeColor = Color.Red;
                        updateLabel("Error connecting to server!");
                    }
                    nextSecond = DateTime.Now.Second + 1;
                }
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient tcpClient = new TcpClient(this.ip, this.port);
                String payload = DateTime.UtcNow.ToShortTimeString() + " " + username + ": " + sendText.Text;
                Byte[] buffer = System.Text.Encoding.ASCII.GetBytes(payload);
                NetworkStream stream = tcpClient.GetStream();
                stream.Write(buffer, 0, buffer.Length);

                updated.ForeColor = Color.Blue;
                updateLabel("Sent Message!");

            }
            catch (ArgumentNullException except)
            {
                Console.WriteLine("ArgumentNullException: {0}", except);
            }
            catch (SocketException except)
            {
                updated.ForeColor = Color.Red;
                updateLabel("Error connecting to server!");
            }
        }
    }
}
