using P4GPayment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace P4GPayment.Domain
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Street { get;set; }

        [Required]
        public int Number { get; set; }

        public int? OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        private ICollection<int> _paymentIds;
        [NotMapped]
        public ICollection<int> PaymentIds
        {
            get { return _paymentIds ?? (_paymentIds = Payments.Select(s => s.Id).ToList()); }
            set { _paymentIds = value; }
        }

        private ICollection<Payment> _payments;
        public virtual ICollection<Payment> Payments
        {
            get { return _payments ?? (_payments = new Collection<Payment>()); }
            set { _payments = value; }
        }
    }
}