using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{
    public Text restaurantName;
    public Text restaurantPhone;
    public Text totalCost;
    public Text totalPeople;
    public Text Date;

    public Transform content;
    public GameObject prefabStats;

    public Dictionary<Food, int> foodStats = OrderLine.orderLine.foodStats;

    private void Start()
    {
        foreach (Transform t in content)
        {
            Destroy(t.gameObject);
        }

        restaurantName.text = OrderLine.orderLine.RestaurantChoise.Name;
        restaurantPhone.text = OrderLine.orderLine.RestaurantChoise.PhoneNum;
        totalCost.text = "$" + TotalCost().ToString();
        totalPeople.text = "共" + TotalPeople().ToString() + "人";
        OrderLine.orderLine.datetime = DateTime.Now;
        Date.text = OrderLine.orderLine.datetime.ToString("yyyy/M/d HH:mm");
        FillContent();
    }

    public int TotalCost()
    {
        int cost = 0;
        foreach (var p in foodStats)
        {
            cost += p.Key.prise * p.Value;
        }
        return cost;
    }

    public int TotalPeople()
    {
        int count = 0;
        foreach (var p in foodStats)
        {
            count += p.Value;
        }
        return count;
    }

    public void FillContent()
    {
        var orderedStats = foodStats.ToList();
        orderedStats.Sort((y, x) => x.Value.CompareTo(y.Value));

        foreach (var p in orderedStats)
        {
            GameObject Go = Initiate.Instantiate(prefabStats, content);
            Go.GetComponent<StatsItem>().SetFoodStats(p.Key.name, p.Value);
        }
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}