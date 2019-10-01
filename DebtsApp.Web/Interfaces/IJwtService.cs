namespace DebtsApp.Web.Interfaces
{
    public interface IJwtService
    {
         string GetToken(long id, string email, string name);
    }
}