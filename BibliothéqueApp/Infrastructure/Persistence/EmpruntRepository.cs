using BibliothéqueApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BibliothèqueApp.Domain.Entities
{
    public abstract class EmpruntRepository
    {
        public abstract void AjouterEmprunt(Emprunt emprunt);
        public abstract List<Emprunt> ObtenirTousLesEmprunts();
        public abstract Emprunt ObtenirEmpruntParId(Guid empruntId);
        public abstract List<Emprunt> ObtenirEmpruntsParUtilisateur(Guid utilisateurId);
        public abstract void MettreAJourEmprunt(Emprunt emprunt);
    }
}