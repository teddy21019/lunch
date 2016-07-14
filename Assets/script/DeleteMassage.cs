using System.Collections;
using UnityEngine;

public class DeleteMassage : MonoBehaviour
{
    private Eater eaterToDel;

    public void GetEater(Eater eater)
    {
        eaterToDel = eater;
    }

    public void OnCickConfirm()
    {
        Data.data.eaters.Remove(eaterToDel);
    }

    public void OnClickRegret()
    {
    }
}