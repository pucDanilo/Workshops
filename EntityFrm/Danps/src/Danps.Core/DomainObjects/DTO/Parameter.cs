namespace Danps.Core.DomainObjects.DTO
{
    public struct Parameter
    {
        public object Value { get; private set; }
        public string Field { get; private set; }

        public Parameter(string field, object value)
        {
            Field = field;
            Value = value;
        }
    }
}