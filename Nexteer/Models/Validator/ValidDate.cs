﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nexteer.Models
{
    public class ValidDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime result;
            if (value == null)
            {
                return true;
            }
            else if (DateTime.TryParse(value.ToString(), out result))
            {
                return true;
            }

            return false;
        }
    }
}