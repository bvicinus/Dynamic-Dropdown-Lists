using System;
using System.IO;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
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


    //event handler for drop down list for STATES
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlState is autoPostback = true, so the page will reload every changed state

        //this is to reset the label text when a new state is selected 
        lblPopulation.Text = "Population";

        //more bug fixes...
        //if the user selects the blank state
        if(ddlState.SelectedIndex == 0)
        {
            return;
        }


        //grab and store the selected state
        string selected_state = ddlState.SelectedValue;

        //clear any previous cities in there
        ddlCities.Items.Clear();

        //this here is to make a blank option at the very top
        ListItem li = new ListItem("", ""); //create the object
        ddlCities.Items.Add(li); //and add it to the ddl

        //iterates over the list 'cities'
        foreach (City city in cities) 
        {
            //notice how '==' works with strings in C#
            //"are the contents of these two strings the same"
            //not "are these the same string object" like most languages do
            if (city.state == selected_state)
            {
                li = new ListItem(city.name, city.name);
                ddlCities.Items.Add(li); //add to the ddl 
            }
        }
    }



    //event handler for ddl CITIES - autopostback = true
    protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
    {

        //more bug fixes...
        //if the user selects the blank city
        if (ddlCities.SelectedIndex == 0)
        {
            //reset the label
            lblPopulation.Text = "Population";
            return;
        }


        int population = 0;

        //iterate through each city
        foreach (City city in cities)
        {
            //string comparison 
            if (city.name == ddlCities.SelectedValue)
            {
                //set population when correct city found
                population = city.population;
                break;
            }
        }

        //set the label to display the population
        lblPopulation.Text = "Population of " + ddlCities.SelectedValue + " is " + population.ToString();
    }
}