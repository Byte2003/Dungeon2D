using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Transparent : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField]
    private float TransparentAmount = 0.8f;
    [SerializeField]
    private float FadeTime = 0.4f;

    private SpriteRenderer SpriteRenderer;
    private Tilemap Tilemap;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (SpriteRenderer)
            {
                StartCoroutine(FadeRountine(SpriteRenderer, FadeTime, SpriteRenderer.color.a, TransparentAmount));
            }
            else if (Tilemap)
            {
                StartCoroutine(FadeRountine(Tilemap, FadeTime, Tilemap.color.a, TransparentAmount));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (SpriteRenderer)
            {
                StartCoroutine(FadeRountine(SpriteRenderer, FadeTime, SpriteRenderer.color.a, 1f));
            }
            else if (Tilemap)
            {
                StartCoroutine(FadeRountine(Tilemap, FadeTime, Tilemap.color.a, 1f));
            }
        }
    }

    private IEnumerator FadeRountine(SpriteRenderer spriteRenderer, float fadeTime, float startValue, float targetTransparency)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
            yield return null;
        }
    }

    private IEnumerator FadeRountine(Tilemap tilemap, float fadeTime, float startValue, float targetTransparency)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapsedTime / fadeTime);
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, newAlpha);
            yield return null;
        }
    }
}