using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScriptGenerator.Tests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void Column_CreateNew()
        {
            //Arrange / Act
            var column = TestConstants.MockColumn();

            //Assert
            Assert.AreEqual(TestConstants.NameColumn, column.Name);
            Assert.AreEqual(TestConstants.Schema, column.TableSchema);
            Assert.AreEqual(TestConstants.NameTable, column.TableName);
            Assert.AreEqual(TestConstants.Type, column.DataType);
            Assert.AreEqual(TestConstants.DataLength, column.DataLength);
            Assert.AreEqual(TestConstants.isNullable, column.IsNullable);
            Assert.AreEqual(TestConstants.HasPrimaryKey, column.HasPrimaryKeyConstraint);
            Assert.AreEqual(TestConstants.HasUnique, column.HasUniqueConstraint);
            Assert.AreEqual(TestConstants.HasForeignKey, column.HasForeignKeyConstraint);
            Assert.AreEqual(TestConstants.DefaultValue, column.DefaultValue);
            Assert.AreEqual(TestConstants.CommentColumn, column.Comment);
        }

        [TestMethod]
        public void Constraint_CreateNew()
        {
            //Arrange / act
            var constraint = TestConstants.MockConstraint();

            //Assert
            Assert.AreEqual(TestConstants.NameConstraint, constraint.Name);
            Assert.AreEqual(TestConstants.Schema, constraint.Schema);
            Assert.AreEqual(TestConstants.NameTableColumn, constraint.TableColumnName);
            Assert.AreEqual(TestConstants.NameTable, constraint.TableName);
            Assert.AreEqual(TestConstants.TableSpace, constraint.TableSpace);
        }

        [TestMethod]
        public void ConstraintForeignKey_CreateNew()
        {
            //Arrange / act
            var foreignKey = TestConstants.MockConstraintForeignKey();

            //Assert
            Assert.AreEqual(TestConstants.NameConstraint, foreignKey.Name);
            Assert.AreEqual(TestConstants.Schema, foreignKey.Schema);
            Assert.AreEqual(TestConstants.NameTableColumn, foreignKey.TableColumnName);
            Assert.AreEqual(TestConstants.ReferencedSchemaName, foreignKey.ReferencedTableSchemaName);
            Assert.AreEqual(TestConstants.ReferencedTableName, foreignKey.ReferencedTableName);
            Assert.AreEqual(TestConstants.ReferencedColumnName, foreignKey.ReferencedTableColumnName);
            Assert.AreEqual(null, foreignKey.TableSpace);
        }

        [TestMethod]
        public void Sequence_CreateNew()
        {
            //Arrange / Act
            var sequence = TestConstants.MockSequence();

            //Assert
            Assert.AreEqual(TestConstants.NameSequence, sequence.Name);
            Assert.AreEqual(TestConstants.Schema, sequence.Schema);
            Assert.AreEqual(TestConstants.StartsWith, sequence.StartWith);
            Assert.AreEqual(TestConstants.IncrementBy, sequence.IncrementBy);
        }

        [TestMethod]
        public void Table_CreateNew()
        {
            //Arrange / Act
            var table = TestConstants.MockTable();

            //Assert
            Assert.AreEqual(TestConstants.NameTable, table.Name);
            Assert.AreEqual(TestConstants.Schema, table.Schema);
            Assert.AreEqual(TestConstants.CommentTable, table.Comment);
            Assert.AreEqual(TestConstants.TableSpace, table.TableSpace);
        }

        [TestMethod]
        public void Trigger_CreateNew()
        {
            //Arrange / Act
            var trigger = TestConstants.MockTrigger();

            //Assert
            Assert.AreEqual(TestConstants.Schema, trigger.Schema);
            Assert.AreEqual(TestConstants.NameTrigger, trigger.Name);
            Assert.AreEqual(TestConstants.NameTable, trigger.TableName);
        }
    }
}
