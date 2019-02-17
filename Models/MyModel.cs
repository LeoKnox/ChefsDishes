using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsDishes.Models
{
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
        [Display(Name = "Date of Birth")]
        public DateTime Dob {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

        public List<Dish> CreatedDishes {get; set;}

        public Chef ()
        {

        }
    }

    public class Dish
    {
        [Key]
        public int DishId {get; set;}

        [Required]
        [Display(Name = "Name of Dish")]
        public String DishName {get; set;}

        [Required]
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