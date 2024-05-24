using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class CalculatorController : Controller
    {
        
        public ActionResult Index()
        {
            return View(new CalculatorModel());
        }
  
        private int CalculateResult(int operand1, int operand2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand2 != 0 ? operand1 / operand2 : 0; // Проверка деления на ноль
                default:
                    return 0;
            }
        }
        [HttpPost]
        public ActionResult Calculate(CalculatorModel model, string action)
        {
            if (action == "Очистить")
            {
                model.Operand1 = 0;
                model.Operand2 = 0;
                model.Operation = " ";
                model.Result = 0;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    switch (model.Operation)
                    {
                        case "+":
                            model.Result = model.Operand1 + model.Operand2;
                            break;
                        case "-":
                            model.Result = model.Operand1 - model.Operand2;
                            break;
                        case "*":
                            model.Result = model.Operand1 * model.Operand2;
                            break;
                        case "/":
                            if (model.Operand2 != 0)
                            {
                                model.Result = model.Operand1 / model.Operand2;
                            }
                            else
                            {
                                ViewBag.Message = "Деление на ноль недопустимо.";
                                return View("Index", model);
                            }
                            break;
                        default:
                            ViewBag.Message = "Неверная операция.";
                            return View("Index", model);
                    }
                }
            }

            ViewBag.Result = model.Result;
            ViewBag.Message = model.Result == Convert.ToDecimal(ViewBag.ClearValue) ? "Результат равен значению ClearValue!" : "Результат не равен значению ClearValue.";
            string message = ViewBag.Message;
            string wordedMessage = message.Replace("=", " равно ").PadRight(message.Length + 6);
            ViewBag.Message = wordedMessage;

            return View("Index", model);
        }
    
    }
}