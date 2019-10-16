using System;

namespace MongoDB.Fake.Tests
{
    public class SimpleTestDocument
    {
        public class ChildDocument
        {
            public string StringField { get; set; }
            public int IntField { get; set; }
        }

        public Guid Id { get; set; }
        public string StringField { get; set; }
        public int IntField { get; set; }
        public ChildDocument Child { get; set; }
        public string[] ArrayField { get; set; }
    }
}