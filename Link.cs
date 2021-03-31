namespace Energetic.ValueObjects
{
    public record Link : ValueObject<Link, (string, string, Url)>
    {
        public Link(string text, string title, Url url) : base((text, title, url))
        {
        }

        public string Text
        {
            get
            {
                var (text, _, _) = Value;
                return text;
            }
        }

        public string Title
        {
            get
            {
                var (_, title, _) = Value;
                return title;
            }
        }

        public Url Url
        {
            get
            {
                var (_, _, url) = Value;
                return url;
            }
        }
    }
}