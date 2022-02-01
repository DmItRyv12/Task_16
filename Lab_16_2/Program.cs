﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;


namespace Lab_16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string JsonString;
            using (StreamReader sr = new StreamReader("C:/Users/asus/Desktop/Обучение/Автоматизация BIM/Задание 16/Products.json"))
            {
                JsonString = Convert.ToString(sr.ReadLine());
            }
            Console.WriteLine(JsonString);
            Products products = JsonSerializer.Deserialize<Products>(JsonString);
            double max = products.Many[0];
            double min = products.Many[0];
            int x = 0;
            int y = 0;
            foreach (double a in products.Many)
            {
                if (a > max)
                    max = a;
            }
            foreach (double b in products.Many)
            {
                if (b < min)
                    min = b;
            }
            for (int i = 0; i < products.Many.Length; i++)
            {
                if
                    (products.Many[i] == max)
                    x = i;
            }
            for (int i = 0; i < products.Many.Length; i++)
            {
                if
                    (products.Many[i] == min)
                    y = i;
            }
            Console.WriteLine($"Самый дорогой товар Код: {products.Kod[x]} Товар: {products.Name[x]} Цена: {products.Many[x]}");
            Console.WriteLine($"Самый дешовый товар Код: {products.Kod[y]} Товар: {products.Name[y]} Цена: {products.Many[y]}");
            Console.ReadKey();
        }
        class Products
        {
            public int[] Kod { get; set; }
            public string[] Name { get; set; }
            public double[] Many { get; set; }

        }
    }
}
