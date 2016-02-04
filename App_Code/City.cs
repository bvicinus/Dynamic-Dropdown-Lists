using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

/// <summary>
/// Summary description for City
/// </summary>
public class City : IComparable<City>
{
    
    public int rank;
    public String name;
    public String state;
    public int population;



    //constructor
    //this will be one line from a csv file
    public City(string line)  
    {
        string[] info;
        info = line.Split(','); 
        //splits string at comma into array of strings 
        rank = int.Parse(info[0]); //parse string to int 
        name = info[1]; 
        state = info[2];
        population = int.Parse(info[3]); //tryParse would also work

    }

    public int CompareTo(City other)
    {
        int result = string.Compare(this.state, other.state);
        if (result == 0)
        {
            result = string.Compare(this.name, other.name);
        }
        return result;

    }


}