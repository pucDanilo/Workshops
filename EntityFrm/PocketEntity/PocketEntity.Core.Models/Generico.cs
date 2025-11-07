using System.Collections.Generic;

namespace pocket_angular.Models
{
    public class Foobar
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }

    public class Generico
    {
        public List<Foobar> Filtros { get; set; }
        public string[] Colunas { get; set; }
        public List<string[]> Dados { get; set; }
    }
}