using System;
using System.Collections.Generic;
using System.Text;

namespace Cervo.Models
{
    public class DtoFirmaDigitale
    {
        public string Oggetto { get; set; }
        public string EmessoDa { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }
        public string Algoritmo { get; set; }
        public string Seriale { get; set; }

    }
}
