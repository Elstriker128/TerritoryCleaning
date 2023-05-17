using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerritoryCleaning
{
    public class Family
    {
        public string Street { get; private set; }
        public string Owner { get; private set; }
        public int AdultCount { get; private set; }
        public int ChildCount { get; private set; }
        public double ApartmentSize { get; private set; }
        public int PeopleCount { get; set; }
        /// <summary>
        /// A constructor to create a Family class object
        /// </summary>
        /// <param name="street">the name of the street that the family lives in</param>
        /// <param name="owner">the name of the owner of the apartment</param>
        /// <param name="adultCount">the amount of adults in a family</param>
        /// <param name="childCount">the amount of children in a family</param>
        /// <param name="apartmentSize">the size of the apartment, where the family lives</param>
        public Family(string street, string owner, int adultCount, int childCount, double apartmentSize)
        {
            Street = street;
            Owner = owner;
            AdultCount = adultCount;
            ChildCount = childCount;
            ApartmentSize = apartmentSize;
        }
        /// <summary>
        /// A constructor to format data for output
        /// </summary>
        /// <param name="street">the name of the street that the family lives in</param>
        /// <param name="owner">the name of the owner of the apartment</param>
        /// <param name="peopleCount">the combined amount of people living in the apartment</param>
        public Family(string street, string owner, int peopleCount)
        {
            Street = street;
            Owner = owner;
            PeopleCount = peopleCount;
        }
        /// <summary>
        /// An overriden ToString() method that returns the Family object's data in a specific format
        /// </summary>
        /// <returns>the Family object's data in a specific format</returns>
        public override string ToString()
        {
            return String.Format($"| {this.Owner,-20} | {this.AdultCount,14} | {this.ChildCount,14} | {this.ApartmentSize,15} |");
        }
    }
}