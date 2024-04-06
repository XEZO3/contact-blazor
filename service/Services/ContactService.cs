
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
        public void Create(Contact entity)
        {
            LastId++;
            entity.Id = LastId;
           _contactRepository.Add(entity);
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

        public void Update( Contact entity)
        {
             _contactRepository.Update(entity);

        }
    }
}
