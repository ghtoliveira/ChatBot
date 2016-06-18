using System;
using System.Collections.Generic;

namespace ChatBot {
    /// <summary>
    /// Classe que contém os comandos que podem ser utilizados pelo usuário na aplicação cliente
    /// </summary>

    //TODO: Remover a propriedade comando das classes
    static class NomeComandos {
        public const string COMANDO_PIADA = "/piada";
        public const string COMANDO_CREDITOS = "/creditos";
        public const string COMANDO_COMANDOS = "/comandos";
    }


    class Comandos {
        
        public string executarComando(string comando) {
            switch (comando) {
                case NomeComandos.COMANDO_PIADA:
                    ComandoPiada cp = new ComandoPiada();
                    return cp.retornar();
                case NomeComandos.COMANDO_COMANDOS:
                    ComandoComandos cc = new ComandoComandos();
                    return cc.retornar();
                case NomeComandos.COMANDO_CREDITOS:
                    ComandoCreditos ccr = new ComandoCreditos();
                    return ccr.retornar();
                default:
                    ComandoErrado ce = new ComandoErrado();
                    return ce.retornar();
            }
        }


    }

    class ComandoErrado {
        public string retorno { get; }
        private List<string> frases;

        public ComandoErrado() {
            frases = new List<string>();
            string frase;
            frase = "Você informou um comando inválido, tente novamente.";
            frases.Add(frase);
        }

        public string retornar() {
            Random random = new Random();
            int pos = random.Next(frases.Count);
            return frases[pos];
        }

    }

    class ComandoCreditos {
        public string comando { get; }
        public string retorno { get; }

        public ComandoCreditos() {
            comando = NomeComandos.COMANDO_CREDITOS;
            retorno = "Aplicação criada por Guilherme Oliveira e Renan Fengler em 06/2016 para a cadeira de Redes de Computadores, Universidade de Santa Cruz do Sul";
        }

        public string retornar() {
            return retorno;
        }
    }

    class ComandoComandos{
        public string comando { get; }
        public string retorno { get; }

        public ComandoComandos() {
            comando = NomeComandos.COMANDO_COMANDOS;
            retorno = 
                "Comandos disponíveis: \n" +
                "creditos - Irá retornar ao usuário uma lista contendo as informações de quem desenvolveu a aplicação \n" +
                "comandos - Retornará uma lista que contém todos os comandos da aplicação \n" +
                "piada - A aplicação consultará uma lista de piadás e irá contar uma selecionada aleatoriamente da lista \n" +
                "jogonumero - Irá começar a seção de um jogo de adivinhação aonde o servidor tentará adivinhar o número que o jogador está pensando entre 0 e 1000.\n" +
                "jogonumeromaior - Utilizado após o jogo começar para informar ao servidor que o número é maior do que o adivinhado pelo servidor.\n" +
                "jogonumeromenor - Utilizado após o jogo começar para informar ao servidor que o número é menor do que o adivinhado pelo servidor.\n" +
                "jogonumerocerto - Informa ao servidor que ele acertou o número\n" +
                "jogonumerocancelar - Cancela a seção do jogo." ;
        }

        public string retornar() {
            return retorno;
        }
    }

    class ComandoPiada {
        public string comando { get; }
        public string retorno { get; }


        private List<string> piadas;

        public ComandoPiada() {
            comando = comando = NomeComandos.COMANDO_PIADA;
            //Popula a classe com piadas
            piadas = new List<string>();
            string piada;

            piada = "O que são 3 pontinhos verdes no canto da sala?\n Mofo.";
            piadas.Add(piada);
            piada = "O que o nadador fez para bater o recorde? \n Treinou exaustivamente, fez dietas e deixou distrações para trás.";
            piadas.Add(piada);
            piada = "Macho que é macho \n Tem cromossomos XY";
            piadas.Add(piada);
            piada = "Um irlândes saiu de um bar.";
            piadas.Add(piada);
            piada = "O que é vermelho e tem cheiro de tinta azul? \n Tinta vermelha.";
            piadas.Add(piada);
            piada = "O que um advogado falou para o outro? \n Nós dois somos advogados.";
            piadas.Add(piada);
            piada = "O que Batman falou para Robin antes deles entarem no carro?\n Entre no carro Robin.";
            piadas.Add(piada);
            piada = "O que uma águia e uma toupeira tem em comum?\n Ambas moram em baixo do solo, exceto a águia.";
            piadas.Add(piada);
        }

        public string retornar() {
            Random random = new Random();
            int pos = random.Next(piadas.Count);
            return piadas[pos];
        }
    }


}
