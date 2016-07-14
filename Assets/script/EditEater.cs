using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EditEater : MonoBehaviour
{
    [SerializeField]
    private InputField nameInput;

    private Eater personToEdit;

    private CanvasGroup CanvasGroup_Edit;
    private CanvasGroup CanvasGroup_ConfirmDel;

    private void Start()
    {
        CanvasGroup_Edit = ViewportControl.Singleton.CanvasGroup_Edit;
        CanvasGroup_ConfirmDel = ViewportControl.Singleton.CanvasGroup_ConfirmDel;
    }

    public void Edit(Eater eater)
    {
        Fade.Show(ViewportControl.Singleton.CanvasGroup_Edit);          //打開編輯室窗
        nameInput.text = eater.name;        //填入eater name
        personToEdit = eater;               //指定編輯的person為傳入的eater
    }

    public void OnClickSubmit()             //確定編輯
    {
        personToEdit.name = nameInput.text; //取得編輯欄位並改變eater資訊
        Fade.Hide(CanvasGroup_Edit);        //關閉編輯視窗
        ViewportControl.Singleton.UpdateEater();
        Initiate.WriteData("data");
    }

    public void OnClickDelete()             //按下刪除鍵時
    {
        Fade.Show(CanvasGroup_ConfirmDel);      //顯示刪除確認
    }

    public void OnClickSureDel()            //確認刪除
    {
        Data.data.eaters.Remove(personToEdit);          //從data中刪除
        Fade.Hide(CanvasGroup_ConfirmDel);     //關閉刪除確認
        Fade.Hide(CanvasGroup_Edit);            //關閉編輯室窗
        ViewportControl.Singleton.UpdateEater();
        Initiate.WriteData("data");
    }

    public void onClickRegret()
    {
        Fade.Hide(CanvasGroup_ConfirmDel);     //關閉刪除確認視窗
    }
}