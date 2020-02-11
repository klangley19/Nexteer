using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nexteer.Models
{
    public class ValidBoolean : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result;
            if (value == null)
            {
                return true;
            }
            else if (bool.TryParse(value.ToString(), out result))
            {
                return true;
            }

            return false;
        }
    }
}