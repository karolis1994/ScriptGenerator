using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptGenerator.Models;

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
            Assert.AreEqual(column.Name, TestConstants.ColumnName);
            Assert.AreEqual(column.TableSchema, TestConstants.Schema);
            Assert.AreEqual(column.TableName, TestConstants.TableName);
            Assert.AreEqual(column.DataType, TestConstants.Type);
            Assert.AreEqual(column.DataLength, TestConstants.DataLength);
            Assert.AreEqual(column.IsNullable, TestConstants.isNullable);
            Assert.AreEqual(column.HasPrimaryKeyConstraint, TestConstants.HasPrimaryKey);
            Assert.AreEqual(column.HasUniqueConstraint, TestConstants.HasUnique);
            Assert.AreEqual(column.HasForeignKeyConstraint, TestConstants.HasForeignKey);
            Assert.AreEqual(column.DefaultValue, TestConstants.DefaultValue);
            Assert.AreEqual(column.Comment, TestConstants.CommentColumn);
        }

        [TestMethod]
        public void Constraint_CreateNew()
        {
            //Arrange / act
            var constraint = TestConstants.MockConstraint();

            //Assert
            Assert.AreEqual(constraint.Name, TestConstants.ConstraintName);
            Assert.AreEqual(constraint.Schema, TestConstants.Schema);
            Assert.AreEqual(constraint.TableColumnName, TestConstants.TableColumn);
            Assert.AreEqual(constraint.TableName, TestConstants.TableName);
            Assert.AreEqual(constraint.TableSpace, TestConstants.TableSpace);
        }

        [TestMethod]
        public void ConstraintForeignKey_CreateNew()
        {
            //Arrange / act
            var foreignKey = TestConstants.MockConstraintForeignKey();

            //Assert
            Assert.AreEqual(foreignKey.Name, TestConstants.ConstraintName);
            Assert.AreEqual(foreignKey.Schema, TestConstants.Schema);
            Assert.AreEqual(foreignKey.TableColumnName, TestConstants.TableColumn);
            Assert.AreEqual(foreignKey.ReferencedTableSchemaName, TestConstants.ReferencedSchemaName);
            Assert.AreEqual(foreignKey.ReferencedTableName, TestConstants.ReferencedTableName);
            Assert.AreEqual(foreignKey.ReferencedTableColumnName, TestConstants.ReferencedColumnName);
            Assert.AreEqual(foreignKey.TableSpace, null);
        }

        [TestMethod]
        public void Sequence_CreateNew()
        {
            //Arrange / Act
            var sequence = TestConstants.MockSequence();

            //Assert
            Assert.AreEqual(sequence.Name, TestConstants.SequenceName);
            Assert.AreEqual(sequence.Schema, TestConstants.Schema);
            Assert.AreEqual(sequence.StartWith, TestConstants.StartsWith);
            Assert.AreEqual(sequence.IncrementBy, TestConstants.IncrementBy);
        }

        [TestMethod]
        public void Table_CreateNew()
        {
            //Arrange / Act
            var table = TestConstants.MockTable();

            //Assert
            Assert.AreEqual(table.Name, TestConstants.TableName);
            Assert.AreEqual(table.Schema, TestConstants.Schema);
            Assert.AreEqual(table.Comment, TestConstants.CommentTable);
            Assert.AreEqual(table.TableSpace, TestConstants.TableSpace);
        }
    }
}
