﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace P4GPayment.Domain
{
    [Table("StreetNumber")]
    public class StreetNumber
    {
        [Key]
        public int Id { get; set; }

        public string Number { get; set; }
    }
}