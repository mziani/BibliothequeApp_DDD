using BibliothéqueApp.Domain.Events;
using System;
using System.IO;

namespace BibliothèqueApp.Application
{
    public class EvenementMediateur
    {
        public void EmettreEvenement(EmpruntEvent empruntEvent)
        {

            string logMessage = $"Emprunt du livre {empruntEvent.LivreId} par l'utilisateur {empruntEvent.UtilisateurId} le {empruntEvent.DateEmprunt}.";
            EnregistrerDansFichierLog(logMessage);
        }

        public void RecevoirEvenement(EmpruntEvent empruntEvent)
        {

            string emailSubject = "Confirmation d'emprunt";
            string emailBody = $"Cher utilisateur, vous avez emprunté le livre {empruntEvent.LivreId} le {empruntEvent.DateEmprunt}.";
            EnvoyerEmail(empruntEvent.UtilisateurId, emailSubject, emailBody);
        }

        private void EnregistrerDansFichierLog(string message)
        {

            string logFilePath = "emprunt_log.txt";
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
        }

        private void EnvoyerEmail(Guid utilisateurId, string sujet, string contenu)
        {

            Console.WriteLine($"Email envoyé à l'utilisateur {utilisateurId}: {sujet}\n{contenu}");
        }
    }
}