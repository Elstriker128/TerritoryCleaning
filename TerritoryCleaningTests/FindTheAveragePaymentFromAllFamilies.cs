using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerritoryCleaning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerritoryCleaning.Tests
{
    [TestClass()]
    public class FindTheAveragePaymentFromAllFamilies
    {
        [TestMethod()]
        public void FindTheAveragePaymentFromAllFamilies_CheckIfCountIsRight_True()
        {
            List<List<Family>> allFamilies = new List<List<Family>>();

            List<Family> families = new List<Family>();
            Family first = new Family("Maple Road", "Gonzalez", 2, 2, 4.0);
            Family second = new Family("Pine Street", "Wilson", 1, 1, 2.0);
            Family third = new Family("Cedar Lane", "Rodriguez", 2, 3, 3.0);
            Family fourth = new Family("Elm Street", "Smith", 2, 0, 3.0);

            families.Add(first);
            families.Add(second);
            families.Add(third);
            families.Add(fourth);

            allFamilies.Add(families);

            TaskUtils taskUtils = new TaskUtils(allFamilies);

            List<Cost> costs = new List<Cost>();
            Cost cost1 = new Cost(2, 2, 4.0);
            Cost cost2 = new Cost(1, 1, 2.0);
            Cost cost3 = new Cost(2, 3, 3.0);
            Cost cost4 = new Cost(2, 0, 3.0);

            costs.Add(cost1);
            costs.Add(cost2);
            costs.Add(cost3);
            costs.Add(cost4);

            double average = taskUtils.FindTheAveragePaymentFromAllFamilies(costs);
            Assert.AreEqual(average, 9.5);
        }
    }
}
