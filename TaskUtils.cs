using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerritoryCleaning
{
    public class TaskUtils
    {
        private List<List<Family>> allFamilies;
        /// <summary>
        /// A constructor that transforms a List<List<Family>> object to a TaskUtils object
        /// </summary>
        /// <param name="allFamilies">an object of the List<List<Family>> collection</param>
        public TaskUtils(List<List<Family>> allFamilies)
        {
            this.allFamilies = allFamilies;
        }
        /// <summary>
        /// A methodd that calculates how many families pay more taxes that the given amount
        /// </summary>
        /// <param name="amount">the given amount of money</param>
        /// <param name="costs">a list of all the costs</param>
        /// <returns>a list of families that pay more taxes that the given amount</returns>
        public List<Family> FilterAllFamilies(double amount, List<Cost> costs)
        {
            var allFilteredFamilies = from family in this.allFamilies.SelectMany(x => x)
                                      from cost in costs
                                      where family.AdultCount.Equals(cost.AdultCount) && family.ChildCount.Equals(cost.ChildCount) && family.ApartmentSize * cost.OneSquareCost > amount
                                      orderby family.Street, family.Owner
                                      select new Family(family.Street, family.Owner, family.PeopleCount = family.AdultCount + family.ChildCount);
            return allFilteredFamilies.ToList();
        }
        /// <summary>
        /// A method that finds the average amount of money paid from all families
        /// </summary>
        /// <param name="costs">a list of all the costs</param>
        /// <returns>the average amount of money paid from all families</returns>
        public double FindTheAveragePaymentFromAllFamilies(List<Cost> costs)
        {
               double sum = (from family in this.allFamilies.SelectMany(x => x)
                        from cost in costs
                        where family.AdultCount.Equals(cost.AdultCount) && family.ChildCount.Equals(cost.ChildCount)
                        select family.ApartmentSize * cost.OneSquareCost).Sum();
                int count = this.allFamilies.SelectMany(x => x).Count();
            return sum / count;
        }
        /// <summary>
        /// A method that how many families pay less that the average cost
        /// </summary>
        /// <param name="costs">a list of all the costs</param>
        /// <returns>a list of families that pay less that the average cost</returns>
        public List<Family> FilterAllFamilies(List<Cost> costs)
        {
            double average = FindTheAveragePaymentFromAllFamilies(costs);
            var allFilteredFamilies = from family in this.allFamilies.SelectMany( x => x)
                                                     from cost in costs
                                                     where family.AdultCount.Equals(cost.AdultCount) && family.ChildCount.Equals(cost.ChildCount) && family.ApartmentSize * cost.OneSquareCost < average
                                                     orderby family.Street, family.Owner
                                                     select family;
            return allFilteredFamilies.ToList();
        }
    }
}