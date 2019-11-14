using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScriptGenerator.Services
{
    public class VersioningService : IVersioningService
    {
        private readonly Regex assemblyVersionRegex = new Regex("(?<=AssemblyVersion\\(\"|AssemblyFileVersion\\(\")\\d+.\\d+.\\d+.\\d+(?=\"\\)\\])");
        private readonly Regex versionRegex = new Regex("\\d+\\.\\d+\\.\\d+\\.\\d+");

        public async Task<string> ChangeVersions(string rootPath, bool increaseMinor, bool increaseMajor)
        {
            return await Task.Run(() =>
            {
                string[] files = Directory.GetFiles(rootPath, "AssemblyInfo.cs", SearchOption.AllDirectories);
                string fileText;
                string newVersion = string.Empty;

                var resultBuilder = new StringBuilder(VersioningMessages.Result_Header + Environment.NewLine);

                foreach (string file in files)
                {
                    fileText = File.ReadAllText(file);
                    Match match = assemblyVersionRegex.Match(fileText);

                    if (match.Success)
                    {
                        string[] version = match.Value.Split('.');

                        if (increaseMajor)
                            version[0] = (int.Parse(version[0]) + 1).ToString();
                        if (increaseMinor)
                            version[1] = (int.Parse(version[1]) + 1).ToString();

                        newVersion = string.Join(".", version);
                    }
                    fileText = assemblyVersionRegex.Replace(fileText, newVersion);
                    File.WriteAllText(file, fileText);

                    resultBuilder.AppendLine(string.Format(VersioningMessages.Result_Info, file, newVersion));
                }

                return resultBuilder.ToString();
            })
            .ConfigureAwait(false);
        }

        public async Task<string> ChangeVersions(string rootPath, string customVersion)
        {
            return await Task.Run(() =>
            {
                ValidateVersion(customVersion);

                string[] files = Directory.GetFiles(rootPath, "AssemblyInfo.cs", SearchOption.AllDirectories);
                string fileText;

                var resultBuilder = new StringBuilder(VersioningMessages.Result_Header + Environment.NewLine);

                foreach (string file in files)
                {
                    fileText = File.ReadAllText(file);

                    fileText = assemblyVersionRegex.Replace(fileText, customVersion);
                    File.WriteAllText(file, fileText);

                    resultBuilder.AppendLine(string.Format(VersioningMessages.Result_Info, file, customVersion));
                }

                return resultBuilder.ToString();
            })
            .ConfigureAwait(false);
        }

        public void ValidateVersion(string version)
        {
            if (!versionRegex.Match(version).Success)
                throw new ArgumentException("Invalid version format");
        }
    }
}
