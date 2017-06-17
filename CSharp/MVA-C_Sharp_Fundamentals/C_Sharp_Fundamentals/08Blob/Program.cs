using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace _08Blob {
    class Program {
        static void Main(string[] args) {
            bool[,] blobGrid = HelperClass.ReadFileGenerateGrid("C:\\users\\drago\\Desktop\\blob.txt", ' ', 10);
            HelperClass.printBoolGrid(blobGrid);

            BlobBoundaryTraverser firstBlob = new BlobBoundaryTraverser(blobGrid);
            firstBlob.traverseBlob();
            firstBlob.print();

            Console.ReadLine();
        }
    }

    public class BlobBoundaryTraverser {
        enum Direction { Up, Down, Left, Right };
        private int topBound, lowerBound, leftBound, rightBound;
        private Direction dir;
        private Coords currCoord;
        private Dictionary<Coords,bool> checkedCells;
        private bool[,] gridWithBlob;

        public BlobBoundaryTraverser(bool[,] gridWithBlob) {
            dir = Direction.Up;
            this.gridWithBlob = gridWithBlob;
            checkedCells = new Dictionary<Coords, bool>();

            currCoord = findStartPoint();
            topBound = currCoord.y;
            lowerBound = currCoord.y;
            leftBound = currCoord.x;
            rightBound = currCoord.x;
            Console.WriteLine("=====Starting Point=====");
            Console.WriteLine("{0} {1}", currCoord.x, currCoord.y);
        }

        //Do a scan to find the "left" wall of the blob
        private Coords findStartPoint() {
            int arrSize = gridWithBlob.GetLength(0);
            int interval = arrSize/2;
            while (interval != 0) {
                for (int y = interval-1; y < arrSize; y = y + interval) {
                    for (int x = 0; x < arrSize; x++) {
                        Coords checkedCoord = new Coords(x, y);
                        addCheckedCell(checkedCoord);
                        if (gridWithBlob[x, y]) {
                            return checkedCoord;
                        }
                    }
                }
                interval = interval / 2;
            }
            return new Coords(-1,-1);
        }

        //Basically, hug the left wall around the entire blob's border
        public void traverseBlob() {
            int counter = -1;
            Coords startingCoord = currCoord;

            Console.WriteLine("=====Path Taken=====");
            do {
                //accounts for the fringe case where there's a "tail" on my starting point
                if (startingCoord.Equals(currCoord))
                    counter++;

                switch (dir) {
                    case Direction.Up:
                        //check left, up, right+, down+
                        if (moveLeft())
                            continue;
                        else if (moveUp())
                            continue;
                        else if (moveRight())
                            continue;
                        else if (moveDown())
                            continue;
                        break;
                    case Direction.Down:
                        //check right, down, left, up
                        if (moveRight())
                            continue;
                        else if (moveDown())
                            continue;
                        else if (moveLeft())
                            continue;
                        else if (moveUp())
                            continue;
                        break;
                    case Direction.Left:

                        //check down, left, up, right
                        if (moveDown())
                            continue;
                        else if (moveLeft())
                            continue;
                        else if (moveUp())
                            continue;
                        else if (moveRight())
                            continue;
                        break;
                    case Direction.Right:
                        //check up, right, down, left
                        if (moveUp())
                            continue;
                        else if (moveRight())
                            continue;
                        else if (moveDown())
                            continue;
                        else if (moveLeft())
                            continue;
                        break;
                }
            } while (counter < 2);
        }

        private Boolean moveLeft() {
            Coords checkedCoord;
            if (currCoord.x != 0) {
                checkedCoord = new Coords(currCoord.x - 1, currCoord.y);
                addCheckedCell(checkedCoord);
                if (gridWithBlob[checkedCoord.x, checkedCoord.y]) {
                    currCoord = checkedCoord;
                    dir = Direction.Left;
                    Console.WriteLine("{0} {1}", checkedCoord.x, checkedCoord.y);
                    return true;
                }
            }
            return false;
        }

        private Boolean moveRight() {
            Coords checkedCoord;
            int maxIndex = gridWithBlob.GetLength(0) - 1;
            if (currCoord.x != maxIndex) {
                checkedCoord = new Coords(currCoord.x + 1, currCoord.y);
                addCheckedCell(checkedCoord);
                if (gridWithBlob[checkedCoord.x, checkedCoord.y]) {
                    currCoord = checkedCoord;
                    dir = Direction.Right;
                    Console.WriteLine("{0} {1}", checkedCoord.x, checkedCoord.y);
                    return true;
                }
            }
            return false;
        }

        private Boolean moveUp() {
            Coords checkedCoord;
            if (currCoord.y != 0) {
                checkedCoord = new Coords(currCoord.x, currCoord.y - 1);
                addCheckedCell(checkedCoord);
                if (gridWithBlob[checkedCoord.x, checkedCoord.y]) {
                    currCoord = checkedCoord;
                    dir = Direction.Up;
                    Console.WriteLine("{0} {1}", checkedCoord.x, checkedCoord.y);
                    return true;
                }
            }
            return false;
        }

        private Boolean moveDown() {
            Coords checkedCoord;
            int maxIndex = gridWithBlob.GetLength(0) - 1;
            if (currCoord.y != maxIndex) {
                checkedCoord = new Coords(currCoord.x, currCoord.y + 1);
                addCheckedCell(checkedCoord);
                if (gridWithBlob[checkedCoord.x, checkedCoord.y]) {
                    currCoord = checkedCoord;
                    dir = Direction.Down;
                    Console.WriteLine("{0} {1}", checkedCoord.x, checkedCoord.y);
                    return true;
                }
            }
            return false;
        }

        private void addCheckedCell(Coords checkedCoord) {
            if (!checkedCells.ContainsKey(checkedCoord)) {
                checkedCells.Add(checkedCoord, gridWithBlob[checkedCoord.x, checkedCoord.y]);
            }
            if (gridWithBlob[checkedCoord.x, checkedCoord.y]) {
                if (checkedCoord.x < leftBound) {
                    leftBound = checkedCoord.x;
                }
                if (checkedCoord.x > rightBound) {
                    rightBound = checkedCoord.x;
                }
                if (checkedCoord.y < topBound) {
                    topBound = checkedCoord.y;
                }
                if (checkedCoord.y > lowerBound) {
                    lowerBound = checkedCoord.y;
                }
            }
        }

        public void print() {
            Console.WriteLine("=====OUTPUT=====");
            Console.WriteLine("Number of Checked Cells: {0}", checkedCells.Count);
            Console.WriteLine("Top Boundary: {0}", topBound);
            Console.WriteLine("Lower Boundary: {0}", lowerBound);
            Console.WriteLine("Left Boundary: {0}", leftBound);
            Console.WriteLine("Right Boundary: {0}", rightBound);
        }

        private struct Coords {
            public int x, y;

            public Coords(int x, int y) {
                this.x = x;
                this.y = y;
            }
        }
    }

    public static class HelperClass {
        public static bool[,] ReadFileGenerateGrid(string fileName, char delimiter, int arrSize) {
            bool[,] blobGrid = new bool[arrSize, arrSize];
            uint counter = 0;
            try {
                using (StreamReader myReader = new StreamReader(fileName)) {
                    String line = "";
                    while ((line = myReader.ReadLine()) != null) {
                        string[] lineOfBits = Regex.Split(line.Trim(), delimiter+"\\s?");
                        if (lineOfBits.Length != arrSize) {
                            throw new Exception("Size of input array does not match expected number of columns");
                        }
                        for (int i = 0; i < arrSize; i++) {
                            blobGrid[i, counter] = (lineOfBits[i].Equals("0")) ? false : true;   
                        }
                        counter++;
                    }
                }
            }
            catch (FileNotFoundException e) {
                Console.WriteLine("The file {0} does not exist", fileName);
                Console.WriteLine(e.ToString());
                Console.ReadLine();
                return null;
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
                return null;
            }
            return blobGrid;
        }

        public static void printBoolGrid(bool[,] grid) {
            int arrSize = grid.GetLength(0);
            for (int j = 0; j < arrSize; j++) {
                for (int i = 0; i < arrSize; i++) {
                    Console.Write(string.Format("{0} ", (grid[i, j] == false) ? "0" : "1"));
                }
                Console.WriteLine();
            }
        }
    }
}