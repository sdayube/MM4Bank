namespace MM4Bank.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        protected bool IsValid(string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return false;
            }
            return true;
        }
    }
}
