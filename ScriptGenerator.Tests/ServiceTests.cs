using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptGenerator.Models;
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

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_TableNotNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            var table = TestConstants.MockTable();

            //Act
            var script = scriptGenerator.GenerateCreationScript(table).Result;

            //Assert
            Assert.IsNotNull(script);
        }

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_TableNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            Table table = null;

            //Act
            var script = scriptGenerator.GenerateCreationScript(table).Result;

            //Assert
            Assert.AreEqual(string.Empty, script);
        }

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_ColumnNotNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            var column = TestConstants.MockColumn();

            //Act
            var script = scriptGenerator.GenerateCreationScript(column).Result;

            //Assert
            Assert.IsNotNull(script);
        }

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_ColumnNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            Column column = null;

            //Act
            var script = scriptGenerator.GenerateCreationScript(column).Result;

            //Assert
            Assert.AreEqual(string.Empty, script);
        }

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_SequenceNotNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            var sequence = TestConstants.MockSequence();

            //Act
            var script = scriptGenerator.GenerateCreationScript(sequence).Result;

            //Assert
            Assert.IsNotNull(script);
        }

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_SequenceNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            Sequence sequence = null;

            //Act
            var script = scriptGenerator.GenerateCreationScript(sequence).Result;

            //Assert
            Assert.AreEqual(string.Empty, script);
        }

        [TestMethod]
        public void Versioning_ValidateVersion_Valid()
        {
            //Arrange
            var versioningSerivce = new VersioningService();

            //Act
            versioningSerivce.ValidateVersion(TestConstants.CustomVersion);
        }

        [TestMethod]
        public void Versioning_ValidateVersion_NotValid()
        {
            //Arrange
            var versioningSerivce = new VersioningService();

            //Act / Assert
            Assert.ThrowsException<ArgumentException>(() => versioningSerivce.ValidateVersion("dasd"));
        }

        [TestMethod]
        public void Versioning_ChangeVersions_AssemblyVersion_Major()
        {
            //Arrange
            IVersioningService versioningService = new VersioningService();
            var currentVersion = TestConstants.RegexAssemblyVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;
            int.TryParse(currentVersion.Split('.')[0], out var currentMajorVersion);

            //Act
            versioningService.ChangeVersions(TestConstants.PathResources(), false, true).Wait();

            //Assert
            var changedVersion = TestConstants.RegexAssemblyVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;
            int.TryParse(changedVersion.Split('.')[0], out var changedMajorVersion);

            Assert.IsTrue(changedMajorVersion == currentMajorVersion + 1);
        }

        [TestMethod]
        public void Versioning_ChangeVersions_AssemblyVersion_Minor()
        {
            //Arrange
            IVersioningService versioningService = new VersioningService();
            var currentVersion = TestConstants.RegexAssemblyVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;
            int.TryParse(currentVersion.Split('.')[1], out var currentMinorVersion);

            //Act
            versioningService.ChangeVersions(TestConstants.PathResources(), true, false).Wait();

            //Assert
            var changedVersion = TestConstants.RegexAssemblyVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;
            int.TryParse(changedVersion.Split('.')[1], out var changedMinorVersion);

            Assert.IsTrue(changedMinorVersion == currentMinorVersion + 1);
        }

        [TestMethod]
        public void Versioning_ChangeVersions_AssemblyFileVersion_Major()
        {
            //Arrange
            IVersioningService versioningService = new VersioningService();
            var currentVersion = TestConstants.RegexAssemblyFileVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;
            int.TryParse(currentVersion.Split('.')[0], out var currentMajorVersion);

            //Act
            versioningService.ChangeVersions(TestConstants.PathResources(), false, true).Wait();

            //Assert
            var changedVersion = TestConstants.RegexAssemblyFileVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;
            int.TryParse(changedVersion.Split('.')[0], out var changedMajorVersion);

            Assert.IsTrue(changedMajorVersion == currentMajorVersion + 1);
        }

        [TestMethod]
        public void Versioning_ChangeVersions_AssemblyFileVersion_Minor()
        {
            //Arrange
            IVersioningService versioningService = new VersioningService();
            var currentVersion = TestConstants.RegexAssemblyFileVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;
            int.TryParse(currentVersion.Split('.')[1], out var currentMinorVersion);

            //Act
            versioningService.ChangeVersions(TestConstants.PathResources(), true, false).Wait();

            //Assert
            var changedVersion = TestConstants.RegexAssemblyFileVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;
            int.TryParse(changedVersion.Split('.')[1], out var changedMinorVersion);

            Assert.IsTrue(changedMinorVersion == currentMinorVersion + 1);
        }

        [TestMethod]
        public void Versioning_ChangeVersions_AssemblyFileVersion_Custom()
        {
            //Arrange
            IVersioningService versioningService = new VersioningService();

            //Act
            versioningService.ChangeVersions(TestConstants.PathResources(), TestConstants.CustomVersion).Wait();

            //Assert
            var changedVersion = TestConstants.RegexAssemblyFileVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;

            Assert.AreEqual(TestConstants.CustomVersion, changedVersion);
        }

        [TestMethod]
        public void Versioning_ChangeVersions_AssemblyVersion_Custom()
        {
            //Arrange
            IVersioningService versioningService = new VersioningService();

            //Act
            versioningService.ChangeVersions(TestConstants.PathResources(), TestConstants.CustomVersion).Wait();

            //Assert
            var changedVersion = TestConstants.RegexAssemblyVersion.Match(File.ReadAllText(TestConstants.PathResourceAssemblyInfo())).Value;

            Assert.AreEqual(TestConstants.CustomVersion, changedVersion);
        }
    }
}
