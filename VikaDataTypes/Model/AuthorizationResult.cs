namespace Vk.Model
{
    public class AuthorizationResult
    {
        public AuthorizationStatus Status { get; set; }
        public AuthorizationContext Context { get; set; }
        public string Description { get; set; }
    }
}