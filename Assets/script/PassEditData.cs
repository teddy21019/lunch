using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassEditData : MonoBehaviour
{
    //set singleton
    public static PassEditData ED;

    private void Awake()
    {
        ED = this;
    }

    private Restaurant restaurantToEdit;

    public void SetReference(Restaurant rs)
    {
        ED.restaurantToEdit = rs;
    }

    public Restaurant GetReference()
    {
        return ED.restaurantToEdit;
    }

    public void OnClickAdd()
    {
        ED.restaurantToEdit = new Restaurant();
        SceneManager.LoadScene("AddEditRes");
    }

    public void ClearData()
    {
        //建立檔案
        Initiate.WriteData("data");
        //重設
        ED.restaurantToEdit = null;
    }
}