using System.IO;

namespace Solid_Principles
{
    public class Persistence
    {
        public void SaveToFile(Journal journal, string fileName, bool overwrite = false)
        {
            if(overwrite || !File.Exists(fileName))
                File.WriteAllText(fileName,journal.ToString());
        }
    }
}