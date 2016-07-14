using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormManager : MonoBehaviour
{
    public InputField restaurantName;

    public InputField restaurantPhone;

    public InputField restaurantAddress;

    public GameObject prefabInput;

    public Transform meals;

    public ScrollRect screct;

    public CanvasGroup ReturnCG;
    public CanvasGroup DeleteCG;

    private Restaurant rs = PassEditData.ED.GetReference();

    //singleton
    public static FormManager singleton;

    public void Awake()
    {
        singleton = this;
    }

    public void Start()
    {
        OnClickClear();
        LoadResValue();
        LoadMenu();
    }

    public void LoadResValue()          //填入標單資料
    {
        restaurantName.text = rs.Name;
        restaurantPhone.text = rs.PhoneNum;
        restaurantAddress.text = rs.Address;
    }

    public void ChangeResValue()
    {
        rs.Name = restaurantName.text;
        rs.PhoneNum = restaurantPhone.text;
        rs.Address = restaurantAddress.text;
        List<string> mealInput = new List<string>();
        List<string> priseInput = new List<string>();
        List<Food> foodInShow = new List<Food>();
        foreach (Transform meal in meals)
        {
            //meal.GetComponent<>();
            mealInput.Add(meal.GetChild(0).GetComponent<InputField>().text);
            priseInput.Add(meal.GetChild(1).GetComponentInChildren<InputField>().text);
            foodInShow.Add(meal.GetComponent<MealStatus>().food);
        }
        for (int i = 0; i < meals.childCount - 1; i++)//don't add last one
        {
            string name = mealInput[i];
            int prise = int.Parse(priseInput[i]);
            Food food = foodInShow[i];
            if (name != "")
                rs.ChangeMunu(name, prise, food);
        }
        if (!Data.data.restaurant.Contains(rs))
        {
            Data.data.restaurant.Add(rs);
        }

        ReturnList();
    }

    public void OnPopReturn()
    {
        Fade.Show(ReturnCG);
    }

    public void OnPopDelete()
    {
        Fade.Show(DeleteCG);
    }

    public void OnClickClear()
    {
        GameObject[] GOS = GameObject.FindGameObjectsWithTag("HideFirst");
        foreach (var GO in GOS)
        {
            Fade.Hide(GO.GetComponent<CanvasGroup>());
        }
    }

    public void DeleteRestaurant()
    {
        if (Data.data.restaurant.Contains(rs))
            Data.data.restaurant.Remove(rs);
        ReturnList();
    }

    public void ReturnList()
    {
        PassEditData.ED.ClearData();            //清空pass edit data的restaurant 內容
        SceneManager.LoadScene("restaurant");   //回到餐廳頁面
        //重載
    }

    public void LoadMenu()
    {
        foreach (Food f in rs.menu)
        {
            GameObject GO = Initiate.Instantiate(prefabInput, meals);
            GO.GetComponent<MealStatus>().SetMealStatus(f);
        }
        //往下延伸空白
        GameObject GO2 = Initiate.Instantiate(prefabInput, meals);
        GO2.GetComponent<MealStatus>().SetMealStatus();
    }
}