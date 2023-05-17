using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TerritoryCleaning
{
    public static class StaticClassForAdditions
    {
        //public static List<Family> FilterFamiliesThatPayMoreThanAmount(this List<Family> families, double amount, List<Cost> costs)
        //{
        //    var filtered = from family in families
        //                   from cost in costs
        //                   where family.AdultCount.Equals(cost.AdultCount) && family.ChildCount.Equals(cost.ChildCount) && family.ApartmentSize * cost.OneSquareCost > amount 
        //                   orderby family.Street, family.Owner
        //                   select new Family(family.Street, family.Owner,family.PeopleCount= family.AdultCount + family.ChildCount);
        //    return filtered.ToList();
        //}
        //public static double FindTheSumOfAllPayments(this List<Family> families, List<Cost> costs)
        //{
        //    double sum = (from family in families
        //                  from cost in costs
        //                  where family.AdultCount.Equals(cost.AdultCount) && family.ChildCount.Equals(cost.ChildCount)
        //                  select family.ApartmentSize * cost.OneSquareCost).Sum();
        //    return sum;
        //}
    }
}