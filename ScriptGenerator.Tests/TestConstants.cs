using ScriptGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScriptGenerator.Tests
{
    public static class TestConstants
    {
        public const string Schema = "Schema";
        public const string TableName = "TableName";
        public const string SequenceName = "SequenceName";
        public const string ColumnName = "ColumnName";
        public const string ConstraintName = "ConstraintName";
        public const string ReferencedSchemaName = "ReferencedSchema";
        public const string ReferencedTableName = "ReferencedTable";
        public const string ReferencedColumnName = "ReferencedColumn";
        public const string CommentColumn = "CommentColumn";
        public const string CommentTable = "CommentTable";
        public const string TableColumn = "TableColumn";
        public const string TableSpace = "TableSpace";
        public const string DefaultValue = null;
        public const int DataLength = 20;
        public const int StartsWith = 1;
        public const int IncrementBy = 1;
        public const DataType Type = DataType.Number;
        public const bool HasPrimaryKey = false;
        public const bool HasForeignKey = false;
        public const bool HasUnique = false;
        public const bool isNullable = false;

        public static Table MockTable() => Table.CreateNew(
            TableName,
            Schema,
            CommentTable,
            TableSpace,
            new HashSet<Column>());
        public static Sequence MockSequence() => Sequence.CreateNew(
            SequenceName,
            Schema,
            StartsWith,
            IncrementBy);
        public static Column MockColumn() => Column.CreateNew(
            Schema,
            TableName,
            ColumnName,
            Type, 
            DataLength,
            DefaultValue,
            isNullable,
            CommentColumn,
            HasPrimaryKey,
            null,
            HasUnique,
            null,
            HasForeignKey,
            null);
        public static Constraint MockConstraint() => Constraint.CreateNew(
            Schema,
            ConstraintName,
            TableName,
            TableColumn,
            TableSpace);
        public static ConstraintForeignKey MockConstraintForeignKey() => ConstraintForeignKey.CreateNew(
            Schema,
            ConstraintName,
            TableName,
            TableColumn, 
            ReferencedSchemaName,
            ReferencedTableName, 
            ReferencedColumnName, 
            null);

        public static string PathResources() => Directory.GetCurrentDirectory() + "\\Resources";
        public static string PathResourceAssemblyInfo() => Directory.GetCurrentDirectory() + "\\Resources\\AssemblyInfo.cs";
        public static string PathResourceCharset() => Directory.GetCurrentDirectory() + "\\Resources\\TestCharset.txt";
        public static string PathResourceCharsetIncorrect() => Directory.GetCurrentDirectory() + "\\Resources\\TestCharsetsdasdasd.txt";
        public const string CharsetTestResult = "' || chr(1) || '";

        public static Regex RegexAssemblyVersion = new Regex("(?<=AssemblyVersion\\(\")\\d+.\\d+.\\d+.\\d+(?=\"\\)\\])");
        public static Regex RegexAssemblyFileVersion = new Regex("(?<=AssemblyFileVersion\\(\")\\d+.\\d+.\\d+.\\d+(?=\"\\)\\])");
        public const string CustomVersion = "1.0.0.0";
    }
}
