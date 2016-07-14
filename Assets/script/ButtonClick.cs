using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void onClickOrder()
    {
        SceneManager.LoadScene("order-1");
    }

    public void onClickRestaurant()
    {
        SceneManager.LoadScene("restaurant");
    }

    public void onClickEater()
    {
        SceneManager.LoadScene("eater");
    }
}