using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerritoryCleaning
{
    public partial class UIForClient : System.Web.UI.Page
    {
        /// <summary>
        /// A method that occurs when the second button is pushed. It mainly calculates all additional values
        /// </summary>
        /// <param name="sender">an object of the object class</param>
        /// <param name="e">an object of the EventArgs class</param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.Visible= false;
            List<List<Family>> allFamilies = (List<List<Family>>)Session["AllFamilies"];
            List<Cost> costs = (List<Cost>)Session["AllCosts"];
            double amount = (double)Session["Amount"];
            TaskUtils taskUtils = new TaskUtils(allFamilies);
            try
            {
                List<Family> FilteredWhoPayMoreThanGivenAmount = taskUtils.FilterAllFamilies(amount, costs);
                if (FilteredWhoPayMoreThanGivenAmount.Count == 0)
                {
                    throw new IndexOutOfRangeException("Filtered families which pay more than given amount");
                }
                InOut.PrintThreeFormatData(Server.MapPath($"~/Result_Data/{Result}"), FilteredWhoPayMoreThanGivenAmount);
                InsertThreeParameterData(FilteredWhoPayMoreThanGivenAmount);
            }
            catch (IndexOutOfRangeException ek)
            {
                CustomValidator2.Visible = false;
                CustomValidator2.ErrorMessage = $"{ek.Message} list hold no values";
                CustomValidator2.IsValid = false;
                CustomValidator2.ForeColor = Color.Red;
            }
            try
            {
                List<Family> FilteredWhoPayLessThanAverage = taskUtils.FilterAllFamilies(costs);
                if (FilteredWhoPayLessThanAverage.Count == 0)
                {
                    throw new IndexOutOfRangeException("Filtered families which pay less than average");
                }
                InOut.PrintFamilyData(Server.MapPath($"~/Result_Data/{Result}"), "Filtered families which pay less than average", FilteredWhoPayLessThanAverage);
                InsertAboveAverageData(FilteredWhoPayLessThanAverage);
            }
            catch (IndexOutOfRangeException ek)
            {
                CustomValidator2.Visible = false;
                CustomValidator2.ErrorMessage = $"{ek.Message} list hold no values";
                CustomValidator2.IsValid = false;
                CustomValidator2.ForeColor = Color.Red;
            }
        }
        /// <summary>
        /// A method that inserts all the families' data to a table in the UI
        /// </summary>
        /// <param name="allFamilies"> a list of lists of all the families</param>
        private void InsertAllFamiliesData(List<List<Family>> allFamilies)
        {
            Panel panel = new Panel();
            Controls.Add(panel);
            foreach (var families in allFamilies)
            {
                Label emptySpace = new Label();
                emptySpace.Text = "";
                emptySpace.Height = 10;
                panel.Controls.Add(emptySpace);

                Table table = new Table();
                InsertFamilyData(families, table);
                panel.Controls.Add(table);

                panel.Controls.Add(emptySpace);
            }
            
        }
        /// <summary>
        /// A method that inserts the families' data to a table in the UI
        /// </summary>
        /// <param name="families">a list of a families data</param>
        /// <param name="required">the needed table for the data to be put</param>
        private void InsertFamilyData(List<Family> families, Table required)
        {
            required.BorderColor = Color.Black;
            required.BorderStyle = BorderStyle.Solid;
            required.GridLines = GridLines.Both;

            Family current = families.FirstOrDefault();
            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = $"{current.Street}";
            called.ColumnSpan = 4;
            prow.Cells.Add(called);
            required.Rows.Add(prow);

            TableRow frow = new TableRow();

            TableCell fowner = new TableCell();
            fowner.Text = "Owner";

            TableCell fadults = new TableCell();
            fadults.Text = "Adult count";

            TableCell fchildren = new TableCell();
            fchildren.Text = "Child count";

            TableCell fapartment = new TableCell();
            fapartment.Text = "Apartment size";

            frow.Cells.Add(fowner);
            frow.Cells.Add(fadults);
            frow.Cells.Add(fchildren);
            frow.Cells.Add(fapartment);

            required.Rows.Add(frow);

            foreach(Family family in families)
            {
                TableRow row = new TableRow();

                TableCell owner = new TableCell();
                owner.Text = family.Owner;

                TableCell adults = new TableCell();
                adults.Text = family.AdultCount.ToString();

                TableCell children = new TableCell();
                children.Text = family.ChildCount.ToString();

                TableCell apartment = new TableCell();
                apartment.Text = family.ApartmentSize.ToString();

                row.Cells.Add(owner);
                row.Cells.Add(adults);
                row.Cells.Add(children);
                row.Cells.Add(apartment);

                required.Rows.Add(row);
            }
        }
        /// <summary>
        /// A method that inserts all the costs to a table
        /// </summary>
        /// <param name="costs">a list of all the costs</param>
        private void InsertCostData(List<Cost> costs)
        {
            Panel panel = new Panel();
            Controls.Add(panel);

            Label emptySpace = new Label();
            emptySpace.Text = "";
            emptySpace.Height = 10;
            panel.Controls.Add(emptySpace);

            Table required = new Table();

            required.BorderColor = Color.Black;
            required.BorderStyle = BorderStyle.Solid;
            required.GridLines = GridLines.Both;

            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = $"The primary costs for cleaning";
            called.ColumnSpan = 3;
            prow.Cells.Add(called);
            required.Rows.Add(prow);

            TableRow frow = new TableRow();

            TableCell fadults = new TableCell();
            fadults.Text = "Adult count";

            TableCell fchildren = new TableCell();
            fchildren.Text = "Child count";

            TableCell foneSquare = new TableCell();
            foneSquare.Text = "One square price";

            frow.Cells.Add(fadults);
            frow.Cells.Add(fchildren);
            frow.Cells.Add(foneSquare);

            required.Rows.Add(frow);

            foreach (Cost cost in costs)
            {
                TableRow row = new TableRow();

                TableCell adults = new TableCell();
                adults.Text = cost.AdultCount.ToString();

                TableCell children = new TableCell();
                children.Text = cost.ChildCount.ToString();

                TableCell apartment = new TableCell();
                apartment.Text = cost.OneSquareCost.ToString();

                row.Cells.Add(adults);
                row.Cells.Add(children);
                row.Cells.Add(apartment);

                required.Rows.Add(row);
            }
            panel.Controls.Add(required);

            panel.Controls.Add(emptySpace);
        }
        /// <summary>
        /// A method that inserts the data of filtered families that pay above average cost into a table in the UI
        /// </summary>
        /// <param name="families">a list of families</param>
        private void InsertAboveAverageData(List<Family> families)
        {
            Panel panel = new Panel();
            Controls.Add(panel);

            Label emptySpace = new Label();
            emptySpace.Text = "";
            emptySpace.Height = 10;
            panel.Controls.Add(emptySpace);

            Table required = new Table();

            required.BorderColor = Color.Black;
            required.BorderStyle = BorderStyle.Solid;
            required.GridLines = GridLines.Both;

            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = $"Filtered families which less more than average";
            called.ColumnSpan = 4;
            prow.Cells.Add(called);
            required.Rows.Add(prow);

            TableRow frow = new TableRow();

            TableCell fowner = new TableCell();
            fowner.Text = "Owner";

            TableCell fadults = new TableCell();
            fadults.Text = "Adult count";

            TableCell fchildren = new TableCell();
            fchildren.Text = "Child count";

            TableCell fapartment = new TableCell();
            fapartment.Text = "Apartment size";

            frow.Cells.Add(fowner);
            frow.Cells.Add(fadults);
            frow.Cells.Add(fchildren);
            frow.Cells.Add(fapartment);

            required.Rows.Add(frow);

            foreach (Family family in families)
            {
                TableRow row = new TableRow();

                TableCell owner = new TableCell();
                owner.Text = family.Owner;

                TableCell adults = new TableCell();
                adults.Text = family.AdultCount.ToString();

                TableCell children = new TableCell();
                children.Text = family.ChildCount.ToString();

                TableCell apartment = new TableCell();
                apartment.Text = family.ApartmentSize.ToString();

                row.Cells.Add(owner);
                row.Cells.Add(adults);
                row.Cells.Add(children);
                row.Cells.Add(apartment);

                required.Rows.Add(row);
            }
            panel.Controls.Add(required);

            panel.Controls.Add(emptySpace);
        }
        /// <summary>
        /// A method that inserts the data of filtered families in a specific format into a table 
        /// </summary>
        /// <param name="families">a list of families</param>
        private void InsertThreeParameterData(List<Family> families)
        {
            Panel panel = new Panel();
            Controls.Add(panel);

            Label emptySpace = new Label();
            emptySpace.Text = "";
            emptySpace.Height = 10;
            panel.Controls.Add(emptySpace);

            Table required = new Table();

            required.BorderColor = Color.Black;
            required.BorderStyle = BorderStyle.Solid;
            required.GridLines = GridLines.Both;

            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = $"Filtered families which pay more than given amount";
            called.ColumnSpan = 3;
            prow.Cells.Add(called);
            required.Rows.Add(prow);

            TableRow frow = new TableRow();

            TableCell fstreet = new TableCell();
            fstreet.Text = "Street";

            TableCell fowner = new TableCell();
            fowner.Text = "Owner";

            TableCell fallPeople = new TableCell();
            fallPeople.Text = "People count";


            frow.Cells.Add(fstreet);
            frow.Cells.Add(fowner);
            frow.Cells.Add(fallPeople);

            required.Rows.Add(frow);

            foreach (Family family in families)
            {
                TableRow row = new TableRow();

                TableCell street = new TableCell();
                street.Text = family.Street;

                TableCell owner = new TableCell();
                owner.Text = family.Owner;

                TableCell allPeople = new TableCell();
                allPeople.Text = family.PeopleCount.ToString();

                row.Cells.Add(street);
                row.Cells.Add(owner);
                row.Cells.Add(allPeople);

                required.Rows.Add(row);
            }
            panel.Controls.Add(required);

            panel.Controls.Add(emptySpace);
        }
    }
}