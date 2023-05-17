using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerritoryCleaning
{
    public class Cost
    {
        public int AdultCount { get; private set; }
        public int ChildCount { get; private set; }
        public double OneSquareCost { get; private set; }
        /// <summary>
        /// A constructor to create a Cost class object
        /// </summary>
        /// <param name="adultCount">the required amount of adults in a family</param>
        /// <param name="childCount">the required amount of children in a family</param>
        /// <param name="oneSquareCost">the cost for one square meter</param>
        public Cost(int adultCount, int childCount, double oneSquareCost)
        {
            AdultCount = adultCount;
            ChildCount = childCount;
            OneSquareCost = oneSquareCost;
        }
        /// <summary>
        /// An overriden ToString() method that returns the Cost object's data in a specific format
        /// </summary>
        /// <returns>the Cost object's data in a specific format</returns>
        public override string ToString()
        {
            return String.Format($"| {this.AdultCount,14} | {this.ChildCount,14} | {this.OneSquareCost,20} |");
        }
    }
}