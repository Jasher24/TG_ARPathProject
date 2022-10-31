using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelOptions : MonoBehaviour
{
    [SerializeField]
    float duration;
    [SerializeField]
    float delay;

    [SerializeField]
    RectTransform target;

    [SerializeField]
    Vector2 startPoint;
    [SerializeField]
    Vector2 finalPoint;

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(startPoint, finalPoint));
    }
    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(finalPoint, startPoint));
    }

    IEnumerator FadeInCoroutine(Vector2 v1, Vector2 v2)
    {
        Vector2 startPoint = v1;
        Vector2 finalPoint = v2;
        float elapsed = 0;
        while (elapsed <= delay)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0;
        while(elapsed <= duration)
        {
            float percentage = elapsed / duration;
            elapsed += Time.deltaTime;
            Vector2 currentPosition = Vector2.Lerp(startPoint, finalPoint, percentage);
            target.anchoredPosition = currentPosition;
            yield return null;
        }
        target.anchoredPosition = finalPoint;
    }
    /*
    IEnumerator FadeOurCoroutine()
    {

    }*/
}
