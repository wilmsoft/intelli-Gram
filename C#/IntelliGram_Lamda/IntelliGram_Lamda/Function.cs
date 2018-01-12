using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using System.IO;
using ImageRecordJson;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace IntelliGram_Lamda
{
    public class Function
    {
        private string mystring;
        public Function()
        {
            mystring = "default";
        }

        public Function(string what)
        {
            mystring = "what";
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(Stream request, ILambdaContext context)
        {
            mystring = mystring + "yep";

            StreamReader reader = new StreamReader(request);
            string readerAsString = await reader.ReadToEndAsync();
            return readerAsString?.ToUpper();
        }

        public string GetImageByID(string id)
        {
            ImageRecord expectedResult = new ImageRecord
            {
                Id = "phile",
                Image = "bla",
                Title = "Hello world"
            };

            return expectedResult.ToJson();
        }
    }
    }
