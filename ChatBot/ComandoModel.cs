using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot {
    /// <summary>
    /// Utilizada para abstrair os comandos, contém o comando em sí (/algo) e o que ele deve retornar
    /// </summary>
    class ComandoModel {
        public string Comando { get; set; }
        public string Retorno { get; set; }
    }
}
