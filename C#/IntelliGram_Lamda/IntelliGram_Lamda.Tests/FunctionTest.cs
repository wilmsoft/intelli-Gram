using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using IntelliGram_Lamda;
using System.IO;
using System.Text;
using ImageRecordJson;

namespace IntelliGram_Lamda.Tests
{
    public class FunctionTest
    {
        private object id;

        [Fact]
        public async Task TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes("Hello World" ?? ""));
            string sut = await function.FunctionHandler(ms, context);

            Assert.Equal("HELLO WORLD", sut);
        }

        [Fact]
        public async Task TestSingleImageGet()
        {

            // Arrange 
            var function = new Function("bob");
            var context = new TestLambdaContext();
            ImageRecord expectedResult = new ImageRecord
            {
                Id = "bob",
                Image = "bla",
                Title = "Hello world"
            };

            // Act
            string id = "bob";
            string sut = function.GetImageByID(id);

            ImageRecord actualResult = ImageRecord.FromJson(sut);

            // Assert
            // Assert.Equal(expectedResult.Id, actualResult.Id);
            Assert.True(expectedResult.Equals(actualResult));
        }
    }
}
