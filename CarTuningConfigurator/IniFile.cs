using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

public class IniFile
{
    private string fileName;

    public IniFile(string fileName)
    {
        this.fileName = fileName;
    }

    public string ReadSection(string section)
    {
        string[] lines = File.ReadAllLines(fileName);

        string sectionValue = null;
        foreach(string line in lines)
        {
            if (line.StartsWith(section))
            {
                sectionValue = line.Split("=")[1].Trim();
                break;
            }
        }

        if(sectionValue == null)
        {
            throw new ArgumentNullException("The Section " + sectionValue + " is not defined.");
        }

        return sectionValue;
    }

    
}
