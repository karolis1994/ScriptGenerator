using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptGenerator.Models;
using ScriptGenerator.Services;

namespace ScriptGenerator.Tests
{
    [TestClass]
    public class ScriptGeneratorTests
    {
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
        public void ScriptGenerator_GenerateCreationScript_TriggerNotNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            var trigger = TestConstants.MockTrigger();

            //Act
            var script = scriptGenerator.GenerateCreationScript(trigger).Result;

            //Assert
            Assert.IsNotNull(script);
        }

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_TriggerNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            Trigger trigger = null;

            //Act
            var script = scriptGenerator.GenerateCreationScript(trigger).Result;

            //Assert
            Assert.AreEqual(string.Empty, script);
        }

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_NonVisualSettingNotNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            var nonVisualSetting = TestConstants.MockNonVisualSetting();

            //Act
            var script = scriptGenerator.GenerateCreationScript(nonVisualSetting).Result;

            //Assert
            Assert.IsNotNull(script);
        }

        [TestMethod]
        public void ScriptGenerator_GenerateCreationScript_NonVisualSettingNull()
        {
            //Arrange
            IScriptGenerationService scriptGenerator = new ScriptGenerationService();
            NonVisualSetting nonVisualSetting = null;

            //Act
            var script = scriptGenerator.GenerateCreationScript(nonVisualSetting).Result;

            //Assert
            Assert.AreEqual(string.Empty, script);
        }
    }
}
