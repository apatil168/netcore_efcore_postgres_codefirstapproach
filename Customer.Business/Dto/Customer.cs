using Customer.Common.Dto;

namespace Customer.Business.Dto
{
    public class Customer : BaseDto, IEquatable<Customer>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => FirstName + LastName;
        public string? Email { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public string CustomerCode { get; set; }

        public bool Equals(Customer? other)
        {
            if (other == null) return false;
            return other.Id == Id && other.FirstName == FirstName && other.LastName == LastName && other.Email == Email;
        }
    }
}
