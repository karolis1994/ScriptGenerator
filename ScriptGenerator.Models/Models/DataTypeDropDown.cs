using System;
using System.Collections.Generic;

namespace ScriptGenerator.Models
{
    /// <summary>
    /// Data type dropdown model
    /// </summary>
    public class DataTypeDropDown
    {
        private DataTypeDropDown() { }

        private static IReadOnlyCollection<DataTypeDropDown> dropDownTypes;

        /// <summary>
        /// Drop down key
        /// </summary>
        public DataType Key { get; private set; }

        /// <summary>
        /// Drop down value
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Retrieve a list with all possible drop down values
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DataTypeDropDown> GetAllDropDownOptions()
        {
            if (dropDownTypes == null) {

                var list = new List<DataTypeDropDown>();

                foreach (var f in Enum.GetValues(typeof(DataType)))
                {
                    var e = (DataType)f;

                    list.Add(new DataTypeDropDown()
                    {
                        Key = e,
                        Value = Enum.GetName(typeof(DataType), e).ToUpper()
                    });
                }

                dropDownTypes = list;
            }

            return dropDownTypes;
        }
    }
}
