using P4GPayment.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P4GPayment.Domain;
using P4GPayment.Repositories;
using P4GPayment.Context;
using P4GPayment.Base;

namespace P4GPayment.Logic
{
    public class StreetNumberLogic : IStreetNumberLogic
    {
        private readonly StreetNumberRepository _repository = new StreetNumberRepository(new ApplicationDbContext());

        public ResponseMessage Create(StreetNumber entity)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Edit(StreetNumber entity)
        {
            throw new NotImplementedException();
        }

        public List<StreetNumber> GetAll()
        {
            return _repository.GetAll();
        }

        public StreetNumber GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}