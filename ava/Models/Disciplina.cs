using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ava.Models
{
    public class Disciplina
    {
        [PrimaryKey, AutoIncrement]
        public int DisId { get; set; }

        public int DisCursoId { get; set; }

        public string? DisNome { get; set; }

        public string? DisSigla { get; set; }

        public string? DisObservacoes { get; set; }

        [Ignore]
        public string CodigoNome => $"[{DisId}] {DisNome}";
    }
}
