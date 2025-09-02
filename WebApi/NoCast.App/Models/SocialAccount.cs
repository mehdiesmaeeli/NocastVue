namespace NoCast.App.Models
{
    public class SocialAccount
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public SocialPlatform Platform { get; set; } // Instagram, Twitter, etc.
        public string ProfileName { get; set; }

        public bool IsVerified { get; set; } // شرایط تایید مثل تعداد فالوور یا بررسی دستی

        public DateTime CreatedAt { get; set; }
    }

    public enum SocialPlatform
    {
        Instagram,
        YouTube,
        Twitter,
    }
}
