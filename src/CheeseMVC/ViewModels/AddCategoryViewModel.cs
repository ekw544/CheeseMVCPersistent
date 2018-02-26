using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage = "You must give a name for the category")]
        //did not explicity say to include error message, but added anyway
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
