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
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;   
        }
        public void Create(Contact entity)
        {
           _contactRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _contactRepository.Delete(id);
        }

        public Task<List<Contact>> GetAll()
        {
            return Task.FromResult(_contactRepository.GetAll());
        }

        public Task<Contact> GetById(int id)
        {
            return Task.FromResult(_contactRepository.GetById(id));

        }

        public void Update( Contact entity)
        {
             _contactRepository.Update(entity);

        }
    }
}
