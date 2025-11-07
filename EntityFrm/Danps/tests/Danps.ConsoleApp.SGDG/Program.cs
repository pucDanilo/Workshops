using Danps.My.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Danps.ConsoleApp.SGDG
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using var db = new MyApplicationContext();
            //MyBancoDados.HealthCheck(db);
            var classes = db.MyClasses.Include(a => a.MyClassFields).Where(a => a.NomeTabela == "contrato").FirstOrDefault();
            //using var db2 = new ModeloContext();
            //MyBancoDados.TemplateHealthCheck(db2);
        }
    }
}