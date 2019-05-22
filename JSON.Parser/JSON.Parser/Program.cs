using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JSON.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            //string json = "[{\"Key1\" :{\"Sub-Key1\" : \"Sub-Value1\" ,\"Sub-Key2\" : \"Sub-Value2\" ,\"Sub-Key3\" : \"Sub-Value3\" ,}\"Key2\" :{\"Sub-Key1\" :[ { \"Sub-Sub-Key1\" : \"Val1\" } , { \"Sub-Sub-Key2\" : \"Val2\" }  ] ,\"Sub-Key2\" :[ { \"Sub-Sub-Key1\" : \"Val1\" } , { \"Sub-Sub-Key2\" : \"Val2\" }  ]}}]";
            //string json = "[{\"Key1\" : \"Value1\" ,\"Key2\" : \"Value2\"}]";
            string json = "[{\"Key1\" : \"1\" ,\"Key2\" : {\"key3\":\"1\",\"key4\":{\"key5\":\"4\"}}}]";
            Person a = new Person("William Henry", "Gates", null);
            Person b = new Person("Bill", "Gates", a);

            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            object obj = scriptSerializer.Deserialize(json, typeof(object));

            //foreach (var item in obj as object[])
            //{
            //    string val = Parse(item, 0);
            //    Console.WriteLine(val);
            //}

            foreach (var item in obj as object[])
            {
                string val = Parse(b, 0);
                Console.WriteLine(val);
            }
            Console.ReadKey();
        }

        public static string Parse(object obj, int depth)
        {
            string result = string.Empty;

            //if (obj.GetType() == typeof(object[]))
            //{
            //    foreach (var item in obj as object[])
            //    {

            //    }
            //}
            if (obj == null || obj.GetType() == typeof(string))
            {
                result += "";
            }
            else if (obj.GetType() == typeof(Dictionary<string, object>))
            {
                foreach (var item in (obj as Dictionary<string, object>).ToArray())
                {
                    result += ((KeyValuePair<string, object>)item).Key + " " + (depth + 1).ToString() + "\n";
                    result += Parse(((KeyValuePair<string, object>)item).Value, depth + 1);
                }
            }
            else if (obj.GetType() == typeof(Person))
            {
                result += (obj as Person)._firstname + " " + (depth + 1).ToString() + "\n";
                result += (obj as Person)._lastName + " " + (depth + 1).ToString() + "\n";
                result += (obj as Person)._father+ " " + (depth + 1).ToString() + "\n";
                result += Parse((obj as Person)._father, depth + 1);
            }
            else
            {
                result += "";
            }

            return result;
        }

        public class Person
        {
            public string _firstname, _lastName;
            public object _father;

            public Person(string firstName, string lastName, object father)
            {
                _firstname = firstName;
                _lastName = lastName;
                _father = father;
            }
        }

    }
}
