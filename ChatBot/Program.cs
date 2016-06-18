using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatBot {
    class Program {

        /*
        A parte dos comandos retorna algo muito grande para o console e ele precisa enviar a mesma mensagem diversar vezes
            
            */

        static void Main(string[] args) {
            

            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 1994));
            sck.Listen(0);
            Socket acc = sck.Accept();

            while (true) {
                

                
                Comandos comandos = new Comandos();



                byte[] buffer = new byte[16000];

                int rec = acc.Receive(buffer, 0, buffer.Length, 0);
                Array.Resize(ref buffer, rec);
                string msgRec = Encoding.Default.GetString(buffer);
                Console.WriteLine("Received: {0}", msgRec);
                buffer = new byte[16000];
                buffer = Encoding.Default.GetBytes(comandos.executarComando(msgRec));

                acc.Send(buffer, 0, buffer.Length, 0);


                //acc.Close();
                //sck.Close();

            }
            
           
        }
    }
}
