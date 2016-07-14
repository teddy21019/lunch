using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestaurantInfo : MonoBehaviour
{
    [SerializeField]
    private Text name;

    [SerializeField]
    private Text address;

    [SerializeField]
    private Text phone;

    [SerializeField]
    private Image star;

    protected Restaurant restaurant;

    public void Initialize(Restaurant rs)
    {
        restaurant = rs;
        name.text = restaurant.Name;
        address.text = restaurant.Address;
        phone.text = restaurant.PhoneNum;
        star.fillAmount = restaurant.Rank / 5f;
    }

    public void OnClickEdit()
    {
        PassEditData.ED.SetReference(restaurant);
        SceneManager.LoadScene("AddEditRes");
    }
}