namespace CleanArthitecture.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; init; }
        public int ExpiryMinutes { get; init; }
        public string Isuuer { get; init; }
        public string Audience { get; init; }
    }
}
