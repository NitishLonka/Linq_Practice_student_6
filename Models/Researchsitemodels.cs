namespace Linq_practice_studnet_6.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public List<Document>? documents { get; set; }

        public List<Download>? downloads { get; set; }

    }

    public class Download
    {
        public int Id { get; set; }

        public DateTime Downloaded_date { get; set; }

        public User? User { get; set; }

        public Document? Document { get; set; }

    }

    public class Document
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AreaofResearch { get; set; }

        public List<Download>? Downloads { get; set; }

        public User User { get; set; }
    }
}
