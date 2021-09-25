using KomodoInsurance_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperTeamManagement_Repo
{
    public class DeveloperRepo
    {
        private List<Developer> _listofDevelopers = new List<Developer>();
        public List<Developer> ListOfDevelopers { get; set; }
        public int _count = 0;
        
        //create
        public bool AddDeveloperToList(Developer devToBeAdded)
        {
            if(devToBeAdded is null)
            {
                return false;
            }
            _count++;
            devToBeAdded.ID = _count;
            _listofDevelopers.Add(devToBeAdded);
            return true;
        }
        //read
        public List<Developer> GetDeveloperList()
        {
            return _listofDevelopers;
        }

        //update
        public bool UpdateExistingDeveloper(int originalDeveloper, Developer updatedDeveloper)
        {
            Developer oldDeveloper = GetDeveloperById(originalDeveloper);

            if (oldDeveloper != null)
            {
                oldDeveloper.Name = updatedDeveloper.Name;
                oldDeveloper.PluralSight = updatedDeveloper.PluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete
        public bool RemoveDeveloperFromList(int id)
        {
            var devToBeDeleted = GetDeveloperById(id);

            if (devToBeDeleted is null)
            {
                return false;
            }
            else
            {
                _listofDevelopers.Remove(devToBeDeleted);
                return true;
            }
        }
        //find developer by their unique id
        public Developer GetDeveloperById(int id)
        {
            foreach(Developer developer in _listofDevelopers)
            {
                if(developer.ID == id)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
