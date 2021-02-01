using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassMetotExamp
{
    class ClientManager
    {
        List<Client> clientList = new List<Client>();
        public void ClientAdd(Client client)
        {
            clientList.Add(client);
            Console.WriteLine(client.Name + " Client Added.");
        }

        public void ClientDelete(Client client)
        {
            var clientDeleted = clientList.Single(x => x.ID == client.ID);
            clientList.Remove(clientDeleted);
            Console.WriteLine(client.Name + " Client Deleted.");
        }

        public void ClientUpdate(Client client, string name , string surname, char gender)
        {
            string tempClient = client.Name;

            var clientUpdated = clientList.Single(x => x.ID == client.ID);
            clientUpdated.Name = name;
            clientUpdated.Surname = surname;
            clientUpdated.Gender = gender;

            Console.WriteLine(tempClient + " --> " + clientUpdated.Name);
        }

        public void ClientList()
        {
            foreach (var clients in clientList)
            {
                Console.WriteLine(clients.ID + " : " + clients.Name + " " + clients.Surname + " : " + clients.Gender);
            }
        }

    }
}
