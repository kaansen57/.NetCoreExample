using System;
using System.Collections.Generic;

namespace ClassMetotExample
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ClientManager clientManager = new ClientManager();

            Client client1 = new Client();
            client1.ID = 1;
            client1.Name = "Kaan";
            client1.Surname = "ŞEN";
            client1.Gender = 'E';

            clientManager.ClientAdd(client1);

            Client client2 = new Client();
            client2.ID = 2;
            client2.Name = "Recep";
            client2.Surname = "ŞEN";
            client2.Gender = 'E';

            clientManager.ClientAdd(client2);

            clientManager.ClientList();

            clientManager.ClientUpdate(client1, "Mehmet", "ŞEN", 'E');

            clientManager.ClientList();

            clientManager.ClientDelete(client2);

            clientManager.ClientList();

        }
    }
}
