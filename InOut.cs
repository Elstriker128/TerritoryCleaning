using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TerritoryCleaning
{
    public class InOut
    {
        /// <summary>
        /// A method that reads family data from a directory and puts that data into a list of lists
        /// </summary>
        /// <param name="files">the array of strings that hold all the data files' names</param>
        /// <returns>a list of lists of all the families</returns>
        public static List<List<Family>> ReadFamilyDataFromAllFiles(string[] files)
        {
            List<List<Family>> allFamilyList = new List<List<Family>>();
            foreach(string file in files)
            {
                allFamilyList.Add(ReadFamilyDataFromOneFile(file));
            }
            return allFamilyList;
        }
        /// <summary>
        /// A method that reads family data from a singular list and puts that data into a list
        /// </summary>
        /// <param name="fileName">the name of the data file</param>
        /// <returns>a list of families</returns>
        public static List<Family> ReadFamilyDataFromOneFile(string fileName)
        {
            List<Family> list = new List<Family>();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            string street = lines[0];
            foreach (string line in lines.Skip(1))
            {
                string[] values = Regex.Split(line, ";");
                string owner = values[0];
                int adultCount = int.Parse(values[1]);
                int childCount = int.Parse(values[2]);
                double apartmentSize = double.Parse(values[3]);
                Family current = new Family(street, owner, adultCount, childCount, apartmentSize);
                list.Add(current);
            }
            return list;
        }
        /// <summary>
        /// A method that prints the list of lists of family data to a TXT file
        /// </summary>
        /// <param name="filename">the name of the TXT file</param>
        /// <param name="allFamilyList">the list of lists of family data</param>
        public static void PrintFamilyDataFromAllFiles(string filename, List<List<Family>> allFamilyList)
        {
            foreach(List<Family> list in allFamilyList)
            {
                Family current = list.FirstOrDefault();
                PrintFamilyData(filename, current.Street, list);
            }
        }
        /// <summary>
        /// A method that prints the data of a single list of families into a TXT file
        /// </summary>
        /// <param name="filename">the name of the TXT file</param>
        /// <param name="header">a table name that tells what kind of data is stored</param>
        /// <param name="familyList">the list of family data</param>
        public static void PrintFamilyData(string filename, string header, List<Family> familyList)
        {
            using (StreamWriter writer = new StreamWriter(filename, true, Encoding.UTF8))
            {
                writer.WriteLine(new string('-', 190));
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 190));
                writer.WriteLine(($"| {"Owner",-20} | {"Adult count",-14} | {"Child count",-14} | {"Apartment size",-15} |"));
                writer.WriteLine(new string('-', 190));
                foreach (Family family in familyList)
                {
                    writer.WriteLine(family.ToString());
                }
                writer.WriteLine(new string('-', 190));
                writer.WriteLine();
            }
        }
        /// <summary>
        /// A method that prints the filtered families that pay more that the given amount in a specific format
        /// </summary>
        /// <param name="filename">the name of the TXT file</param>
        /// <param name="familyList">the list of family data</param>
        public static void PrintThreeFormatData(string filename, List<Family> familyList)
        {
            using (StreamWriter writer = new StreamWriter(filename, true, Encoding.UTF8))
            {
                writer.WriteLine(new string('-', 190));
                writer.WriteLine("Filtered families which pay more than given amount");
                writer.WriteLine(new string('-', 190));
                writer.WriteLine(($"| {"Street",-20} | {"Owner",-20} | {"People count",-14} |"));
                writer.WriteLine(new string('-', 190));
                foreach (Family family in familyList)
                {
                    writer.WriteLine(String.Format($"| {family.Street,-20} | {family.Owner,-20} | {family.PeopleCount,14} |"));
                }
                writer.WriteLine(new string('-', 190));
                writer.WriteLine();
            }
        }
        /// <summary>
        /// A method that reads all the costs from a data file
        /// </summary>
        /// <param name="fileName">the name of the data file</param>
        /// <returns>a list of all the costs</returns>
        public static List<Cost> ReadCostDataFromOneFile(string fileName)
        {
            List<Cost> list = new List<Cost>();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = Regex.Split(line, ";");
                int adultCount = int.Parse(values[0]);
                int childCount = int.Parse(values[1]);
                double oneSquareCost = double.Parse(values[2]);
                Cost current = new Cost(adultCount, childCount, oneSquareCost);
                list.Add(current);
            }
            return list;
        }
        /// <summary>
        /// A method that prints all the costs to a TXT file
        /// </summary>
        /// <param name="filename">the name of the TXT file</param>
        /// <param name="header">a table name that tells what kind of data is stored</param>
        /// <param name="costList">a list of all the costs</param>
        public static void PrintCostData(string filename, string header, List<Cost> costList)
        {
            using (StreamWriter writer = new StreamWriter(filename, true, Encoding.UTF8))
            {
                writer.WriteLine(new string('-', 190));
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 190));
                writer.WriteLine(($"| {"Adult count",-14} | {"Child count",-14} | {"One square cost",-20} |"));
                writer.WriteLine(new string('-', 190));
                foreach (Cost cost in costList)
                {
                    writer.WriteLine(cost.ToString());
                }
                writer.WriteLine(new string('-', 190));
                writer.WriteLine();
            }
        }
    }
}