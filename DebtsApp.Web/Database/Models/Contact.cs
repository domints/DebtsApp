namespace DebtsApp.Web.Database.Models
{
    public class Contact
    {
        public long Id { get; set; }
        public long OwnerUserId { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; }

        public virtual User OwnerUser { get; set; }
        public virtual User User { get; set; }
    }
}