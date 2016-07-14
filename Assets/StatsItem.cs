using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsItem : MonoBehaviour
{
    public Text foodName;
    public Text foodCount;

    private string food;
    private string count;

    public void SetFoodStats(string food, int count)
    {
        this.food = food;
        this.count = count.ToString();
        Initiate();
    }

    public void Initiate()
    {
        foodName.text = food;
        foodCount.text = count;
    }
}