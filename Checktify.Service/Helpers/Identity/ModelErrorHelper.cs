using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Checktify.Service.Helpers.Identity
{
    public static class ModelErrorHelper
    {
        public static void AddModelErrorsList(this ModelStateDictionary modelState, List<string> erorrs)
        {
            foreach (var error in erorrs)
            {
                modelState.AddModelError(string.Empty, error);
            }
        }

        public static void AddModelErrorsList(this ModelStateDictionary modelState, IEnumerable<IdentityError> errors)
        {
            errors.ToList().ForEach(x => modelState.AddModelError(string.Empty, x.Description));
        }
    }
}
