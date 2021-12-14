using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Helpers
{
    public static class PracticeMgtHelpers
    {
        public static IEnumerable<SelectListItem> GenderToSelectList()
        {
            var genderItems = EnumHelpers.ToSelectList(typeof(Gender)).ToList();
            genderItems.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            return genderItems;
        }

    }
}