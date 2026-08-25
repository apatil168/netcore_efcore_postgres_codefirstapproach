namespace Customer.Common.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
    }
}
