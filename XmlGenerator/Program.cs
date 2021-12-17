using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Autotests.Models.Task;

namespace XmlGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = args[0];
            var count = Convert.ToInt32(args[1]);
            var filename = args[2];
            var format = args[3];
            if (type == "tasks")
            {
                GenerateForTasks(count, filename, format);
            }
            else
            {
                Console.Out.Write("Unrecognized type of data" + type);
            }
        }

        private static string GenerateRandomString(int length)
        {
            var random = new Random();
            return new string(
                Enumerable.Range(0, length)
                    .Select(x => (char) random.Next('a', 'z'))
                    .ToArray());
        }

        static void GenerateForTasks(int count, string filename, string format)
        {
            var tasks = new List<TaskData>();
            for (int i = 0; i < count; i++)
            {
                tasks.Add(new TaskData(GenerateRandomString(10)));
            }

            if (format == "xml")
            {
                var writer = new StreamWriter(filename);
                WriteGroupsToXmlFile(tasks, writer);
                writer.Close();
            }
            else
            {
                Console.Out.Write("Unrecognized format" + format);
            }

        }

        static void WriteGroupsToXmlFile(List<TaskData> tasks, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<TaskData>)).Serialize(writer, tasks);
        }
    }
}