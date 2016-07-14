using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MealStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabInput;

    //============
    [SerializeField]
    private InputField foodName;

    [SerializeField]
    private InputField foodPrize;

    //=============
    [SerializeField]
    private Text foodNameText;

    [SerializeField]
    private Text foodPrizeText;

    //============

    public Food food;

    [SerializeField]
    private bool canAdd;

    public void SetMealStatus()
    {
        food = new Food();
        canAdd = true;
        InitializeInput();
    }

    public void SetMealStatus(Food f)   //set meal status with parameter--create non-addable row
    {
        food = f;
        canAdd = false;
        InitializeInput();
    }

    public void ShowFoodInfo(Food f)
    {
        food = f;
        foodNameText.text = food.name;
        foodPrizeText.text = "$" + food.prise.ToString();
    }

    public void OnClickAppend()
    {
        if (canAdd)
        {
            GameObject GO = Initiate.Instantiate(FormManager.singleton.prefabInput, FormManager.singleton.meals);
            GO.GetComponent<MealStatus>().SetMealStatus();
            FormManager.singleton.screct.verticalNormalizedPosition = 0;
        }
        canAdd = false;
    }

    public void InitializeInput()
    {
        foodName.text = food.name;
        if (food.prise == 0)
        {
            foodPrize.text = "";
        }
        else
            foodPrize.text = food.prise.ToString();
    }

    public void OnClickSelect()
    {
        OrderLine.orderLine.CurrentFood = food;
        OrderLine.orderLine.OnClickEaterConfirmMeal();
        OrderLine.ToScene(2);
    }
}