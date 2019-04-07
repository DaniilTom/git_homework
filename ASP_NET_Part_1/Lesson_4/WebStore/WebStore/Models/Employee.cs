using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Employee
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Имя"), Required(ErrorMessage = "Имя является обязательным")]
        [MinLength(3)]
        public string FirstName { get; set; }

        //[RegularExpression()] [DataType]

        [Display(Name = "Фамилия"), Required(ErrorMessage = "Фамилия является обязательной")]
        [MinLength(2)]
        public string SurName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст")]
        [Range(18, 120)]
        public int Age { get; set; }


        public string Dossier { get; set; }
    }
}
