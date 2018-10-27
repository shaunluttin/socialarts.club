using System.Collections.Generic;

namespace socialarts.club.Pages.Tools
{
    public class CostBenefitOption 
    {
        public string Action { get; set; }

        public string Advantages { get; set; }

        public string Disadvantages { get; set; }
    }

    public class CostBenefitAnalysis
    {
        public string TheProblem { get; set; }

        public List<CostBenefitOption> Options { get; set; } = new List<CostBenefitOption>();
    }
}
