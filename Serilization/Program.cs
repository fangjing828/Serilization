using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serilization
{
    public class JsonSerilization
    {
        public static T JsonString2Object<T>(string jsonString) where T : class
        {
            T instance = Activator.CreateInstance<T>();
            return instance;
        }

        public static string Object2JsonString(object instance)
        {
            string jsonString = string.Empty;

            if (instance.GetType().IsClass)
            {
            }

            return jsonString;
        }
    }
}
