namespace WebSystem.Mvc.Core.ValuesObject
{
    public class Email
    {
        public string EmailAddress { get; private set; }

        public Email() { }

        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
