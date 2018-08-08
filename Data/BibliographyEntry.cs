namespace socialarts.club.Data
{
    public abstract class BibliographyEntry
    {
        public int Id { get; set; }

        public string Title { get; set; }

        // optional chapter/section
        public string Section { get; set; }

        // TODO: Break Author into a List<string>
        public string Authors { get; set; }

        public string Year { get; set; }

        // for anchor tags
        public string Slug { get; set; }
    }

    public class BibliographyWebDocument : BibliographyEntry
    {
        public string RetrievedFrom { get; set; }
    }

    public class BibliographyBook : BibliographyEntry 
    {
        public string Publisher { get; set; }
    }
}