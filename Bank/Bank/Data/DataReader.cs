using BankApp.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankApp.Data
{
    class DataReader
    {
        public static List<Client> ReadClients()
        {
            List<Client> clients;
            var relation = @"..\..\..\";
            var currPath = Path.Combine(Environment.CurrentDirectory, relation, @"Data\clients.json");

            using (StreamReader r = new StreamReader(currPath))
            {
                string json = r.ReadToEnd();
                clients = JsonConvert.DeserializeObject<List<Client>>(json);
            }

            return clients;
        }
    }
}
