using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ava.Models
{
    public class Periodo
    {
        [PrimaryKey, AutoIncrement]
        public int PerId { get; set; }

        public string? PerNome { get; set; }

        public string? PerSigla { get; set; }

        public string? PerObservacoes { get; set; }

        [Ignore]
        public string CodigoNome => $"[{PerId}] {PerNome}";
    }
}
