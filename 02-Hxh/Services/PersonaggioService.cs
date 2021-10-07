using _02_Hxh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _02_Hxh.Services
{
    public class PersonaggioService : IPersonaggioService
    {
        private Database db;

        private static PersonaggioService _instance = null;

        private PersonaggioService()
        {
            db = new Database("hxh");
        }

        public static PersonaggioService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PersonaggioService();
            }

            return _instance;
        }


        public IEnumerable<Personaggio> GetAll()
        {
            List<Personaggio> r = new List<Personaggio>();

            List<Dictionary<string, string>> righe = db.Read("select * from personaggi");

            foreach (Dictionary<string, string> riga in righe)
            {
                Personaggio p = new Personaggio();
                p.FromDictionary(riga);

                r.Add(p);
            }

            return r;
        }

        public Personaggio GetById(int id)
        {
            return GetInstance().GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public bool AddPersonaggio(Personaggio p)
        {
            string query = $"insert into personaggi (nome,potenza,dob) " +
                                   $"values ('{p.Nome}',{p.Potenza},'{p.Dob.Year}-{p.Dob.Month}-{p.Dob.Day}'); ";

            return db.Update(query);
        }
        public bool UpdatePersonaggio(Personaggio p)
        {
            string query = $"update personaggi set nome='{p.Nome}',potenza='{p.Potenza}',dob='{p.Dob.Year}-{p.Dob.Month}-{p.Dob.Day}' where id ={p.Id}";

            return db.Update(query);
        }

        public bool DeletePersonaggio(int id)
        {
            string query = $"delete from personaggi where id = {id}";

            return db.Update(query);
        }

    }
}
