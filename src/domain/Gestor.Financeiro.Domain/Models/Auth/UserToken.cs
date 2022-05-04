namespace Gestor.Financeiro.Domain.Models.Auth
{
    public class UserToken
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public IEnumerable<UserClaim>? Claims { get; set; }
    }
}
