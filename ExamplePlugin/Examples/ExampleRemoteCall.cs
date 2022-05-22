﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LLNET.RemoteCall;
using LLNET.Logger;

namespace ExamplePlugin.Examples
{
    //piece of junk
    public class ExampleRemoteCall : IExample
    {

        static readonly Logger logger = new("ExampleRemoteCall");

        static void Test(bool val)
        {
            logger.warn.WriteLine(val);
        }

        public void Execute()
        {
            //double ExampleCall(int a1,bool a2,List<string> strArr)

            var succeed = RemoteCallAPI.ExportFunc(".NET", "ExampleCall", (args) =>
            {
                string a1 = args[0];
                bool a2 = args[1];
                double a3 = args[2];

                logger.warn.WriteLine($"a1:{a1},a2:{a2},a3:{a3}");

                return 233;
            });

            logger.warn.WriteLine(succeed);

            var func = RemoteCallAPI.ImportFunc(".NET", "ExampleCall");
            var ret = func(new() { "string", true, 233.33 });
            double d = ret;

            logger.info.WriteLine($"ReturnVal:{d}");
        }
    }
}
