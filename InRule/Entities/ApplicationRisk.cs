namespace InRule.Entities
{
    public class ApplicationRisk
    {
        public int Id { get; set; }
        public string VesselCategory { get; set; }
        public int GrossTonnage { get; set; }
        public string RiskCategory { get; set; }
        public int Age { get; set; }
        public int VesselFlag { get; set; }
    }
}
