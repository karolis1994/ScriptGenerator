using System;
using System.Collections.Generic;

namespace ScriptGenerator.Services
{
    /// <summary>
    /// Interface to do various functions with a word document
    /// </summary>
    public interface IWordService
    {
        /// <summary>
        /// Retrieves a dictionary from non visual setting definitions document
        /// </summary>
        /// <param name="clientName">The name of the client for whom the setting values should be retrieved</param>
        /// <param name="filePath">The path to the file where the document is located</param>
        /// <returns></returns>
        Dictionary<string, int> GetClientSettings(string clientName, string filePath);
    }
}
