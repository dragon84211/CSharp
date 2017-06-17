using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace _03String {
    class Program {
        static void Main(string[] args) {
            List<string> inputArr = ReadFile(@"C:\temp\Input.txt");
            StringAppend(inputArr, 100000, true);
            StringAppend(inputArr, 1500, false);
            Console.ReadLine();
        }

        static List<string> ReadFile(string fileName) {
            List<string> lineArr = new List<string>();
            StreamReader myReader = new StreamReader(fileName);
            String line = "";
            while (line != null) {
                line = myReader.ReadLine();
                if (line != null)
                    lineArr.Add(line);
            }
            myReader.Close();
            return lineArr;
        }

        static void StringAppend(List<string> inputStringArr, int numOfTimes, bool fastSpeed) {
            DateTime startTime = DateTime.Now;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (fastSpeed) {
                StringBuilder finalString = new StringBuilder();
                for (int i = 0; i < numOfTimes; i++) {
                    //finalString.Clear();
                    foreach (string line in inputStringArr) {
                        finalString.Append(line);
                    }
                }
            }
            else {
                String finalString = "";
                for (int i = 0; i < numOfTimes; i++) {
                    //finalString = "";
                    foreach (string line in inputStringArr) {
                        finalString += line;
                    }
                }
            }
            TimeSpan totalTimeSpan = DateTime.Now.Subtract(startTime);
            stopWatch.Stop();
            Console.WriteLine("{0}: DateTime-{1}ms / Stopwatch-{2}ms", fastSpeed ? "StringBuilder" : "String", (int)totalTimeSpan.TotalMilliseconds, stopWatch.ElapsedMilliseconds);
        }
    }
}
