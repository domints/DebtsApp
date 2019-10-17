using DebtsApp.Web.Interfaces;

namespace DebtsApp.Web.APIModels
{
    public class Debt : IIdEntity
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public bool IsMyDebt { get; set; }
        public long OtherId { get; set; }
        public string OtherName { get; set; }
        public bool IsEditable { get; set; }
    }
}