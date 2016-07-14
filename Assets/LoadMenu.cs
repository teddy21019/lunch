using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabInput;

    [SerializeField]
    private Transform meals;

    [SerializeField]
    private Text nowEater;

    private Restaurant rs = OrderLine.orderLine.RestaurantChoise;

    [Range(0, 3)]
    public float shakeThreshHold;

    private void Start()
    {
        ShowEater();
        LoadIn();
    }

    private void Update()
    {
        if (Input.acceleration.magnitude > shakeThreshHold)
        {
            int i = OrderLine.orderLine.RestaurantChoise.menu.Count - 1;
            int ranChoise = Random.Range(0, i);
            OrderLine.orderLine.CurrentFood = OrderLine.orderLine.RestaurantChoise.menu[ranChoise];
            OrderLine.orderLine.OnClickEaterConfirmMeal();
            OrderLine.ToScene(2);
        }
    }

    public void LoadIn()
    {
        foreach (Transform tf in meals)
        {
            Destroy(tf.gameObject);
        }
        foreach (Food f in rs.menu)
        {
            GameObject GO = Initiate.Instantiate(prefabInput, meals);
            GO.GetComponent<MealStatus>().ShowFoodInfo(f);
        }
    }

    public void ShowEater()
    {
        nowEater.text = OrderLine.orderLine.CurrentEater.name + "，今天想吃什麼？";
    }

    public void OnClickReturn()
    {
        SceneManager.LoadScene("order-2");
    }
}