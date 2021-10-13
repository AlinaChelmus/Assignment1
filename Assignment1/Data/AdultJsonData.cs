using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;


namespace Assignment1.Data
{
    public class AdultJsonData: IUserService
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public AdultJsonData()
        {
            if (!File.Exists(adultFile))
            {
                Seed();
                WriteAdultsToFile();
            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }
        
        private void Seed()
        {
            Adult[] ad =
            {
                new Adult
                {
                    Id = 1,
                    FirstName = "Alina",
                    LastName = "chelmus",
                    HairColor = "Black",
                    EyeColor = "Brown",
                    Age = 34,
                    Weight = 70,
                    Height = 155,
                    Sex = "F",
                    JobTitle = "Student",
                    Salary = 8000
                },

                new Adult
                {
                    Id = 2,
                    FirstName = "Teo",
                    LastName = "Catana",
                    HairColor = "Blonde",
                    EyeColor = "Blue",
                    Age = 25,
                    Weight = 72,
                    Height = 178,
                    Sex = "M",
                    JobTitle = null,
                    Salary = 0
                },
            };
            adults = ad.ToList();
        }

        public IList<Adult> getAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public void AddAdult(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultsToFile();
        }

        public void RemoveAdult(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultsToFile();
        }

        private void WriteAdultsToFile()
        {
            string adultAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile,adultAsJson);
        }

        public void Update(Adult adults)
        {
            Adult toUpdate = adults.First(t => t.Id == adults.Id);
            toUpdate.FirstName = adults.FirstName;
            toUpdate.LastName = adults.LastName;
            toUpdate.HairColor = adults.HairColor;
            toUpdate.EyeColor = adults.EyeColor;
            toUpdate.Age = adults.Age;
            toUpdate.Weight = adults.Weight;
            toUpdate.Height = adults.Height;
            toUpdate.Sex = adults.Sex;
            toUpdate.JobTitle = adults.JobTitle;
            toUpdate.Salary = adults.Salary;
            WriteAdultsToFile();
        }

        public Adult Get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }


        public User ValidateUser(string userName, string Password)
        {
            User first = users.FirstOrDefault(user => user.Email.Equals(Email));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(Password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }

        public bool IsEmailRegistered(string email)
        {
            foreach (var user in users) if (user.Email.Equals(email)) return true;
            return false;
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}