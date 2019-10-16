using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class FieldFilter : IFilter
    {
        private readonly string _fieldName;
        private readonly IFilter _child;

        public FieldFilter(string fieldName, IFilter child)
        {
            _fieldName = fieldName;
            _child = child;
        }

        public bool Filter(BsonValue value)
        {
            if (TryGetFieldValue(value, out BsonValue fieldValue))
            {
                return _child.Filter(fieldValue);
            }
            return false;
        }

        private bool TryGetFieldValue(BsonValue inputValue, out BsonValue fieldValue)
        {
            fieldValue = null;
            if (!inputValue.IsBsonDocument)
            {
                return false;
            }

            var document = inputValue.AsBsonDocument;
            if (!document.Contains(_fieldName))
            {
                return false;
            }

            fieldValue = document[_fieldName];
            return true;
        }
    }
}