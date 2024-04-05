using Domain.IRepository;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private List<T> _entities = new List<T>();

        public List<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
            return _entities.FirstOrDefault(e => GetId(e) == id);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            var existingEntity = _entities.FirstOrDefault(e => GetId(e) == GetId(entity));
            if (existingEntity != null)
            {       
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(existingEntity, prop.GetValue(entity));
                }
            }
        }

        public void Delete(int id)
        {
            _entities.RemoveAll(e => GetId(e) == id);
        }

        private int GetId(T entity)
        {
            var idProp = typeof(T).GetProperty("Id");
            if (idProp != null && idProp.PropertyType == typeof(int))
            {
                return (int)idProp.GetValue(entity);
            }
            else
            {
                throw new InvalidOperationException("Entity does not have a valid Id property.");
            }
        }

    }
}
