using System;
using System.IO;
using System.Net.Sockets;

namespace IACryptOfTheCSharpDancer.modules
{
    /// <summary>Module en charge de la communication avec le sereur</summary>
    public class ModuleCommunication : Module
    {
        /// <summary>Le client TCP</summary>
        private TcpClient client;
        /// <summary>Le flux entrant depuis le serveur</summary>
        private StreamReader fluxEntrant;
        /// <summary>Le flux sortant vers le serveur</summary>
        private StreamWriter fluxSortant;

        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleCommunication(IA ia) : base(ia){}

        /// <summary>Création du client TCP </summary>
        private void Connexion()
        {
            this.client = new TcpClient("127.0.0.1", 1234);
        }

        /// <summary>Création du flux entrant et du flux sortant</summary>
        private void CreationFlux()
        {
            this.fluxEntrant = new StreamReader(this.client.GetStream());
            this.fluxSortant = new StreamWriter(this.client.GetStream())
            {
                AutoFlush = true
            };
        }

        /// <summary>Etablir la connexion avec le serveur</summary>
        public void EtablirConnexion()
        {
            this.Connexion();
            this.CreationFlux();
        }

        /// <summary>Envoyer un message au serveur</summary>
        /// <param name="message">Le message à envoyer</param>
        public void EnvoyerMessage(string message)
        {
            Console.WriteLine(">> " + message);
            this.fluxSortant.WriteLine(message);
        }

        /// <summary>Recevoir un message depuis le serveur (bloque jusqu'à réception d'un message)</summary>
        public String RecevoirMessage()
        {
            String message = this.fluxEntrant.ReadLine();
            Console.WriteLine("<< " + message);
            return message;
        }

        /// <summary>Termine la connexion au serveur</summary>
        public void FermerConnexion()
        {
            this.client.Close();
        }
    }
}
