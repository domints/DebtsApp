namespace DebtsApp.Web.Database.Models
{
    public class Debt
    {
        public long Id { get; set; }
        public long CreatorId { get; set; }
        public bool IsMyDebt { get; set; }
        public long? OtherUserId { get; set; }
        public long? OtherContactId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public virtual User Creator { get; set; }
        public virtual User OtherUser { get; set; }
        public virtual Contact OtherContact { get; set; }
    }
}