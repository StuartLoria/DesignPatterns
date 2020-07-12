using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SOLID.Principles
{
    public class SingleResponsibility
    {
        private const bool OVERWRITE = true;
        public void Test()
        {
            var myJournal = new Journal();
            myJournal.AddEntry("I ate an apple today");
            myJournal.AddEntry("I rode my bike today");
            System.Console.WriteLine(myJournal);

            string savedFilePath = JournalPersistence.SaveToFile(myJournal, "happyDay.txt", OVERWRITE);
            System.Console.WriteLine($"Saved Journal to: {savedFilePath}");
        }
    }

    class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");

            return count;   // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    static class JournalPersistence
    {
        public static string SaveToFile(Journal journal, string fileName, bool overwrite = false)
        {
            string appFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            string journalFolderPath = Path.Combine(appFolderPath, "JournalFiles");
            Directory.CreateDirectory(journalFolderPath);
            string journalFilePath = Path.Combine(journalFolderPath, fileName);

            bool fileIsNew = !File.Exists(journalFilePath);
            if(overwrite || fileIsNew)
            {
                File.WriteAllText(journalFilePath, journal.ToString());
            }

            return journalFilePath;
        }
    }
}
