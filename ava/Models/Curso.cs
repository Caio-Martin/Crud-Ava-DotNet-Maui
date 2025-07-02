using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ava.Models
{
    public class Curso
    {
        [PrimaryKey, AutoIncrement]
        public int CurId { get; set; }

        public string CurNome { get; set; }

        public string CurSigla { get; set; }

        public string CurDescricao { get; set; }

        public string FormatoCompleto => $"[{CurId}] {CurSigla} - {CurNome}";

        public string CurCargaHoraria { get; set; }

        public string CurNivel { get; set; }

        public string CurPeriodo { get; set; }
    }
}

