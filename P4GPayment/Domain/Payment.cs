using P4GPayment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace P4GPayment.Domain
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Duration { get; set; }

        public byte[] Evidence { get; set; }

        public int PayeeId { get; set; }

        [ForeignKey("PayeeId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }
}