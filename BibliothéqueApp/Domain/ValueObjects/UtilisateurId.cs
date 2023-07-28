namespace BibliothéqueApp.Domain.ValueObjects
{
    public class UtilisateurId
    {
        public Guid Value { get; private set; }

        public UtilisateurId(Guid value)
        {
            Value = value;
        }
    }
}