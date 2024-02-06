using AppointEase.Domain.AppointEase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointEase.Application.AppointEase.Application.Interface
{
    public interface IPersonRepository
    {
        Person GetPerson(int personId);
        IEnumerable<Person> GetAllPersons();
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
