namespace BibliothéqueApp.Domain.Entities
{
    public class Membre
    {
        public Guid Id { get; }
        public string Nom { get; }

        public Membre(Guid id, string nom)
        {
            Id = id;
            Nom = nom;
        }
    }
}