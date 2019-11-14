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
            Assert.AreEqual(TestConstants.ColumnName, column.Name);
            Assert.AreEqual(TestConstants.Schema, column.TableSchema);
            Assert.AreEqual(TestConstants.TableName, column.TableName);
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
            Assert.AreEqual(TestConstants.ConstraintName, constraint.Name);
            Assert.AreEqual(TestConstants.Schema, constraint.Schema);
            Assert.AreEqual(TestConstants.TableColumn, constraint.TableColumnName);
            Assert.AreEqual(TestConstants.TableName, constraint.TableName);
            Assert.AreEqual(TestConstants.TableSpace, constraint.TableSpace);
        }

        [TestMethod]
        public void ConstraintForeignKey_CreateNew()
        {
            //Arrange / act
            var foreignKey = TestConstants.MockConstraintForeignKey();

            //Assert
            Assert.AreEqual(TestConstants.ConstraintName, foreignKey.Name);
            Assert.AreEqual(TestConstants.Schema, foreignKey.Schema);
            Assert.AreEqual(TestConstants.TableColumn, foreignKey.TableColumnName);
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
            Assert.AreEqual(TestConstants.SequenceName, sequence.Name);
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
            Assert.AreEqual(TestConstants.TableName, table.Name);
            Assert.AreEqual(TestConstants.Schema, table.Schema);
            Assert.AreEqual(TestConstants.CommentTable, table.Comment);
            Assert.AreEqual(TestConstants.TableSpace, table.TableSpace);
        }
    }
}
