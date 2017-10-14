using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GosDumaApiIntegration;
using GosDumaApiIntegration.Model;
using System.IO;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var duma = new GosDuma("1a08505ef2dc61d5d785020aa28785da07cae308", "appe9d238832bc804bc783ee8fd90af00f8aa098cdb");
            var task=duma.GetDeputiesList(true, Deputy.DeputyPosition.Any);
            
            task.Wait();
            var deputies = task.Result;
            
            var deputyId = deputies.FirstOrDefault(deputy => deputy.Name.Contains("Жириновский")).Id;

            var task2 = duma.GetShorthandRecordByDeputyId(deputyId, DateTime.Parse("2017-01-01"), DateTime.Now);
            task2.Wait();
            var shorthand = task2.Result;

            using (FileStream fstream = new FileStream(@"C:\Users\123\Documents\GosDuma\ZhirinovskiyShorthand.txt", FileMode.OpenOrCreate))
            {                
                byte[] array = System.Text.Encoding.Default.GetBytes(shorthand);
                
                fstream.Write(array, 0, array.Length);                
            }

            Console.ReadLine();
        }
    }
}
