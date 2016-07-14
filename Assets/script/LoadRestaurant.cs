using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRestaurant : MonoBehaviour
{
    public static LoadRestaurant singleton;
    public int loadNum;
    private int currentDataIndex = 0;

    [Range(0, 3)]
    public float shakeTreshHold = 2.80f;

    [SerializeField]
    private GameObject prefabRestaurant;

    [SerializeField]
    private Transform content;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        LoadData();
    }

    private void Update()
    {
        if (Input.acceleration.magnitude > shakeTreshHold)
        {
            int i = Data.data.restaurant.Count - 1;
            int ranChoise = Random.Range(0, i);
            OrderLine.orderLine.RestaurantChoise = Data.data.restaurant[ranChoise];
            OrderLine.ToScene(2);
        }
    }

    public void LoadData()
    {
        foreach (Transform t in content)
        {
            Destroy(t.gameObject);
        }
        int dataNum = Data.data.restaurant.Count;
        if (dataNum < loadNum)
        {
            LoadNew(dataNum);
        }
        else
            LoadNew(loadNum);
    }

    public void LoadNew(int l)
    {
        for (int i = 0; i < l; i++)
        {
            Restaurant rs = Data.data.restaurant[i];
            GameObject GO = Initiate.Instantiate(prefabRestaurant, content);
            GO.GetComponent<RestaurantInfo>().Initialize(rs);
        }
    }

    public void ToStartPage()
    {
        SceneManager.LoadScene("main menu");
    }

    public void OnClickAddMore()
    {
        List<Restaurant> newData = CSV.ReadRestaurantCSV(@"C:\Users\User\Desktop\Unity\訂便當\restaurants2.csv");
        Data.data.restaurant.AddRange(newData);
        Initiate.WriteData("data");
        LoadData();
    }
}