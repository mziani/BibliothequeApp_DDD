namespace BibliothéqueApp.Domain.Events
{
    public class EmpruntEvent
    {
        public Guid LivreId { get; private set; }
        public Guid UtilisateurId { get; private set; }
        public DateTime DateEmprunt { get; private set; }

        public EmpruntEvent(Guid livreId, Guid utilisateurId, DateTime dateEmprunt)
        {
            LivreId = livreId;
            UtilisateurId = utilisateurId;
            DateEmprunt = dateEmprunt;
        }
    }
}