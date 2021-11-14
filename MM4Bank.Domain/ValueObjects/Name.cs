namespace MM4Bank.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => GetFullName();

        public Name(string fullName)
        {
            if (IsValid(fullName))
            {
                SetFrom(fullName);
            }
            // throw new System.ArgumentException(nameof(fullName));
            // tá estourando erro sempre,
            // é só por um else?
        }

        public void SetFrom(string fullName)
        {
            var name = fullName.Split(" ");
            // se não tem 2 nomes o índice 1 fica nulo
            // tem que pensar o que fazer aqui
            FirstName = name[0];
            LastName = name[1];
        }

        private string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
