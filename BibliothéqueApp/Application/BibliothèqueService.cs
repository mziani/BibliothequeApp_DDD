using System;
using System.Collections.Generic;
using BibliothéqueApp.Domain.Entities;

namespace BibliothèqueApp.Application
{
    public class BibliothèqueService
    {
        private readonly List<Livre> _livres;
        private readonly List<Membre> _membres;
        private readonly List<Emprunt> _emprunts;

        public BibliothèqueService()
        {
            _livres = new List<Livre>();
            _membres = new List<Membre>();
            _emprunts = new List<Emprunt>();
        }

        public void AjouterLivre(Guid id, string titre)
        {
            var livre = new Livre(id, titre);
            _livres.Add(livre);
        }

        public void AjouterMembre(Guid id, string nom)
        {
            var membre = new Membre(id, nom);
            _membres.Add(membre);
        }

        public void EmprunterLivre(Guid livreId, Guid membreId, DateTime dateEmprunt, DateTime dateRendu)
        {
            var emprunt = new Emprunt(Guid.NewGuid(), livreId, membreId, dateEmprunt, dateRendu);
            _emprunts.Add(emprunt);
        }

        public List<Livre> ObtenirListeLivres()
        {
            return _livres;
        }

        public List<Membre> ObtenirListeMembres()
        {
            return _membres;
        }

        public List<Emprunt> ObtenirListeEmprunts()
        {
            return _emprunts;
        }
    }
}
