using System;
using System.Collections.Generic;

namespace ScriptGenerator.Models
{
    /// <summary>
    /// Non visual setting model
    /// </summary>
    public class NonVisualSetting
    {
        /// <summary>
        /// A name of non visual setting for all the rest of the values
        /// </summary>
        public static readonly string Else = "Else";

        /// <summary>
        /// Non visual setting name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Dictionary of clients and values that should be assigned to the clients
        /// </summary>
        public Dictionary<string, string> Clients { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Creates a new non visual setting
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static NonVisualSetting CreateNew(String name)
        {
            return new NonVisualSetting()
            {
                Name = name
            };
        }
    }
}
