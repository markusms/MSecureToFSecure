using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MsecureToFsecure
{
    class Program
    {
        static void Main(string[] args)
        {
            //change path to where you have a keys.txt file with copy pasted msecure keys.csv
            //change newPath to where you want the fsecureKeys.txt to be created 
            //create a new csv file in excel and copy paste fsecureKeys.txt there
            //import the new csv file to F-Secure KEY as Keepass 2 csv
            string path = @"I:\Koodaus\CSharp\MsecureToFsecure\MsecureToFsecure\keys.txt";
            string newPath = @"I:\Koodaus\CSharp\MsecureToFsecure\MsecureToFsecure\fsecureKeys.txt";

            int counter = 0;
            string line;
            List<string> keyList = new List<string>();

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] keys = line.Split(',');
                int lastPos = keys.Length - 1;
                string key = $"{keys[2]},{keys[5]},{keys[6]},{keys[4]},{keys[3]}";
                keyList.Add(key);
                counter++;
            }
            file.Close();

            TextWriter tw = new StreamWriter(newPath, true);

            tw.WriteLine("start"); //the first line has to have some text but it is not read as a password
            foreach (var key in keyList)
            {
                tw.WriteLine(key);
            }
            tw.Close();
        }
    }
}
