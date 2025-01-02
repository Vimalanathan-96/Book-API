namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }

        // MLA Citation
        public string MlaCitation => $"{AuthorLastName}, {AuthorFirstName}. \"{Title}.\" {Publisher}.";

        // Chicago Citation
        public string ChicagoCitation => $"{AuthorFirstName} {AuthorLastName}. {Title}. {Publisher}.";
    }
}
