using Firaxis.VisualStudio.Tasks.Civ6;
using Microsoft.Build.Framework;
using System;
using System.Xml.Linq;

namespace CivModBuddy
{
    public class CivWrapperTask : GenerateModInfo, ITask
    {
        public override bool Execute()
        {
            var result = base.Execute();

            if (result)
            {
                var modInfoPath = GetFullModinfoPath();
                if (modInfoPath != null)
                {
                    LogMessage("CivWrapperTask DEBUG - Adding CompatibleVersions tag to .modinfo file.");
                    AddCompatibleVersionsTag(modInfoPath);
                    LogMessage("CivWrapperTask DEBUG - Done.");
                }
                else
                {
                    LogMessage("CivWrapperTask ERROR - modInfoPath of '" + GetFullModinfoPath() + "' was null.");
                }
            }
            else
            {
                LogMessage("CivWrapperTask ERROR - An error occurred in Firaxis' section of code.");
            }

            return result;
        }

        private string GetFullModinfoPath()
        {
            return this.TargetPath;
        }

        private void AddCompatibleVersionsTag(string modInfoPath)
        {
            try
            {
                XDocument modInfo = XDocument.Load(modInfoPath);
                XElement modElement = modInfo.Element("Mod");
                XElement propertiesElement = modElement.Element("Properties");
                propertiesElement.Add(
                    new XElement("CompatibleVersions", "2.0")
                );
                modInfo.Save(modInfoPath);
            }
            catch (Exception ex)
            {
                LogMessage("CivWrapperTask EXCEPTION - " + ex.Message);
            }
        }

        private void LogMessage(string message)
        {
            this.Log.LogError(message);
        }
    }
}