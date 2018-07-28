﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4GPayment.Base
{
    public class ResponseMessage
    {
        public bool IsError { get; set; }

        private List<string> _errorCodes = new List<string>();

        public List<string> ErrorCodes
        {
            get { return _errorCodes; }
            set { _errorCodes = value; }
        }
    }
}