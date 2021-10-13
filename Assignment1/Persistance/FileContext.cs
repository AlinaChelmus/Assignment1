using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assignment1.Data;
using Models;
using Assignment1.Pages;
using Adult = Models.Adult;

namespace FileContext
{
    public class FileContext 
    {
        private readonly string adultsFile = "adults.json";

        private readonly string familiesFile = "families.json";

        public FileContext()
        {
            
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

       
        public IList<Adult> Adults { get; }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            
            var jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (var outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(Adults);
            return tmp;
        }

        public void AddAdult(Adult adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
             Adults.Add(adult);
             SaveChanges();
        }
    }
}