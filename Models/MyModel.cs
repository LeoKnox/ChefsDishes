using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
    public class isPositiveAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {if ((int)value < 0)
            return new ValidationResult("Must be a postivie number.");
        return ValidationResult.Success;
        }
    }

    public class isEighteen : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime nowDate = DateTime.Now;
            DateTime diff2 = Convert.ToDateTime(value);
            int? diff3 = (int?) (nowDate - diff2).TotalDays;
            int? diz = diff3/365;
            {if (diz > 18)
                return new ValidationResult("no no no");
            return ValidationResult.Success;
            }
        }
    }
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}

        [Required]
        [Display(Name = "First Name")]
        public String FirstName {get; set;}

        [Required]
        [Display(Name = "Last Name")]
        public String LastName {get; set;}

        [Required]
        [isEighteen]
        [Display(Name = "Date of Birth")]
        public DateTime Dob {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

        public List<Dish> CreatedDishes {get; set;}

        [NotMapped]
        public int age 
        {
            get {
                return DateTime.Now.Year - Dob.Year;
            }
        }

        public Chef ()
        {

        }
    }

    public class Dish
    {
        [Key]
        public int DishId {get; set;}

        [Required]
        [MinLength(2)]
        [Display(Name = "Name of Dish")]
        public String DishName {get; set;}

        [Required]
        [isPositive]
        [Display(Name = "# of Calories")]
        public int Calories {get; set;}

        [Required]
        [Display(Name = "Description")]
        public String Description {get; set;}

        [Required]
        [Display(Name = "Tastiness")]
        public int Tastiness {get; set;}

        public int ChefId {get; set;}
        public Chef Creator {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

        public Dish ()
        {
            
        }
    }
}