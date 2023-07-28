using System;
using System.Collections.Generic;
using BibliothèqueApp.Domain.Entities;
using BibliothéqueApp.Domain.Entities;

namespace BibliothèqueApp.Infrastructure.Persistence
{
    public class MemoryEmpruntRepository : EmpruntRepository
    {
        private List<Emprunt> emprunts = new List<Emprunt>();

        public override void AjouterEmprunt(Emprunt emprunt)
        {
            emprunts.Add(emprunt);
        }

        public override void MettreAJourEmprunt(Emprunt emprunt)
        {
            var index = emprunts.FindIndex(e => e.Id == emprunt.Id);
            if (index >= 0)
            {
                emprunts[index] = emprunt;
            }
            else
            {
                throw new Exception("Emprunt non trouvé dans la base de données.");
            }
        }

        public override List<Emprunt> ObtenirTousLesEmprunts()
        {
            return emprunts;
        }

        public override List<Emprunt> ObtenirEmpruntsParUtilisateur(Guid utilisateurId)
        {
            return emprunts.FindAll(e => e.UtilisateurId == utilisateurId);
        }

        public override Emprunt ObtenirEmpruntParId(Guid livreId)
        {
            return emprunts.Find(e => e.LivreId == livreId);
        }
    }
}