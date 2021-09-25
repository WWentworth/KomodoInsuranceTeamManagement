using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_POCO
{
    public class Developer
    {
        public string Name { get; set; }
        public bool PluralSight { get; set; }
        public int ID { get; set; }

        public Developer() { }

        public Developer(string name, bool pluralSight)
        {
            Name = name;
            PluralSight = pluralSight;
        }
    }

}
