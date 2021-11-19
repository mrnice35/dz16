using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace dz16
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] product = new Product[5];//Создаем массив из пяти продуктов
            for (int i = 0; i < 5; i++)
            {
                product[i] = new Product();

                Console.WriteLine("Введите код товара {0}:", i + 1);
                product[i].code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара {0}:", i + 1);
                product[i].name = Console.ReadLine();
                Console.WriteLine("Введите цену товара {0}:", i + 1);
                product[i].price = Convert.ToInt32(Console.ReadLine());

                string jsonString = JsonSerializer.Serialize(product);//Сериализуем его JSON строку
                string path = "Logs/Products.json"; //путь к файлу
                using (StreamWriter sw = new StreamWriter(path, false))//Сохраняем значения в строку (Folse-перезапись файла)
                {
                    sw.WriteLine(jsonString);
                }
                Console.ReadKey();


            }

        }
        class Product //создаем класс
        {
            public int code { get; set; }
            public string name { get; set; }
            public double price { get; set; }
        }
    }

}
