using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
 * The EaterItem class tackles all behavior assotiated with the eater item
 */

public class EaterItem : MonoBehaviour
{
    public Text eaterName;
    public Text eaterChoise;
    public Eater person;

    public void SetEater(Eater eater)  //當eater item被建立時
    {
        person = eater;
        eaterName.text = eater.name;
        if (eaterChoise != null)
        {
            Food f;
            if (OrderLine.orderLine.order.TryGetValue(eater, out f))
                eaterChoise.text = f.name;
            else
            {
                eaterChoise.text = "";
            }
        }

        //others
    }

    public void onClickEdit()
    {
        ViewportControl.Singleton.EditForm.Edit(person);  //將Eater資訊傳給編輯視窗的script
    }
}