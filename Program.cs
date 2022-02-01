﻿using System;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.IO;



namespace Lab_16
{
    class Program
    {
        static void Main(string[] args)
        {
            int z = 5; 
            int[] kod = new int[z];
            string[] name = new string[z];
            double[] many = new double[z];
            for (int i = 0; i < z; i++)
            {
                Console.WriteLine("Введите код товара (целое число)");
                kod[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара (строка)");
                name[i] = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите цену товара (вещественное число)");
                many[i] = Convert.ToDouble(Console.ReadLine());
            }
            Products products = new Products()
            {
                Kod = kod,
                Name = name,
                Many = many
            };
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            string JsonString = JsonSerializer.Serialize(products, options);
            Console.WriteLine(JsonString);
            using (StreamWriter sw = new StreamWriter("C:/Users/asus/Desktop/Обучение/Автоматизация BIM/Задание 16/Products.json"))
            {
                sw.WriteLine(JsonString);
            }
            Console.ReadKey();
        }
    }
    class Products
    {
        public int[] Kod { get; set; }
        public string[] Name { get; set; }
        public double[] Many { get; set; }
    }
}