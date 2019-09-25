namespace DebtsApp.Web.Interfaces
{
    public interface IJwtService
    {
         string GetToken(string email, string name);
    }
}