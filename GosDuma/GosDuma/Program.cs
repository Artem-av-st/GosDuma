using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GosDumaApiIntegration;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var duma = new GosDuma("1a08505ef2dc61d5d785020aa28785da07cae308", "appe9d238832bc804bc783ee8fd90af00f8aa098cdb");
            var task=duma.GetDeputiesList(true);
            
            task.Wait();
            var result = task.Result;
        }
    }
}
