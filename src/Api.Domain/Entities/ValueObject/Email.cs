namespace Api.Domain.Entities.ValeuObjects
{
    public sealed class Email
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}