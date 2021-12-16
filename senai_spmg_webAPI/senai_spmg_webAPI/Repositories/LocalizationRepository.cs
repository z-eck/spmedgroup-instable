using MongoDB.Driver;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmg_webAPI.Repositories
{
    public class LocalizationRepository : ILocalizationRepository
    {
        private readonly IMongoCollection<Localization> lclztn;

        public LocalizationRepository()
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("senai_spmg");
            lclztn = database.GetCollection<Localization>("localization");
        }

        public void Create(Localization newLocalization)
        {
            lclztn.InsertOne(newLocalization);
        }

        public List<Localization> ReadAll()
        {
            return lclztn.Find(localization => true).ToList();
        }
    }
}
