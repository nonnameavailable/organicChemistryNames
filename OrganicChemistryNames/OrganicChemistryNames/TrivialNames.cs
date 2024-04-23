using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace OrganicChemistryNames
{
    class TrivialNames
    {
        private Dictionary<string, string> csvData = new Dictionary<string, string>();
        public TrivialNames()
        {
            string fileContent = Properties.Resources.chemusage;
            using (var reader = new StringReader(fileContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split(';');
                    string name = split[0];
                    if (!csvData.ContainsKey(name))
                    {
                        csvData.Add(name, line);
                    }
                }
            }
        }
        public string NameAndUsage(string key)
        {
            if (csvData.TryGetValue(key, out string value))
            {
                string[] data = value.Split(';');
                string trivial = data[1];
                string usage = data[2];
                return trivial + Environment.NewLine + usage; // Returns the whole line as a string
            }
            else
            {
                return null; // Key not found
            }
        }
    }
}
