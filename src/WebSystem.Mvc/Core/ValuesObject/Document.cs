using WebSystem.Mvc.Core.Enums;

namespace WebSystem.Mvc.Core.ValuesObject
{
    public class Document
    {
        public EDocumentType Type { get; private set; }
        public string Number { get; private set; }

        public Document(EDocumentType type, string number)
        {
            Type = type;
            Number = number;
        }
    }
}
