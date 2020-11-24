using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowFiddlerTests.Steps
{
    public class User
    {

        public string FirstName;
        public string MiddleName;
        public string Surname;
        public int BirthYear;
        public string City;

        public List<User> usersList = new List<User>()
        {
            new User("John", "", "Johnson", 1980, "Vienna"),
            new User("Stephen", "", "Stephenson", 1984, "Paris"),
            new User("Ivan", "", "Ivanov", 1978, "Moscow"),
            new User("Jack", "fon", "Brown", 1975, "New York")
        };

        public User(string firstName, string middleName, string surname, int birthYear, string city)
        {
            FirstName = firstName;
            MiddleName = middleName;
            Surname = surname;
            BirthYear = birthYear;
            City = city;

            foreach (User user in usersList)
            {
                if (user.City == "Vienna" && user.Surname == "Johnson")
                {
                    Console.WriteLine(user);
                }
            }

        }
    }
}






        




    







//Task:
//- to print all information about all users with Surname 'Johnson' who lives in City 'Vienna'
//- to remove duplicates(Users with the same Surname, BirthYear and City are the same person)



