using Danps.Core.DomainObjects;
using Danps.Core.DomainObjects.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Danps.Core.Data
{
    public abstract class RawQueryGeneric : IRawQuery
    {
        protected static string SELECT_COUNT => "select count(*) Total";
        private StringBuilder SelectList;
        private string SelectCount;
        private StringBuilder GroupByList;
        protected StringBuilder TableSource;
        private StringBuilder _searchCondition;
        private string _orderExpression;
        private List<Parameter> _parametros;

        public RawQueryGeneric(string orderBy = null) : this(orderBy, SELECT_COUNT)
        {
        }

        public RawQueryGeneric(string orderBy, string selectCount)
        {
            SelectCount = selectCount;
            _parametros = new List<Parameter>();
            _orderExpression = string.IsNullOrEmpty(orderBy) ? "" : "ORDER BY " + orderBy;
            TableSource = new StringBuilder();
        }

        public void AddSelectItem(string columnTable, string alias, bool IsGroupingItem = false)
        {
            AddSelectItem($"{columnTable} as {alias}");
            if (IsGroupingItem)
            {
                AddGroupByItem(columnTable);
            }
        }

        public void AddGroupByItem(string columnTable)
        {
            if (GroupByList != null)
                GroupByList.Append(",");
            else
                GroupByList = new StringBuilder();

            GroupByList.Append(Environment.NewLine).Append(columnTable);
        }

        public void AddSelectItem(string sql)
        {
            if (SelectList != null)
                SelectList.Append(",");
            else
                SelectList = new StringBuilder();

            SelectList.Append(Environment.NewLine).Append(sql);
        }

        public void AddTableSourceItem(string sql)
        {
            TableSource.Append(Environment.NewLine).Append(sql);
        }

        private string _querySpecification => $" {SelectList} {TableSourceCondition} {GroupByExpression} {_orderExpression} ";
        protected string GroupByExpression => GroupByList != null ? $"group by {GroupByList.ToString()}" : "";
        protected string TableSourceCondition => TableSource.ToString() + (_searchCondition != null ? _searchCondition.ToString() : "");

        public Parameter[] GetParameters() => _parametros.ToArray();

        public string GetCountQuery() => $"{SelectCount} {TableSourceCondition}";

        public string GetQuery() => $"select distinct {_querySpecification}";

        public string GetQuery(int maxResults) => $"select distinct top {maxResults} {_querySpecification}";

        public string GetQuery(int pageNumber, int maxResults)
        {
            if (pageNumber < 0)
            {
                throw new Exception("O número da página precisa ser maior que zero!");
            }
            return $"select distinct {_querySpecification} OFFSET {(pageNumber - 1) * maxResults} ROWS FETCH NEXT {maxResults} ROWS ONLY; ";
        }

        public string FormatField(string field, int pos = 0)
        {
            return $"{field}_{pos}";
        }

        public string FormatFieldExpression(string field, int pos = 0)
        {
            return "@" + FormatField(field, pos);
        }

        public string GetLabelParametros(IEnumerable itens, string field)
        {
            string listaLabels = "";
            int i = 0;
            foreach (var item in itens)
            {
                listaLabels += $"{FormatFieldExpression(field, i)},";
                i++;
            }

            if (!string.IsNullOrEmpty(listaLabels))
            {
                listaLabels = listaLabels.Substring(0, listaLabels.Length - 1);
            }

            return listaLabels;
        }

        private void AddExpressionFormat(string expression, string field)
        {
            AddExpression(string.Format(expression, FormatFieldExpression(field)));
        }

        public void AddExpression(string sql)
        {
            if (_searchCondition == null)
            {
                _searchCondition = new StringBuilder();
                _searchCondition.Append(" where ");
            }
            else
                _searchCondition.Append(" and ");
            _searchCondition.Append(sql).Append(Environment.NewLine);
        }

        public void AddExpression(string item, string field, string expression)
        {
            if (!string.IsNullOrEmpty(item))
            {
                AddParametro(item, field);
                AddExpressionFormat(expression, field);
            }
        }

        public void AddExpression(DateTime item, string field, string expression)
        {
            if (item != null && item > DateTime.MinValue)
            {
                AddParametro(field, item);
                AddExpressionFormat(expression, field);
            }
        }

        public void AddExpression(object item, string field, string expression)
        {
            AddParametro(field, item);
            AddExpressionFormat(expression, field);
        }

        public void AddExpression(IEnumerable itens, string field, string expression)
        {
            if (itens != null)
            {
                AddParametro(field, itens);
                AddExpression(string.Format(expression, GetLabelParametros(itens, field)));
            }
        }

        public void AddExpressionNotNull(string field)
        {
            AddExpression($"{field} is not null");
        }

        public void AddExpressionNull(string field)
        {
            AddExpression($"{field} is null");
        }

        public void AddParametro(string field, object item)
        {
            if (item != null)
                _parametros.Add(new Parameter(FormatField(field, 0), item));
        }

        public void AddParametro(string field, IEnumerable itens)
        {
            if (itens != null)
            {
                int i = 0;
                foreach (var item in itens)
                {
                    _parametros.Add(new Parameter(FormatField(field, i), item));
                    i++;
                }
            }
        }

        public void AddParametro(string field, string item)
        {
            if (!string.IsNullOrEmpty(item))
                _parametros.Add(new Parameter(FormatField(field, 0), item));
        }

        public void AddParametroAny(string field, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value += "%";
                _parametros.Add(new Parameter(FormatField(field, 0), value));
            }
        }

        public void AddParametro(string field, DateTime value, string mask = "yyyy-MM-dd")
        {
            if (value != null && value > DateTime.MinValue)
                _parametros.Add(new Parameter(FormatField(field, 0), value.ToString(mask)));
        }
    }
}