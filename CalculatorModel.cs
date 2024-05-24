using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1.Models;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Поле Operand1 обязательно для заполнения")]
        public int Operand1 { get; set; }

        [Compare("Operand1", ErrorMessage = "Operand2 должен быть равен Operand1")]
        public int Operand2 { get; set; }

        public string Operation { get; set; }
        public int Result { get; set; }
    }
}