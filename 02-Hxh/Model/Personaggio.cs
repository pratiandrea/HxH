using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _02_Hxh.Model
{
    public class Personaggio : Entity
    {
        public string Nome { get; set; }
        public int Potenza { get; set; }
        public DateTime Dob { get; set; }
    }
}
