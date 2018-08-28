namespace socialarts.club.Data
{
    public class ToolsDocument : IHaveUserData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // e.g. ~/tools/assertivenessscorecard
        // e.g. ~/tools/assertiveness-scorecard
        public string TemplateUrlPath { get; set; }

        public string Json { get; set; }

        public string OwnerId { get; set; }
    }
}