using System.Collections;
using UnityEngine;

public class RestaurantChoise : RestaurantInfo
{
    public void onClickSelect()
    {
        OrderLine.orderLine.RestaurantChoise = restaurant;
        OrderLine.ToScene(2);
    }
}