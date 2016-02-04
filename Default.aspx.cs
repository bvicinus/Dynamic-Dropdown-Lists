using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    List<City> cities = new List<City>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["cities"] == null)
        {
            string path = Server.MapPath("App_Data/cities.csv"); //creates a path to the file
            using (StreamReader readFile = new StreamReader(path)) //text I/O
            {
                string line;
                while ((line = readFile.ReadLine()) != null)
                {
                    City city = new City(line); //create new city
                    cities.Add(city); //add new city to list of cities
                }
            }
            cities.Sort(); //sort the cities list
            Application["cities"] = cities; //
        }
        else
        {
            cities = (List<City>)Application["cities"];
        }        if (IsPostBack) //not initial load
        {
            return;
        }
        // Initial page load only
        // Populate dropdown list of states
        ListItem li = new ListItem("", "");
        ddlState.Items.Add(li);
        string prev_state = "";
        foreach (City city in cities)
        {
            if (city.state != prev_state) //if new state, previously not in list
            {
                // Add state to dropdown list.
                li = new ListItem(city.state, city.state);
                ddlState.Items.Add(li);
                prev_state = city.state;
            }
        }
    }
}