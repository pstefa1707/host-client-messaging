using System;
using System.IO;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;  
using System.Threading; 

class Program
{
    static void Main(string[] args)
    {
        MyWebServer server = new MyWebServer();
    }
}
class MyWebServer  
{  
    private TcpListener myListener;  
    private int port = 25565; 
    public MyWebServer()  
    {  
        try  
        {  
            //start listing on the given port
            IPAddress serverAddr = IPAddress.Parse("192.168.0.15");  
            myListener = new TcpListener(serverAddr, port);  
            myListener.Start();  
            Console.WriteLine("Host started on IP:PORT - {0} at {1}", serverAddr.ToString() + ":" + port.ToString(), DateTime.Now);  
            //start the thread which calls the method 'StartListen'  
            Thread th = new Thread(new ThreadStart(startListen));  
            th.Start();  
        }  
        catch (Exception e)  
        {  
            Console.WriteLine("An Exception Occurred ywhile Listening :" + e.ToString());  
        }   
    }  
    void startListen() {
        Socket newSocket = myListener.AcceptSocket();
        Console.WriteLine("\nNew Client Connected! IP: {0}", newSocket.LocalEndPoint);
        if (newSocket.Connected)
        {
            while(true) {
                Byte[] bReceive = new Byte[1024];
                newSocket.Receive(bReceive, bReceive.Length, 0);
                String recievedStr = Encoding.ASCII.GetString(bReceive);
                Console.WriteLine("\nMessage recieved: {0}", recievedStr);
                Console.Write("\nMessage to reply: ");
                Byte[] sBuffer = new Byte[1024];
                sBuffer = Encoding.ASCII.GetBytes(Console.ReadLine());
                newSocket.Send(sBuffer);
            }
        }
    }
}  
