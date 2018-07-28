using P4GPayment.Context;
using P4GPayment.Logic.Interface;
using P4GPayment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P4GPayment.Models;
using P4GPayment.Base;

namespace P4GPayment.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly UserRepository _repository = new UserRepository(new ApplicationDbContext());
        private readonly AddressRepository _addressRepository = new AddressRepository(new ApplicationDbContext());

        public ResponseMessage Create(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAll()
        {
            return _repository.GetAll();
        }

        public ApplicationUser GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<ApplicationUser> GetFreeUsers()
        {
            var attachedUserIds = _addressRepository.GetAttachedUserIds();

            return _repository.GetFreeUsers(attachedUserIds);
        }

        public ResponseMessage Edit(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}