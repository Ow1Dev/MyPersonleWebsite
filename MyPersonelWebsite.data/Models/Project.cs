namespace MyPersonelWebsite.data.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public virtual Tag Tag  { get; set; }
    }
}
