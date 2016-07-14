using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Initiate : MonoBehaviour
{
    private static string path = Application.persistentDataPath;

    private void Awake()
    {
        ReadData("data");
    }

    public static void ReadData(string type)
    {
        if (File.Exists(path + @"/" + type + ".xml"))
        {
            var serializer = new XmlSerializer(typeof(Data));
            var stream = new StreamReader(path + @"/" + type + ".xml", Encoding.UTF8);

            Data.data = (Data)serializer.Deserialize(stream);
            stream.Close();
        }
        else
        {
            File.Create(path + @"/" + type + ".xml");
        }
    }

    public static void WriteData(string type)
    {
        var serializer = new XmlSerializer(typeof(Data));
        var stream = new StreamWriter(path + @"/" + type + ".xml", false, Encoding.UTF8);
        serializer.Serialize(stream, Data.data);
        stream.Close();
    }

    public static GameObject Instantiate(GameObject prefab, Transform parent)
    {
        GameObject GO = Instantiate(prefab);
        GO.transform.SetParent(parent);
        GO.transform.localScale = Vector3.one;
        return GO;
    }
}

[XmlRoot("data")]
public class Data
{
    public static Data data = new Data(new List<Eater>(), new List<Restaurant>());

    public List<Eater> eaters;
    public List<Restaurant> restaurant;

    private Data()
    {
    }

    public Data(List<Eater> e, List<Restaurant> r)
    {
        eaters = e;
        restaurant = r;
    }
}

public class Eater
{
    public string name;
    public bool isVegetarian;
    public Restaurant preferedRestaurant;

    public Eater()
    {
    }

    public Eater(string name)
    {
        this.name = name;
    }
}

public class Restaurant
{
    private string restaurantName;
    private string address;
    private string phoneNumber;
    private float rank;//0~5
    public List<Food> menu = new List<Food>();
    //public Image restaurantDM;

    //property
    public string Name { get { return restaurantName; } set { restaurantName = value; } }

    public string Address { get { return address; } set { address = value; } }
    public string PhoneNum { get { return phoneNumber; } set { phoneNumber = value; } }
    public float Rank { get { return rank; } set { rank = value; } }

    public Restaurant()
    {
        restaurantName = "";
        address = "";
        phoneNumber = "";
    }

    public Restaurant(string name, string addr, string phone)
    {
        restaurantName = name;
        address = addr;
        phoneNumber = phone;
    }

    //public void SetImage(Image img)
    //{
    //    restaurantDM = img;
    //}

    public void ChangeMunu(string name, int prise, Food food)
    {
        food.name = name;
        food.prise = prise;
        if (menu.Contains(food))
        {
            return;
        }
        else
        {
            menu.Add(food);
        }
    }
}

public class Food
{
    public string name;
    public int prise;

    public Food()
    {
        name = "";
        prise = 0;
    }

    public Food(string name, int prise)
    {
        this.name = name;
        this.prise = prise;
    }
}

public class Order
{
    public static List<Order> orders = new List<Order>();

    private string restaurant;
    private Dictionary<string, string> order = new Dictionary<string, string>();
    private string time;
    private int cost;

    public Order()
    {
    }

    public Order(Restaurant r, Dictionary<Eater, Food> e_f, DateTime dt, int c)
    {
        restaurant = r.Name;
        foreach (var p in e_f)
        {
            order.Add(p.Key.name, p.Value.name);
        }
        time = dt.ToString("yyyy/M/d HH:mm");
        cost = c;
        orders.Add(this);
    }
}