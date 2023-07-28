namespace BibliothéqueApp.Domain.Entities
{
    public class Emprunt
    {
        private Guid guid;
        private Guid value;

        public Guid Id { get; private set; }
        public Guid LivreId { get; private set; }
        public Guid UtilisateurId { get; private set; }
        public DateTime DateEmprunt { get; private set; }


        public Emprunt(Guid id, Guid livreId, Guid utilisateurId, DateTime dateEmprunt, DateTime dateRendu)
        {
            Id = id;
            LivreId = livreId;
            UtilisateurId = utilisateurId;
            DateEmprunt = dateEmprunt;
        }

        public Emprunt(Guid guid, Guid livreId, Guid value, DateTime dateEmprunt)
        {
            this.guid = guid;
            LivreId = livreId;
            this.value = value;
            DateEmprunt = dateEmprunt;
        }
    }
}