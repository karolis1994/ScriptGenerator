using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptGenerator.Services;
using System;
using System.IO;

namespace ScriptGenerator.Tests
{
    [TestClass]
    public class VersioningTests
    {
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
