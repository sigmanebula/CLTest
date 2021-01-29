namespace Poems
{
    public class Poem
    {
        public string title { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public Poet poet { get; set; }
    }

    public class Poet
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
