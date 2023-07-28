namespace BibliothéqueApp.Domain.Entities
{
    public class Livre
    {
        public Guid Id { get; private set; }
        public string Titre { get; private set; }

        public Livre(Guid id, string titre)
        {
            Id = id;
            Titre = titre;
        }
    }
}