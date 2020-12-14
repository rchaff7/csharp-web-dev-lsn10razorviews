using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Required(ErrorMessage = "Location is required.")]
        public string EventLocation { get; set; }
        [Range(0, 100000, ErrorMessage = "This number must be between 0 and 100,000.")]
        public int NumberOfAttendees { get; set; }
        [Compare("IsTrue", ErrorMessage = "Box must be checked.")]
        public bool MustRegister { get; set; }
        public bool IsTrue { get { return true; } }


    }
}
