using System;

namespace Interface_Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionManager connectionManager = new ConnectionManager();

            IConnectionDal[] connections = new IConnectionDal[3]
            {
                new SqlConnection(),
                new MysqlConnection(),
                new MongoConnection()
            };

            foreach (IConnectionDal connect in connections)
            {
                connectionManager.Add(connect);
            }

            connectionManager.Remove(new MysqlConnection());


            foreach (IConnectionDal item in connections)
            {
                if (item is SqlConnection || item is MongoConnection)
                {
                    item.Update();
                }
            }
        }
    }
}
