using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using new_project.Models;

namespace new_project.Controllers
{
    public class LoginRegisterController : Controller
    {

        //обработка форм
        [HttpGet]
        public IActionResult CheckForms()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckForms(string Username, string Email, string Password, string RepeatPassword)
        {
            if(Password==RepeatPassword)
            {
                string RegisterFormData = $"Регистрация завершена! Имя пользователя: {Username},  E-mail: {Email}";
                return Content(RegisterFormData);
            }
            else
            {
                string RegisterFormData = $"Пароли не совпадают!";
                return Content(RegisterFormData);
            }

        }

        //метод возвращающий тип браузера
        public string Browser()
        {
            string userAgent = HttpContext.Request.Headers["User-Agent"];
            return $"Ваш браузер: {userAgent}";
        }
        public string[] getBrandsName()
        {
            string[] brandsNameArray = { "Металист", "Kizlyar Supreme", "Кизляр ПП", 
            "Mr.Blade", "Kizer Cutlery", "Tojiro", "Honor", "Victorinox" };
            return brandsNameArray;
        }

        public double[] getBrandsRate()
        {
            double[] brandsRateArray = { 6.7, 8.3, 1.9, 7.2, 6.1, 5.3, 9.9, 0.8 };
            return brandsRateArray;
        }


        //метод получающий один параметр
        public string BrandsName(int name)
        {
            if(name > 0)
            {
                string brand = getBrandsName()[name - 1];
                return $"Бренд ножей: {brand}";
            }
            else
            {
                return "Пожалуйста, введите корректное значение параметра 'name'";
            }
           
        }

        //метод получающий несколько параметров
        public string BrandsNameRate(int name, int ratemode)
        {
            string brandname = getBrandsName()[name - 1];

            if (ratemode == 1)
            {
                double brandrate = getBrandsRate()[name - 1];
                return $"Бренд ножей {brandname} имеет рейтинг {brandrate} из 10";
            }
            else return "Пожалуйста, выберите режим отображения рейтинга";
        
        }

        //метод получающий массив
        public string AllBrands(int[] num)
        {
            string allBrands = "";
            foreach (int i in num)
            {
                if (i > 0 & i < 9)
                {
                    allBrands += "Бренд ножей " + getBrandsName()[i - 1] + " имеет рейтинг " + getBrandsRate()[i - 1] + " из 10 \n";
                }
                else return "В базе содержится информация только о 8 брендах, выбирайте из них";
            }
            return $"Информация о всех брендах:\n{allBrands}";
        }

        //метод получающий объект
        public string KnifePrice(Knifes knifes)
        {
            if(knifes.l > 0 & knifes.l < 11 & knifes.m > 0 & knifes.m < 11 & knifes.f > 0 & knifes.f < 11)
            {
                return $"Цена ножа с длиной лезвия {knifes.l}, из материала {knifes.m}, и формой {knifes.f} будет равна {knifes.GetKnifePrice()} рублей";
            }
            else return "Все коэффициенты должны иметь значение от 0 до 10";
        }
    }
}