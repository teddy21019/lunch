using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSV : MonoBehaviour
{
    public static List<Restaurant> ReadRestaurantCSV(string path)
    {
        List<Restaurant> newRestaurants = new List<Restaurant>();
        Restaurant res = null;
        StreamReader stream = new StreamReader(File.OpenRead(path), System.Text.Encoding.UTF8);
        bool firstLine = true;
        while (!stream.EndOfStream)
        {
            string line = stream.ReadLine();
            string[] cells = line.Split(',');
            if (firstLine)
            {
                res = new Restaurant(name: cells[0], addr: cells[1], phone: cells[2]);
                firstLine = false;
            }
            else if (cells[0] == "end")
            {
                newRestaurants.Add(res);
                firstLine = true;
            }
            else
            {
                res.menu.Add(new Food(cells[0], int.Parse(cells[1])));
            }
        }
        return newRestaurants;
    }

    //public List<Eater> ReadEaterCSV(string path)
    //{
    //    List<Eater> newEaters = new List<Eater>;
    //    Eater eater = null;
    //    StreamReader stream = new StreamReader(File.OpenRead(path), System.Text.Encoding.UTF8);

    //}
    //public OrderLine ReadOrderLineCSV()
    //{
    //}
}