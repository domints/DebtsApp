namespace DebtsApp.Web.Database.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Seed { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}