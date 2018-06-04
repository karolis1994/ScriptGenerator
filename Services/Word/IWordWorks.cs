using System;
using System.Collections.Generic;

namespace Services
{
    public interface IWordWorks
    {
        Dictionary<String, Int32> GetClientSettings(String clientName, String filePath);
    }
}
