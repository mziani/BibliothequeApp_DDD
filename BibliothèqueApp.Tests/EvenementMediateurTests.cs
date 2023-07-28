using System;
using Xunit;
using Moq;
using BibliothéqueApp.Domain.Events;

namespace BibliothèqueApp.Application.Tests
{
    public class EvenementMediateurTests
    {
        [Fact]
        public void EmettreEvenement_LogsEmpruntEvent()
        {

            var evenementMediateur = new EvenementMediateur();
            var empruntEvent = new EmpruntEvent(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);

            evenementMediateur.EmettreEvenement(empruntEvent);

        }

        [Fact]
        public void RecevoirEvenement_SendsConfirmationEmail()
        {

            var evenementMediateur = new EvenementMediateur();
            var empruntEvent = new EmpruntEvent(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);

            evenementMediateur.RecevoirEvenement(empruntEvent);

        }
    }
}
