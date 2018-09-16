using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoadName.Models
{
    public enum District
    {
        Ampara,
        Anuradhapura,
        Badulla,
        Batticaloa,
        Colombo,
        Galle,
        Gampaha,
        Hambantota,
        Jaffna,
        Kalutara,
        Kandy,
        Kegalle,
        Kilinochchi,
        Kurunegala,
        Mannar,
        Matale,
        Matara,
        Moneragala,
        Mullaitivu,
        [Display(Name = "Nuwara Eliya")]
        NuwaraEliya,
        Polonnaruwa,
        Puttalam,
        Ratnapura,
        Trincomalee,
        Vavuniya
    }
    public class Roadname
    {
        public int Id { get; set; }

        [DisplayName("Your Account ID")]
        public string ApplicationUserId { get; set; }

        [Required]
        [Display(Name =" Name Of the Road (Ex: Queen's Road)")]
        public string NameOfRoad { get; set; }

        [Required]
        [Display(Name = "District")]
        public District District { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Loaction")]
        public string Location { get; set; }

        [Display(Name = "Fill the Famouse People's Name(Ex : Minister, Writers, Sportments, Actors..etc)")]
        public string VIPName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Based Story of Road")]
        public string Story { get; set; }

        public virtual ApplicationUser user { get; set; }
    }
}