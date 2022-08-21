namespace UniUti.Application.ValueObjects
{
    public class TokenJwt
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
