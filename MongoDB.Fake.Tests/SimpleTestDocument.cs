using System;

namespace MongoDB.Fake.Tests
{
    public class SimpleTestDocument
    {
        public class ChildDocument
        {
            public String StringField { get; set; }
            public Int32 IntField { get; set; }
        }

        public Guid Id { get; set; }
        public String StringField { get; set; }
        public Int32 IntField { get; set; }
        public ChildDocument Child { get; set; }
        public String[] ArrayField { get; set; }
    }
}