using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_POCO
{
   public class DevTeam
    {
        public string Name { get; set; }
        public int TeamID { get; set; }
        public List<Developer> DeveloperList { get; set; }

        public DevTeam() { }

        public DevTeam(string name)
        {
            Name = name;
            DeveloperList = new List<Developer>();
        }

        public bool AddDevToDevTeam(Developer devToBeAdded)
        {
            int developerCount = this.DeveloperList.Count;
            this.DeveloperList.Add(devToBeAdded);

            if(developerCount < this.DeveloperList.Count)
            {
                return true;
            }
            return false;
        }

        public bool RemoveDevFromDevTeam(Developer devToBeRemoved)
        {
            int developerCount = this.DeveloperList.Count;
            this.DeveloperList.Remove(devToBeRemoved);

            if(developerCount > this.DeveloperList.Count)
            {
                return true;
            }
            return false;
        }
    }
}
