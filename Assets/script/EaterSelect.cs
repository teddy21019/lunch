using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EaterSelect : ViewportControl
{
    [SerializeField]
    private Text nowRes;

    [SerializeField]
    private Text nowCost;

    private void Start()
    {
        ShowCost();
        nowRes.text = OrderLine.orderLine.RestaurantChoise.Name;
        UpdateEater();
    }

    public void OnClickChooseRest()
    {
        OrderLine.orderLine.BackToRestaurant();
    }

    public void ShowCost()
    {
        int cost = 0;
        foreach (KeyValuePair<Eater, Food> p in OrderLine.orderLine.order)
        {
            cost += p.Value.prise;
        }
        nowCost.text = "現在金額：" + cost.ToString();
    }

    public void OnClickConfirmOrder()
    {
        OrderLine.orderLine.AdminConfirmOrder();
    }
}