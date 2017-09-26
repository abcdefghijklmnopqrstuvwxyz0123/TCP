using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

/*
 *  src:https://www.codeproject.com/Articles/1415/Introduction-to-TCP-client-server-in-C 
 *  
 *  [NOTE] Code serves immediate need for server-side TCP; look into below alternatives.
 *  
 *  alt:https://developer.mozilla.org/en-US/docs/Web/API/WebSockets_API/Writing_WebSocket_server - better?
 *  alt2:https://www.codeproject.com/Articles/155282/TCP-Server-Client-Communication-Implementation - more promising..
 */
public class Server
{
    public static void Main()
    {
        try
        {
            Int32 port;

            TcpListener Listenr = new TcpListener(IPAddress.Parse("142.232.18.102"), port = 8001);

            Listenr.Start();

            Console.WriteLine("The server is running at port " + port + "...");
            Console.WriteLine("The local End point is  :" + Listenr.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");

            Socket s = Listenr.AcceptSocket();
            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

            byte[] b = new byte[100];
            Console.WriteLine("Recieved...");

            for (int i = 0; i < s.Receive(b); i++) Console.Write(Convert.ToChar(b[i]));

            s.Send(new ASCIIEncoding().GetBytes("The string was recieved by the server."));

            Console.WriteLine("\nSent Acknowledgement");

            /* clean up */
            s.Close();
            Listenr.Stop();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
    }
}