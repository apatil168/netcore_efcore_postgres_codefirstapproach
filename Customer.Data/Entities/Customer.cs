using Customer.Common.Entities;

namespace Customer.Data.Entities
{
    public  class Customer : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string CustomerCode { get; set; }
    }
}
