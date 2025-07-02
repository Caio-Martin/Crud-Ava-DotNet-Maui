using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ava.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int UsuId { get; set; }

        public string? UsuNome { get; set; }

        public string? UsuSenha { get; set; }

        [Ignore]
        public string Exibicao => $"[{UsuId}] {UsuNome}";
    }
}
