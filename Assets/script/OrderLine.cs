using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrderLine : MonoBehaviour
{
    //singleton
    public static OrderLine orderLine;

    //

    public Dictionary<Eater, Food> order = new Dictionary<Eater, Food>();
    public Dictionary<Food, int> foodStats;

    public Restaurant RestaurantChoise { get; set; }
    public Eater CurrentEater { get; set; }
    public Food CurrentFood { get; set; }
    public DateTime datetime { get; set; }

    public Text currentCost;

    private void Awake()
    {
        if (orderLine == null)
        {
            DontDestroyOnLoad(gameObject);
            orderLine = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<Food, int> FoodStats()
    {
        Dictionary<Food, int> orderStat = new Dictionary<Food, int>();
        foreach (KeyValuePair<Eater, Food> p in order)
        {
            if (orderStat.ContainsKey(p.Value))
            {
                orderStat[p.Value]++;
            }
            else
            {
                orderStat.Add(p.Value, 1);
            }
        }
        return orderStat;
    }

    public int TotalCost()
    {
        int cost = 0;
        foreach (KeyValuePair<Food, int> p in foodStats)
        {
            cost += p.Key.prise * p.Value;
        }
        return cost;
    }

    public void OnClickEaterConfirmMeal()
    {
        if (order.ContainsKey(CurrentEater))
        {
            order[CurrentEater] = CurrentFood;
        }
        else
        {
            order.Add(CurrentEater, CurrentFood);
        }
        CurrentEater = null;
        CurrentFood = null;
    }

    public void AdminConfirmOrder()
    {
        datetime = DateTime.Now;
        foodStats = FoodStats();//統計數據並儲存

        ToScene(4);
    }

    public void BackToRestaurant()
    {
        orderLine = null;
        ToScene(1);
    }

    public static void ToScene(int i)
    {
        string scene = "order-" + i;
        SceneManager.LoadScene(scene);
    }
}