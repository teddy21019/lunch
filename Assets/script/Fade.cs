using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Fade
{
    public static void Show(CanvasGroup toShow, float duration = 0.4f)
    {
        GameObject GO = toShow.gameObject;
        toShow.alpha = 0;
        toShow.transform.localScale = Vector3.one * 1.3f;
        GO.SetActive(true);
        toShow.DOFade(1, duration);
        toShow.transform.DOScale(Vector3.one, duration);
    }

    public static void Hide(CanvasGroup toHide, float duration = 0.3f)
    {
        GameObject GO = toHide.gameObject;
        toHide.DOFade(0, duration).OnComplete(() => GO.SetActive(false));

        // GO.SetActive(false);
    }
}