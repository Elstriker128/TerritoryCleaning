using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerritoryCleaning
{
    public partial class UIForClient : System.Web.UI.Page
    {
        const string Result = "Results.txt";
        protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Visible = false;
            try
            {
                List<List<Family>> allFamilies = (List<List<Family>>)Session["AllFamilies"];
                List<Cost> costs = (List<Cost>)Session["AllCosts"];
                double amount = (double)Session["Amount"];
                InsertAllFamiliesData(allFamilies);
                InsertCostData(costs);
            }
            catch (NullReferenceException)
            {

                Label1.Text = "No saved primary data";
                Label1.ForeColor = Color.Red;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            Controls.Add(panel);

            if (File.Exists(Server.MapPath($"~/Result_Data/{Result}")))
            {
                File.Delete(Server.MapPath($"~/Result_Data/{Result}"));
            }
            Label1.Text = string.Empty;
            Session.RemoveAll();

            string familyPath = TextBox1.Text;
            string costPath = TextBox2.Text;
            string searchPattern = "*.txt";
            try
            {
                string[] familyFiles = Directory.GetFiles(familyPath, searchPattern);
                if (familyFiles.Length == 0)
                {
                    throw new DirectoryNotFoundException();
                }
                string[] costFiles = Directory.GetFiles(costPath, searchPattern);
                if (costFiles.Length == 0)
                {
                    throw new DirectoryNotFoundException();
                }
                double amount = double.Parse(TextBox3.Text);

                List<List<Family>> allFamilies = InOut.ReadFamilyDataFromAllFiles(familyFiles);
                if(allFamilies.Count == 0)
                {
                    throw new IndexOutOfRangeException();
                }
                List<Cost> costs = InOut.ReadCostDataFromOneFile(costFiles.FirstOrDefault());
                if (costs.Count == 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (allFamilies.Count > 0 && costs.Count > 0)
                {
                    Button2.Visible = true;
                }

                InOut.PrintFamilyDataFromAllFiles(Server.MapPath($"~/Result_Data/{Result}"), allFamilies);
                InOut.PrintCostData(Server.MapPath($"~/Result_Data/{Result}"), "The primary costs for cleaning", costs);

                InsertAllFamiliesData(allFamilies);
                InsertCostData(costs);

                Session["AllFamilies"] = allFamilies;
                Session["AllCosts"] = costs;
                Session["Amount"] = amount;
            }
            catch (DirectoryNotFoundException)
            {
                CustomValidator1.Visible=false;
                CustomValidator1.ErrorMessage = $"Impossible to proceed because one of the directory's data has not been found";
                CustomValidator1.IsValid = false;
                CustomValidator1.ForeColor = Color.Red;
            }
            catch(IndexOutOfRangeException)
            {
                CustomValidator2.Visible = false;
                CustomValidator2.ErrorMessage = $"There is no data in the whole direcotory";
                CustomValidator2.IsValid = false;
                CustomValidator2.ForeColor = Color.Red;
            }
        }
    }
}