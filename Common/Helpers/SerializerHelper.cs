using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Helpers
{
    public static class SerializerHelper
    {
        public static string SerializeObjToJson(object obj)
        {
            string jsonText = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return jsonText;
        }
        public static void SerializeObjToJsonFile(string targetFilePath, object obj)
        {
            string jsonString = SerializeObjToJson(obj);
            File.WriteAllText(targetFilePath, jsonString);
        }
        public static T DeserializeJsonText<T>(string jsonText) where T : class
        {
            T obj = JsonConvert.DeserializeObject<T>(jsonText);
            return obj;
        }

        public static T DeserializeJsonFile<T>(string filePath) where T : class
        {
            string jsonText = File.ReadAllText(filePath);
            T obj = JsonConvert.DeserializeObject<T>(jsonText);
            return obj;
        }

        public static string SerializeObjToJsonEnumsAsStrings(object obj)
        {
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            string jsonText = JsonConvert.SerializeObject(obj, Formatting.Indented, jsonSerializerSettings);
            return jsonText;
        }
        public static void SerializeObjToJsonFileEnumsAsStrings(string targetFilePath, object obj)
        {
            string jsonString = SerializeObjToJsonEnumsAsStrings(obj);
            File.WriteAllText(targetFilePath, jsonString);
        }

        public static string SerializeToJsonIgnoreExceptions(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Error = (serializer, err) =>
            {
                err.ErrorContext.Handled = true;
            };
            string res = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            return res;
        }

        public static string SerializeToJsonHandleAbstraction(object obj)
        {
            Type type = obj.GetType();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            //using (StreamWriter sw = new StreamWriter(settingsFilePath))
            string jsonText = "";
            using (TextWriter tw = new StringWriter())
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(tw))
            {
                serializer.Serialize(writer, obj, type);
                jsonText = tw.ToString();
            }
            return jsonText;

        }
        public static void SerializeToJsonFileHandleAbstraction(string targetFilePath, object obj)
        {
            string jsonString = SerializeToJsonHandleAbstraction(obj);
            File.WriteAllText(targetFilePath, jsonString);
        }

        public static T DeserializeJsonHandleAbstraction<T>(string jsonText) where T : class
        {

            T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonText, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            });
            return obj;

        }

        public static T DeserializeJsonFileHandleAbstraction<T>(string jsonFilePath) where T : class
        {
            string jsonText = File.ReadAllText(jsonFilePath);
            return DeserializeJsonHandleAbstraction<T>(jsonText);
        }

        public static bool SerializeXmlToFile(object obj, string filePath)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            StringWriter sww = new StringWriter();
            xs.Serialize(sww, obj);
            using (var sw = new StreamWriter(filePath, false))
            {
                sw.Write(sww.ToString());
            }
            sww.Dispose();
            return true;
        }

        public static T DeserializeFromXmlFile<T>(string filePath) where T : class
        {

            XmlSerializer xs = new XmlSerializer(typeof(T));
            object obj;
            using (StreamReader sr = new StreamReader(filePath))
            {
                obj = xs.Deserialize(sr);
            }

            return (T)obj;
        }


       

        
    }
}
