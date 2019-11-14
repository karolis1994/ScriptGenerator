using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptGenerator.Services;
using System;

namespace ScriptGenerator.Tests
{
    [TestClass]
    public class OracleCharConverterTests
    {
        [TestMethod]
        public void OracleCharConverter_LoadCharset_CorrectPath()
        {
            //Arrange
            ICharConverterService converter = new OracleCharConverterService();

            //Act
            var task = converter.LoadCharset(TestConstants.PathResourceCharset());
            var charset = task.Result;

            //Assert
            Assert.IsNotNull(charset);
        }

        [TestMethod]
        public void OracleCharConverter_LoadCharset_IncorrectPath()
        {
            //Arrange
            ICharConverterService converter = new OracleCharConverterService();
            var task = converter.LoadCharset(TestConstants.PathResourceCharsetIncorrect());

            //Act / Assert
            Assert.ThrowsException<ArgumentException>(() => task.GetAwaiter().GetResult());
        }

        [TestMethod]
        public void OracleCharConverter_ReplaceWithCharset()
        {
            //Arrange
            ICharConverterService converter = new OracleCharConverterService();
            _ = converter.LoadCharset(TestConstants.PathResourceCharset()).Result;
            var original = "ą";

            //Act
            var task = converter.ReplaceWithCharset(original);
            var result = task.Result;

            //Assert
            Assert.AreEqual(TestConstants.CharsetTestResult, result);
        }
    }
}
