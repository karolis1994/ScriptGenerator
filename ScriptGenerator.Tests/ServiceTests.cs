using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptGenerator.Services;

namespace ScriptGenerator.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void OracleCharConverter_LoadCharset_CorrectPath()
        {
            //Arrange
            ICharConverterService converter = new OracleCharConverterService();

            //Act
            var task = converter.LoadCharset(Directory.GetCurrentDirectory() + TestConstants.CharsetTestRelativePath);
            var charset = task.Result;

            //Assert
            Assert.IsNotNull(charset);
        }

        [TestMethod]
        public void OracleCharConverter_LoadCharset_IncorrectPath()
        {
            //Arrange
            ICharConverterService converter = new OracleCharConverterService();
            var task = converter.LoadCharset(Directory.GetCurrentDirectory() + TestConstants.CharsetTestRelativePathIncorrect);

            //Act / Assert
            Assert.ThrowsException<ArgumentException>(() => task.GetAwaiter().GetResult());
        }

        [TestMethod]
        public void OracleCharConverter_ReplaceWithCharset()
        {
            //Arrange
            ICharConverterService converter = new OracleCharConverterService();
            _ = converter.LoadCharset(Directory.GetCurrentDirectory() + TestConstants.CharsetTestRelativePath).Result;
            var original = "ą";

            //Act
            var task = converter.ReplaceWithCharset(original);
            var result = task.Result;

            //Assert
            Assert.AreEqual(TestConstants.CharsetTestResult, result);
        }
    }
}
