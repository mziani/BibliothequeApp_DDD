using BibliothéqueApp.Domain.Entities;
using BibliothéqueApp.Domain.Events;
using BibliothéqueApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace BibliothèqueApp.Domain
{
    public class EmpruntAggregate
    {
        private List<Emprunt> emprunts = new List<Emprunt>();

        public void EmprunterLivre(Guid livreId, UtilisateurId utilisateurId, DateTime dateEmprunt)
        {
            var emprunt = new Emprunt(Guid.NewGuid(), livreId, utilisateurId.Value, dateEmprunt);
            emprunts.Add(emprunt);

            var empruntEvent = new EmpruntEvent(livreId, utilisateurId.Value, dateEmprunt);
 
        }

        public List<Emprunt> ObtenirEmprunts()
        {

            return emprunts;
        }
    }
}