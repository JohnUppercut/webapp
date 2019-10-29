using System;

namespace new_project.Models
{
    public class Knifes
    {
        public int l { get; set; } //length
        public int m { get; set; } //material
        public int f { get; set; } //form

        public double GetKnifePrice() // вычисление площади треугольника
        {
            return (l + f) * 300 + Math.Pow(m, 4) + f * 1000;
        }

    }
}