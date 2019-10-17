using DebtsApp.Web.Interfaces;

namespace DebtsApp.Web.APIModels
{
    public class Contact : IIdEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsChitUser { get; set; }
        public decimal Balance { get; set; }
    }
}