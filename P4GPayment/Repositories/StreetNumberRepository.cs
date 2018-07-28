using P4GPayment.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P4GPayment.Domain;
using P4GPayment.Context;

namespace P4GPayment.Repositories
{
    public class StreetNumberRepository : IStreetNumberRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreetNumberRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public StreetNumberRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(StreetNumber entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public StreetNumber Edit(StreetNumber entity)
        {
            throw new NotImplementedException();
        }

        public List<StreetNumber> GetAll()
        {
            return _db.StreetNumbers.ToList();
        }

        public StreetNumber GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}