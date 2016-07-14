using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EaterOrder : EaterItem
{
    public Text meal;
    public Food food;

    public void OnClickSelect()
    {
        OrderLine.orderLine.CurrentEater = person;
        OrderLine.ToScene(3);
    }

    public void LoadMeal()
    {
        if (OrderLine.orderLine.order.TryGetValue(person, out food))
        {
            meal.text = food.name;
        }
        else
        {
            meal.text = "";
        }
    }
}