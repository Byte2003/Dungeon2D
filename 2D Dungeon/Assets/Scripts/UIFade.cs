using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField]
    private Image FadeScreen;
    [SerializeField]
    private float FadeSpeed = 1f;

    private IEnumerator FadeRount;

    public void FadeToBlack()
    {
        if (FadeRount is not null)
        {
            StopCoroutine(FadeRount);
        }

        FadeRount = FadeRountine(1);
        StartCoroutine(FadeRount);
    }

    public void FadeToClear()
    {
        if (FadeRount is not null)
        {
            StopCoroutine(FadeRount);
        }

        FadeRount = FadeRountine(0);
        StartCoroutine(FadeRount);
    }

    public IEnumerator FadeRountine(float targetAlpha)
    {
        while (!Mathf.Approximately(FadeScreen.color.a, targetAlpha))
        {
            FadeScreen.color = new Color(
                FadeScreen.color.r,
                FadeScreen.color.g,
                FadeScreen.color.b,
                Mathf.MoveTowards(FadeScreen.color.a, targetAlpha, FadeSpeed * Time.deltaTime)
            );
            yield return null;
        }
    }
}