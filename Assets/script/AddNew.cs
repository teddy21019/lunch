using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddNew : MonoBehaviour
{
    [SerializeField]
    private InputField newName;

    private void OnEnable()
    {
        newName.text = "";
    }

    public void OnClickInsert()
    {
        string name = newName.text;
        if (name != "")
        {
            Data.data.eaters.Add(new Eater(name));
        }
        Fade.Hide(ViewportControl.Singleton.CanvasGroup_Add);

        ViewportControl.Singleton.UpdateEater();
        Initiate.WriteData("data");
    }
}