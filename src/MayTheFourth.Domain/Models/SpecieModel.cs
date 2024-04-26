namespace MayTheFourth.Domain.Models
{
    public class SpecieModel
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string Average_Height { get; set; }
        public string Skin_Colors { get; set; }
        public string Hair_Colors { get; set; }
        public string Eye_Colors { get; set; }
        public string Average_Lifespan { get; set; }
        public string Homeworld { get; set; }
        public string Language { get; set; }
        public List<string> People { get; set; }
        public List<string> Films { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
