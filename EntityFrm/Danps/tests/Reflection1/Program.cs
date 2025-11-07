using SMC.PraticasCurriculares.Domain.Areas.CNV.Models;
using System;
using System.Collections.Generic;

namespace Reflection1
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var tipo = typeof(TipoConvenio);
            System.IO.Directory.CreateDirectory(SERVICES.AREAS.CNV_I_SERVICES_DIR);
            var service = SERVICES.AREAS.SERVICE.Replace("#OBJETO#", tipo.Name).Replace("#AREA#", SERVICES.AREAS.CNV);
            System.IO.File.WriteAllText(SERVICES.AREAS.FILE_SERVICE(tipo.Name), service); ;
             
            foreach (var propertyInfo in tipo.GetProperties())
            {
                Console.WriteLine(propertyInfo.Name);
            }
            Console.WriteLine("Hello World!");
        }
    }

    public class SERVICES
    {
        public class AREAS
        {
            public static string SERVICES_DIR = @"D:\SMC\Dev\PraticasCurriculares\SMC.PraticasCurriculares.Service\Areas";
            public static string I_SERVICES_DIR = @"D:\SMC\Dev\PraticasCurriculares\SMC.PraticasCurriculares.ServiceContract\Areas\":
            public static string CNV = "CNV";
            public static string CNV_SERVICES_DIR => $"{SERVICES_DIR}\\{CNV}\\Services";
            public static string CNV_I_SERVICES_DIR => $"{I_SERVICES_DIR}\\{CNV}\\Interfaces";
            public static string FILE_SERVICE(string value) => $"{CNV_I_SERVICES_DIR}\\{value}Service.cs";
            public static string I_SERVICE = @"using SMC.Framework.Model;
using SMC.Framework.Service;
using SMC.PraticasCurriculares.ServiceContract.Areas.#AREA#.Data;
using System.Collections.Generic;

namespace SMC.PraticasCurriculares.ServiceContract.Areas.#AREA#.Interfaces
{
    public interface I#OBJETO#Service : ISMCService
    {
        long Salvar#OBJETO#(#OBJETO#Data modelo);

        #OBJETO#Data Buscar#OBJETO#(long seq); 
        
        SMCPagerData<#OBJETO#Data> Buscar#OBJETO#s(#OBJETO#FiltroData filtros);
    }
}";
            public static string SERVICE = @"using SMC.Formularios.ServiceContract.Areas.FRM.Interfaces;
using SMC.Framework.Extensions;
using SMC.Framework.Model;
using SMC.Framework.Service;
using SMC.PraticasCurriculares.Domain.Areas.#AREA#.DomainServices;
using SMC.PraticasCurriculares.Domain.Areas.#AREA#.ValueObjects;
using SMC.PraticasCurriculares.ServiceContract.Areas.#AREA#.Data;
using SMC.PraticasCurriculares.ServiceContract.Areas.#AREA#.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SMC.PraticasCurriculares.Service.Areas.#AREA#.Services
{
    public class #OBJETO#Service : SMCServiceBase, I#OBJETO#Service
    {
        private #OBJETO#DomainService #OBJETO#DomainService => this.Create<#OBJETO#DomainService>();

        public #OBJETO#Data Buscar#OBJETO#(long seq)
        {
            return #OBJETO#DomainService.Buscar#OBJETO#((int)seq).Transform<#OBJETO#Data>();
        }

        public SMCPagerData<#OBJETO#Data> Buscar#OBJETO#s(#OBJETO#FiltroData filtros)
        {
            var obj = #OBJETO#DomainService.Buscar#OBJETO#s(filtros.Transform<#OBJETO#FiltroVO>());
            return obj.Transform<SMCPagerData<#OBJETO#Data>>();
        }

        public long Salvar#OBJETO#(#OBJETO#Data modelo)
        {
            var obj = modelo.Transform<#OBJETO#VO>();
            return #OBJETO#DomainService.Salvar#OBJETO#(obj);
        }
    }
}
";
        }
    }

}