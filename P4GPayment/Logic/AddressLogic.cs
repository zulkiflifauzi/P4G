using P4GPayment.Base;
using P4GPayment.Context;
using P4GPayment.Domain;
using P4GPayment.Logic.Interface;
using P4GPayment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4GPayment.Logic
{
    public class AddressLogic : IAddressLogic
    {
        private readonly AddressRepository _repository = new AddressRepository(new ApplicationDbContext());
        
        public Address GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Address> GetAll()
        {
            return _repository.GetAll();
        }

        public ResponseMessage Create(Address entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsAddressExist(entity.Street, entity.Number))
            {
                response.IsError = true;
                response.ErrorCodes.Add("Address Already Exist");
                return response;
            }
            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Edit(Address entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsAddressExist(entity.Street, entity.Number, entity.Id))
            {
                response.IsError = true;
                response.ErrorCodes.Add("Address Already Exist");
                return response;
            }

            _repository.Edit(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            var oldAddress = _repository.GetById(id);

            if (oldAddress.Payments.Count() > 0)
            {
                response.IsError = true;
                response.ErrorCodes.Add("Payment already exist for this Address, it can't be deleted.");
                return response;
            }

            _repository.Delete(id);

            return response;
        }
    }
}