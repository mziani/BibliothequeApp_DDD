using BibliothéqueApp.Domain.ValueObjects;
using System;
using Xunit;
using Assert = Xunit.Assert;

namespace BibliothèqueApp.Domain.Tests
{
    public class EmpruntAggregateTests
    {
        [Fact]
        public void EmprunterLivre_CreatesNewEmprunt()
        {

            var empruntAggregate = new EmpruntAggregate();
            var livreId = Guid.NewGuid();
            var utilisateurId = new UtilisateurId(Guid.NewGuid());
            var dateEmprunt = DateTime.Now;


            empruntAggregate.EmprunterLivre(livreId, utilisateurId, dateEmprunt);

            var emprunts = empruntAggregate.ObtenirEmprunts();
            Assert.Single(emprunts);
            var emprunt = emprunts[0];
            Assert.Equal(livreId, emprunt.LivreId);
            Assert.Equal(utilisateurId.Value, emprunt.UtilisateurId);
            Assert.Equal(dateEmprunt, emprunt.DateEmprunt);
        }

    }
}
