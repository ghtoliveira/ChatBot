using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client {
    class Program {
        static void Main(string[] args) {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994);
            sck.Connect(endPoint);

            while (true) {

                Console.WriteLine("Digite sua mensagem:\n");
                string msg = Console.ReadLine();
                byte[] msgBuffer = Encoding.Default.GetBytes(msg);
                sck.Send(msgBuffer, 0, msgBuffer.Length, 0);

                byte[] buffer = new byte[16000];

                int rec = sck.Receive(buffer, 0, buffer.Length, 0);

                Array.Resize(ref buffer, rec);

                
                string retorno =
                "Comandos disponíveis: \n" +
                "creditos - Irá retornar ao usuário uma lista contendo as informações de quem desenvolveu a aplicação \n" +
                "comandos - Retornará uma lista que contém todos os comandos da aplicação \n" +
                "piada - A aplicação consultará uma lista de piadás e irá contar uma selecionada aleatoriamente da lista \n" +
                "jogonumero - Irá começar a seção de um jogo de adivinhação aonde o servidor tentará adivinhar o número que o jogador está pensando entre 0 e 1000.\n" +
                "jogonumeromaior - Utilizado após o jogo começar para informar ao servidor que o número é maior do que o adivinhado pelo servidor.\n" +
                "jogonumeromenor - Utilizado após o jogo começar para informar ao servidor que o número é menor do que o adivinhado pelo servidor.\n" +
                "jogonumerocerto - Informa ao servidor que ele acertou o número\n" +
                "jogonumerocancelar - Cancela a seção do jogo.";
                //Console.WriteLine(retorno);
                Console.WriteLine(Encoding.Default.GetString(buffer));
            }
            
            
            
            //Console.Read();
            

        }
    }
}
