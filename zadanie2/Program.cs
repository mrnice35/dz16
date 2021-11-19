using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace dz16
{
    class Program
    {
        static void Main(string[] args)
        {
            double max = 0; //переменная для хранения стоимости
            int index = 0; //переменная для хранения индекса
            string path = "C:/Users/Vasiliy/source/repos/dz16/dz16/bin/Debug/Logs/Products.json";//путь к нужному файлу
            using (StreamReader sr = new StreamReader(path))//Чтения файла
            {
                string s = sr.ReadToEnd();// считывает весь текст из файла и передает значение строке S
                Product[] product = JsonSerializer.Deserialize<Product[]>(s);//Десериализация массива файлов из JSON
                for (int i = 0; i < 5; i++)//Цикл перебирающий массив продуктов
                {
                    if (max <= product[i].price)//цикл ищущий самую большую цену
                    {
                        max = product[i].price;//присваиваем значению max самую большую цену из массива
                        index = i;//присваиваем индексу значение индекса массива
                    }
                }
                Console.WriteLine("Самая большая стоимость равна {0}", max);
                Console.WriteLine("У продукта {0}", product[index].name);
                Console.ReadKey();
            }
        }
    }
    class Product //создаем класс
    {
        public int code { get; set; }//поля класса
        public string name { get; set; }
        public double price { get; set; }
    }
}




