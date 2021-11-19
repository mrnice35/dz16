using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;//добавляем пространство имен Json
using System.Text.Encodings.Web;
using System.Text.Unicode;


namespace hw16json
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = "{\"firstName\":\"Tom\",\"lastName\":\"Jackson\",\"gender\":\"male\",\"age\":29,\"online\":true,\"hobby\":[\"football\",\"reading\",\"swiming\"]}";// слышами экранируем строку
            Person person = JsonSerializer.Deserialize<Person>(jsonString);//экземпляр класса персон и вызываем класс JsonSerializer а затем метод Deserialize для преобразования строки в объект (в треугольных скобках ставим обобщенный тип Персон)
            Person person1 = new Person()
            {
                firstName = "Вася",
                lastName = "Васильев",
                gender = "муж",
                age = 30,
                online = false,
                hobby = new string[] { "футбол", "ПРОГРАММИРОВАНИЕ" }
            };
            JsonSerializerOptions options = new JsonSerializerOptions()//создаем для отображения русского языка экземпляр класса джейсон сериалайзер опшинс(до сериализации!!!)
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            string jsonString1 = JsonSerializer.Serialize(person1, options);
            Console.WriteLine(jsonString1);
            Console.ReadKey();
        }

    }
    class Person         //создаем класс с автосвойствамми
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public bool online { get; set; }
        public string[] hobby { get; set; }
    }
}