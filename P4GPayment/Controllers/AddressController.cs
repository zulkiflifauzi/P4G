using P4GPayment.Domain;
using P4GPayment.Logic;
using P4GPayment.Models;
using P4GPayment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P4GPayment.Controllers
{
    public class AddressController : Controller
    {
        private AddressLogic _addressLogic = new AddressLogic();
        private UserLogic _userLogic = new UserLogic();
        private StreetNumberLogic _streetNumberLogic = new StreetNumberLogic();
        // GET: Address
        public ActionResult Index()
        {
            var addresses = _addressLogic.GetAll();
            List<AddressViewModel> results = new List<AddressViewModel>();

            foreach (var item in addresses)
            {
                AddressViewModel result = new AddressViewModel() { Id = item.Id, Street = item.Street, OwnerId = item.OwnerId.HasValue ? item.OwnerId.Value : 0, OwnerName = item.ApplicationUser != null ? item.ApplicationUser.FirstName + " " + item.ApplicationUser.LastName : string.Empty, Number = item.Number };
                results.Add(result);
            }

            return View(results);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            PrepareSelectList();
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(AddressViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                Address address = new Address() { Street = model.Street, OwnerId = model.OwnerId, Number = model.Number };
                var response = _addressLogic.Create(address);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList();
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            PrepareSelectList();
            var entity = _addressLogic.GetById(id);
            AddressViewModel result = new AddressViewModel() { Id = entity.Id, Street = entity.Street, OwnerId = entity.OwnerId.HasValue ? entity.OwnerId.Value : 0, OwnerName = entity.ApplicationUser != null ? entity.ApplicationUser.FirstName + " " + entity.ApplicationUser.LastName : string.Empty, Number = entity.Number };
            return View(result);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AddressViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                Address address = new Address() { Street = model.Street, OwnerId = model.OwnerId, Number = model.Number, Id = model.Id };
                
                var response = _addressLogic.Edit(address); ;
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList();
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _addressLogic.GetById(id);
            AddressViewModel result = new AddressViewModel() { Id = entity.Id, Street = entity.Street, OwnerId = entity.OwnerId.HasValue ? entity.OwnerId.Value : 0, OwnerName = entity.ApplicationUser != null ? entity.ApplicationUser.FirstName + " " + entity.ApplicationUser.LastName : string.Empty, Number = entity.Number };
            return View(result);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(AddressViewModel model)
        {
            try
            {
                var response = _addressLogic.Delete(model.Id); ;
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    var entity = _addressLogic.GetById(model.Id);
                    AddressViewModel result = new AddressViewModel() { Id = entity.Id, Street = entity.Street, OwnerId = entity.OwnerId.HasValue ? entity.OwnerId.Value : 0, OwnerName = entity.ApplicationUser != null ? entity.ApplicationUser.FirstName + " " + entity.ApplicationUser.LastName : string.Empty, Number = entity.Number };
                    return View(result);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                var entity = _addressLogic.GetById(model.Id);
                AddressViewModel result = new AddressViewModel() { Id = entity.Id, Street = entity.Street, OwnerId = entity.OwnerId.HasValue ? entity.OwnerId.Value : 0, OwnerName = entity.ApplicationUser != null ? entity.ApplicationUser.FirstName + " " + entity.ApplicationUser.LastName : string.Empty, Number = entity.Number };
                return View(result);
            }
        }

        private void PrepareSelectList()
        {
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in _userLogic.GetAll())
            {
                userList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FirstName + " " + item.LastName });
            }
            ViewData["Users"] = userList;

            List<SelectListItem> streetNumberList = new List<SelectListItem>();
            foreach (var item in _streetNumberLogic.GetAll())
            {
                streetNumberList.Add(new SelectListItem { Value = item.Number.ToString(), Text = item.Number });
            }
            ViewData["StreetNumbers"] = streetNumberList;

            List<SelectListItem> freeUserList = new List<SelectListItem>();
            foreach (var item in _userLogic.GetFreeUsers())
            {
                freeUserList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FirstName + " " + item.LastName });
            }
            ViewData["FreeUsers"] = freeUserList;
        }
    }
}
