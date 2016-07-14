using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewportControl : MonoBehaviour
{
    public static ViewportControl Singleton;
    public GameObject eaterPrefab;
    public Transform content;

    public EditEater EditForm;

    //canvasgroup
    public CanvasGroup CanvasGroup_Add;

    public CanvasGroup CanvasGroup_ConfirmDel;

    public CanvasGroup CanvasGroup_Edit;

    private void Start()
    {
        Singleton = this;
        GameObject[] GO = GameObject.FindGameObjectsWithTag("HideFirst");
        foreach (GameObject Go in GO)
        {
            Go.SetActive(false);
        }
        UpdateEater();
    }

    public void UpdateEater()
    {
        foreach (Transform tf in content)
        {
            Destroy(tf.gameObject);
            Debug.Log("destroyed");
        }

        foreach (var eater in Data.data.eaters)
        {
            GameObject Go = Initiate.Instantiate(eaterPrefab, content);
            Go.GetComponent<EaterItem>().SetEater(eater);
        }
    }

    public void onClickAdd()
    {
        Fade.Show(CanvasGroup_Add);
    }

    public void OnClickToCancle()
    {
        GameObject[] G = GameObject.FindGameObjectsWithTag("HideFirst");
        foreach (GameObject g in G)
        {
            g.SetActive(false);
        }
    }

    public void ToStartPage()
    {
        SceneManager.LoadScene("main menu");
    }
}