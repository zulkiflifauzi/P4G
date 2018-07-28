using P4GPayment.Context;
using P4GPayment.Domain;
using P4GPayment.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4GPayment.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AddressRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(Address entity)
        {
            _db.Addresses.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.Addresses.SingleOrDefault(c => c.Id == id);
            _db.Addresses.Remove(oldData);
            _db.SaveChanges();
        }

        public Address Edit(Address entity)
        {
            var address = _db.Addresses.Find(entity.Id);
            _db.Entry(address).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return address;
        }

        public List<Address> GetAll()
        {
            return _db.Addresses.ToList();
        }

        public List<int> GetAttachedUserIds()
        {
            return _db.Addresses.Where(c => c.OwnerId.HasValue).Select(c => c.OwnerId.Value).ToList();
        }

        public Address GetById(int id)
        {
            return _db.Addresses.SingleOrDefault(c => c.Id == id);
        }

        public bool IsAddressExist(string street, int number, int? exceptionId = null)
        {
            if(exceptionId.HasValue)
                return _db.Addresses.Any(c => c.Street.Equals(street) && c.Number == number && c.Id != exceptionId);
            else
                return _db.Addresses.Any(c => c.Street.Equals(street) && c.Number == number);
        }
    }
}