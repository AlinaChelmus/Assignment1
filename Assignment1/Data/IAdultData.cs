using System;
using System.Collections.Generic;
using Models;


namespace Assignment1.Data
{
    public interface IAdultData
    {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
        void RemoveAdult(int adultId);
        void Update(Adult adult);
        Adult Get(int id);
       
    }
}