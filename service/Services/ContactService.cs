
using Domain.IRepository;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public static int LastId = 0;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;   
        }
        public bool Create(Contact entity)
        {
            var check =checkExist(entity, c => (c.FirstName == entity.FirstName && c.LastName == entity.LastName) || c.PhoneNumber == entity.PhoneNumber || c.Email == entity.Email);
            if (check) {
                return false;
            }
            LastId++;    
            entity.Id = LastId;
           _contactRepository.Add(entity);
            return true;
        }

        public void Delete(int id)
        {
            _contactRepository.Delete(id);
        }

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactRepository.GetById(id);

        }

        public bool Update( Contact entity)
        {
            var check = checkExist(entity, c =>c.Id !=entity.Id && c.FirstName == entity.FirstName && c.LastName == entity.LastName && c.PhoneNumber == entity.PhoneNumber && c.Email == entity.Email);
            if (check)
            {
                return false;
            }
            else
            {
                _contactRepository.Update(entity);
                return true;
            }

        }
        public bool checkExist(Contact entity, Func<Contact, bool> filter) {
            List<Contact> contact = GetAll();
            Contact exist = contact.FirstOrDefault(filter);
            if (exist != null)
            {
                return true;
            }
            return false;
        }
    }
}
