using System;
using BibliothèqueApp.Application;
using BibliothèqueApp.Domain.Entities;
using BibliothéqueApp.Domain.Events;
using BibliothèqueApp.Infrastructure.Persistence;

class Program
{
    static void Main(string[] args)
    {
        var bibliothèqueService = new BibliothèqueService();
        var evenementMediateur = new EvenementMediateur();
        var empruntRepository = new MemoryEmpruntRepository();

 
        bibliothèqueService.AjouterLivre(Guid.NewGuid(), "Livre 1");
        bibliothèqueService.AjouterLivre(Guid.NewGuid(), "Livre 2");
        bibliothèqueService.AjouterLivre(Guid.NewGuid(), "Livre 3");


        bibliothèqueService.AjouterMembre(Guid.NewGuid(), "Membre 1");
        bibliothèqueService.AjouterMembre(Guid.NewGuid(), "Membre 2");


        var livreId = bibliothèqueService.ObtenirListeLivres()[0].Id;
        var membreId = bibliothèqueService.ObtenirListeMembres()[0].Id;
        var dateEmprunt = DateTime.Now;
        var dateRendu = dateEmprunt.AddDays(14);
        bibliothèqueService.EmprunterLivre(livreId, membreId, dateEmprunt, dateRendu);


        var empruntEvent = new EmpruntEvent(livreId, membreId, dateEmprunt);
        evenementMediateur.EmettreEvenement(empruntEvent);


        evenementMediateur.RecevoirEvenement(empruntEvent);


        Console.WriteLine("Liste de tous les emprunts :");
        var tousLesEmprunts = empruntRepository.ObtenirTousLesEmprunts();
        foreach (var emprunt in tousLesEmprunts)
        {
            Console.WriteLine($"EmpruntId: {emprunt.Id}, LivreId: {emprunt.LivreId}, UtilisateurId: {emprunt.UtilisateurId}, DateEmprunt: {emprunt.DateEmprunt}");
        }


        Console.WriteLine("\nListe des emprunts par utilisateur :");
        var empruntsParUtilisateur = empruntRepository.ObtenirEmpruntsParUtilisateur(membreId);
        foreach (var emprunt in empruntsParUtilisateur)
        {
            Console.WriteLine($"EmpruntId: {emprunt.Id}, LivreId: {emprunt.LivreId}, UtilisateurId: {emprunt.UtilisateurId}, DateEmprunt: {emprunt.DateEmprunt}");
        }

        Console.WriteLine("\nAfficher un emprunt par ID de livre :");
        var empruntParId = empruntRepository.ObtenirEmpruntParId(livreId);
        if (empruntParId != null)
        {
            Console.WriteLine($"EmpruntId: {empruntParId.Id}, LivreId: {empruntParId.LivreId}, UtilisateurId: {empruntParId.UtilisateurId}, DateEmprunt: {empruntParId.DateEmprunt}");
        }
        else
        {
            Console.WriteLine("Aucun emprunt trouvé pour l'ID spécifié.");
        }
    }
}