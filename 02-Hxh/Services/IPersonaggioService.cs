using _02_Hxh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Hxh.Services
{
    interface IPersonaggioService
    {
        IEnumerable<Personaggio> GetAll();
        Personaggio GetById(int id);
        bool AddPersonaggio(Personaggio p);
        bool UpdatePersonaggio(Personaggio p);
        bool DeletePersonaggio(int id);
    }
}
