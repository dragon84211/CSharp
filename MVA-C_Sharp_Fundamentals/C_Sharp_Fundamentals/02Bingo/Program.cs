using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _02Bingo {
    class Program {
        static Boolean[,] bingoBoard = new Boolean[5, 5];

        static void Main(string[] args) {
            List<string> inputArr = ReadFile(@"C:\temp\Bingo.txt");
            Boolean bingo = PlayBingo(inputArr);

            if (bingo)
                Console.WriteLine("Bingo!!!");
            else
                Console.WriteLine("Boo!!!");
            
            PrintBoard();

            Console.ReadLine();
        }

        static List<string> ReadFile(string fileName) {
            List<string> lineArr = new List<string>();
            StreamReader myReader = new StreamReader(fileName);
            String line = "";
            while (line != null) {
                line = myReader.ReadLine();
                if (line != null)
                    lineArr.Add(Regex.Replace(line,@"\s+",""));
            }
            myReader.Close();
            return lineArr;
        }

        static Boolean PlayBingo(List<string> inputArr) {
            string[] coord;
            int xCoord;
            int yCoord;
            foreach (string input in inputArr) {
                Console.WriteLine(input);
                coord = input.Split(',');
                xCoord = int.Parse(coord[0])-1;
                yCoord = int.Parse(coord[1])-1;
                
                bingoBoard[xCoord, yCoord] = true;
                if (IsBingo(xCoord, yCoord))
                    return true;
            }
            return false;
        }

        static Boolean IsBingo(int xCoord, int yCoord) {
            //Check Horizontal
            Boolean isBingo = true;
            for (int i = 0; i < bingoBoard.GetLength(0); i++) {
                if (bingoBoard[xCoord, i] != true) {
                    isBingo = false;
                    break;
                }
            }
            if (isBingo)
                return true;

            //Check Vertical
            isBingo = true;
            for (int i = 0; i < bingoBoard.GetLength(0); i++) {
                if (bingoBoard[i, yCoord] != true) {
                    isBingo = false;
                    break;
                }
            }
            if (isBingo)
                return true;

            //Check Diag
            if (xCoord == yCoord) {
                isBingo = true;
                for (int i = 0; i < 5; i++) {
                    if (bingoBoard[i, i] != true) {
                        isBingo = false;
                        break;
                    }
                }
                if (isBingo)
                    return true;
            }

            if (xCoord + yCoord +1 == bingoBoard.GetLength(0)) {
                isBingo = true;
                for (int i = 0; i < 5; i++) {
                    if (bingoBoard[bingoBoard.GetLength(0) -1 - i, i]) {
                        isBingo = false;
                        break;
                    }
                }
            }            
            return isBingo;
        }

        static void PrintBoard() {
            Console.WriteLine("");
            for (int i = 0; i < bingoBoard.GetLength(0); i++) {
                for (int j = 0; j < bingoBoard.GetLength(0); j++) {
                    if (bingoBoard[i, j])
                        Console.Write("X\t");
                    else
                        Console.Write("O\t");
                }
                Console.WriteLine();
            }
        }
    }
}
