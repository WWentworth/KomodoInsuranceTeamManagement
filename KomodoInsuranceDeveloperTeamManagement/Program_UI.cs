using KomodoInsurance_POCO;
using KomodoInsuranceDeveloperTeamManagement_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperTeamManagement
{
    /* Developers need to have names, access to pluralsight and a unique identifier.
 * Teams need members, name and Id.
 * Managers can add and remove developers from teams by indentifier
 * managers need to be able to see devs on a team, create and update teams
 * BONUS:see all developers who need a pluralsight license
 * BONUS:add multiple developers to a team at once */
    class Program_UI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        private DevTeam _devteam = new DevTeam();
        private readonly List<Developer> _ListOfDevelopers = new List<Developer>();
        public void Run()
        {
            SeedDevelopersList();
            MainMenu();
        }
        private void MainMenu()
        {
            bool stillRunning = true;
            while (stillRunning)
            {
                Console.WriteLine("Select a numeric menu menu option:\n" +
                    "1.Add New Developer\n" +
                    "2.View Developers\n" +
                    "3.Update Developer\n" +
                    "4.Remove Developer\n" +
                    "5.Create Development Team\n" +
                    "6.View Devlopment Teams\n" +
                    "7.Delete Development Team\n" +
                    "8.Add Developer to Team\n" +
                    "9.Remove Developer From Team\n" +
                    "10.Exit");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        // create developer
                        CreateNewDeveloper();
                        break;
                    case 2:
                        //view developers
                        DisplayAllDevelopers();
                        break;
                    case 3:
                        //update developer
                        UpdateExistingDeveloper();
                        break;
                    case 4:
                        //remove developer
                        DeleteExistingDeveloper();
                        break;
                    case 5:
                        //create dev team
                        CreateNewDevTeam();
                        break;
                    case 6:
                        //view dev teams
                        DisplayAllTeams();
                        break;
                    case 7:
                        //delete team
                        DeleteExistingDevTeam();
                            break;

                    case 8:
                        //add developer from team
                        AddDeveloperToDevTeam();
                            break;
                    case 9:
                        //remove developer from team
                        RemoveDeveloperFromDevTeam();
                        break;
                    case 10:
                        stillRunning = false;
                        break;
                    //exit program
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("Please make a valid choice");
                        Console.ResetColor();
                        break;
                }
            }
        }
        private void CreateNewDeveloper()
        {
            Developer newDeveloper = new Developer();
            Console.Clear();
            Console.WriteLine("Please enter the Developer's name:");
            newDeveloper.Name = Console.ReadLine();
            Console.WriteLine("Does the Developer have aceess to PluralSight? (true or false)");
            newDeveloper.PluralSight = bool.Parse(Console.ReadLine());
            _developerRepo.AddDeveloperToList(newDeveloper);

        }
        private void DisplayAllDevelopers()
        {
            List<Developer> listOfDeveloper = _developerRepo.GetDeveloperList();
            Console.Clear();
            foreach (Developer developer in listOfDeveloper)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Name: {developer.Name}\n" +
                    $"ID: {developer.ID}\n" +
                    $"PluralSight Access: {developer.PluralSight}\n");
                Console.ResetColor();
            }
        }

        private void UpdateExistingDeveloper()
        {
            DisplayAllDevelopers();
            Developer newDeveloper = new Developer();
            Console.WriteLine("Enter the ID of the Developer you would like to update");
            int oldDeveloper = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please enter the Developer's name:");
            newDeveloper.Name = Console.ReadLine();
            Console.WriteLine("Does the Developer have aceess to PluralSight? (true or false)");
            newDeveloper.PluralSight = bool.Parse(Console.ReadLine());
            _developerRepo.UpdateExistingDeveloper(oldDeveloper, newDeveloper);

        }
        private void DeleteExistingDeveloper()
        {
            DisplayAllDevelopers();

            Console.WriteLine("Enter the ID you would like to remove:");
            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was Deleted.\n");
            }
            else
            {
                Console.WriteLine("No Developer found with that ID.\n");
            }

        }
        //create new dev team
        private void CreateNewDevTeam()
        {
            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Please enter the Team name:");
            newTeam.Name = Console.ReadLine();
            _devTeamRepo.AddDevTeamToList(newTeam);
        }

        //display team and members of team
        private void DisplayAllTeams()
        {
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            Console.Clear();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Team Name: {devTeam.Name}\n" +
                                    $"ID: {devTeam.TeamID}\n" +
                                    $"Members:");
                Console.ResetColor();
                foreach (Developer dev in devTeam.DeveloperList)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Name:{dev.Name}\n" +
                        $"Id: {dev.ID}\n");
                }
                Console.ResetColor();
            }

        }

        //delete team

        private void DeleteExistingDevTeam()
        {
            DisplayAllTeams();

            Console.WriteLine("Enter the ID you would like to remove:");
            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _devTeamRepo.RemoveTeamFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Team was Deleted.\n");
            }
            else
            {
                Console.WriteLine("No Developer found with that ID.\n");
            }
        }

        //add dev to team
        private void AddDeveloperToDevTeam()
        {
            DisplayAllTeams();
            Console.WriteLine("Enter the ID of the Team you are adding a Developer to:");
            int userInput = int.Parse(Console.ReadLine());
            DisplayAllDevelopers();
            Console.WriteLine("Please Enter the ID of the Developer being added to team:");
            int devSelection = int.Parse(Console.ReadLine());
            Developer devToAdd = _developerRepo.GetDeveloperById(devSelection);
            bool devAdded = _devTeamRepo.GetDevTeamById(userInput).AddDevToDevTeam(devToAdd);
            
        }
        //remove dev from team
        public void RemoveDeveloperFromDevTeam()
        {
            Console.WriteLine("Enter the ID of the Team you are adding a Developer to:");
            int userInput = int.Parse(Console.ReadLine());
            DisplayAllDevelopers();
            Console.WriteLine("Please Enter the ID of the Developer being added to team:");
            int devSelection = int.Parse(Console.ReadLine());
            Developer devToRemove = _developerRepo.GetDeveloperById(devSelection);
            bool devRemoved = _devTeamRepo.GetDevTeamById(userInput).RemoveDevFromDevTeam(devToRemove);
        }

            //seed list to have devs added
            private void SeedDevelopersList()
        {
            Developer bruce = new Developer("Bruce Banner", true);
            Developer tony = new Developer("Tony Stark", false);
            DevTeam frontEnd = new DevTeam("FrontEnd");
            DevTeam backEnd = new DevTeam("BackEnd");
            _developerRepo.AddDeveloperToList(bruce);
            _developerRepo.AddDeveloperToList(tony);
            _devTeamRepo.AddDevTeamToList(frontEnd);
            _devTeamRepo.AddDevTeamToList(backEnd);
        }
    }
}

