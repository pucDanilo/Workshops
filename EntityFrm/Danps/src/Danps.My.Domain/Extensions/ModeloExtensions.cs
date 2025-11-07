using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Danps.My.Domain.Models
{
    public static class ModeloExtensions
    {
        public static MyModelo Executar(this MyModelo modelo, object item)
        {
            if (modelo.Tags != null && modelo.Tags.Count > 0)
            {
                var objetosOrigem = modelo.Tags.Select(t => t.Objeto).Distinct().ToArray();
                Type tipoItem = item.GetType();
                foreach (var tag in modelo.Tags)
                {
                    SubstituirPropriedade(modelo, item, tipoItem, tag);
                }
            }
            return modelo;
        }

        private static void SubstituirPropriedade(MyModelo modelo, object item, Type tipoItem, MyTag tag)
        {
            string prop = tag.Objeto.Propriedade;
            object valor = GetValorPorCaminho(tipoItem, item, prop);
            var dsc = tag.Token;
            if (valor != null)
            {
                if (valor.GetType() == typeof(DateTime))
                    valor = ((DateTime)valor).ToString("dd/MM/yyyy");
                if (tag.ModeloSecundario != null)
                {
                    string mensagem = AtualizarModeloSecundario(tag, valor);
                    modelo.Mensagem = modelo.Mensagem.Replace(dsc, mensagem.ToString());
                }
                else
                    modelo.Mensagem = modelo.Mensagem.Replace(dsc, valor.ToString());
            }
        }

        private static string AtualizarModeloSecundario(MyTag tag, object valor)
        {
            string mensagem = string.Empty;
            var itens = (object[])valor;
            for (int i = 0; i < itens.Length; i++)
            {
                var v = itens[i];
                var clone = (MyModelo)tag.ModeloSecundario.Clone();
                clone.Executar(v);
                mensagem += $"{Environment.NewLine}{clone.Mensagem}{ (i != itens.Length - 1 ? tag.ModeloSecundario.Concatenador : string.Empty)}";
            }

            return mensagem;
        }

        #region Reflection

        public const string PONTO = ".";

        public static string SubStringNext(this string value, int indice) => indice >= 0 ? value.Substring(++indice) : value;

        public static bool SubStringFirstFirst(this string value, string delimiter, out int indice, out string newValue)
        {
            indice = value.IndexOf(delimiter);
            if (indice >= 0)
            {
                newValue = value.Substring(0, indice);
                return true;
            }

            newValue = value;
            return false;
        }

        public static PropertyInfo GetPropertyInfo(Type objType, string propertyName) =>
            objType.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        public static object GetValorPorPropriedade(Type objType, object obj, string propertyName) => GetPropertyInfo(objType, propertyName).GetValue(obj, null);

        public static object GetValorPorCaminho(Type objType, object obj, string path)
        {
            if (obj != null)
            {
                string className;
                int indice;
                if (path.SubStringFirstFirst(PONTO, out indice, out className))
                {
                    path = path.SubStringNext(indice);

                    if (className.Equals(objType.Name))
                    {
                        string[] names = path.Split('.');
                        path = names.Length > 1 ? names[0] : path;

                        if (names.Length > 1)
                        {
                            var prop = objType.GetProperty(path);
                            return GetValorPorCaminho(prop.PropertyType, prop.GetValue(obj, null),
                                                        names.Length == 1 ? names[0] : names[1]);
                        }
                        else
                            return GetValorPorPropriedade(objType, obj, path);
                    }
                    else
                    {
                        var prop = GetPropertyInfo(obj.GetType(), className);
                        return GetValorPorCaminho(prop.PropertyType, prop.GetValue(obj, null), path);
                    }
                }

                return GetValorPorPropriedade(objType, obj, path);
            }

            return null;
        }

        #endregion Reflection
    }
}