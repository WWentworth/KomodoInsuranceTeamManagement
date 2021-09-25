using KomodoInsurance_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperTeamManagement_Repo
{
    public class DevTeamRepo
    {
       private List<DevTeam> _listofDevTeams = new List<DevTeam>();
        //public List<DevTeam> ListOfDevTeams { get; set; }
        private int _count = 0;
        //create
        public bool AddDevTeamToList(DevTeam teamToBeAdded)
        {
            if (teamToBeAdded is null)
            {
                return false;
            }
            _count++;
            teamToBeAdded.TeamID = _count;
            _listofDevTeams.Add(teamToBeAdded);
            return true;
        }
        //read
        public List<DevTeam> GetDevTeamList()
        {
            return _listofDevTeams;
        }
        //update
        public bool UpdateExistingDevTeam(int originalDevTeam, DevTeam updatedDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamById(originalDevTeam);

            if (oldDevTeam != null)
            {
                oldDevTeam.Name = updatedDevTeam.Name;
                oldDevTeam.TeamID = updatedDevTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveTeamFromList(int teamID)
        {
            var teamToBeDeleted = GetDevTeamById(teamID);

            if (teamToBeDeleted is null)
            {
                return false;
            }
            else
            {
                _listofDevTeams.Remove(teamToBeDeleted);
                return true;
            }
        }
        public DevTeam GetDevTeamById(int teamID)
        {
            foreach (DevTeam devTeam in _listofDevTeams)
            {
                if (devTeam.TeamID == teamID)
                {
                    return devTeam;
                }
            }
            return null;
        }
    }

}
