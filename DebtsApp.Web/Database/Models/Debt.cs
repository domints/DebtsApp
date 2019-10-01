namespace DebtsApp.Web.Database.Models
{
    public class Debt
    {
        public long Id { get; set; }
        public long CreatorId { get; set; }
        public long? OwedId { get; set; }
        public long? OwingId { get; set; }
        public long? OwedContactId { get; set; }
        public long? OwingContactId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public virtual User Creator { get; set; }
        public virtual User Owed { get; set; }
        public virtual User Owing { get; set; }
        public virtual Contact OwedContact { get; set; }
        public virtual Contact OwingContact { get; set; }
    }
}