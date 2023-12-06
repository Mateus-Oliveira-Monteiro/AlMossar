using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
     class Reserva
    {
        string nome;
        string sobrenome;
        int quantidadePessoas;
        int idMesa;

        public string Nome { get => nome; set => nome = value; }
        public string Sobrenome { get => sobrenome; set => sobrenome = value; }
        public int QuantidadePessoas { get => quantidadePessoas; set => quantidadePessoas = value; }
        public int IdMesa { get => idMesa; set => idMesa = value; }
    }
}
