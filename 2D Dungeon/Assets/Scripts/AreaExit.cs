using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private string SceneToLoad;
    [SerializeField]
    private string SceneTransitionName;

    private float WaitToLoadTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            SceneManagement.Instance.SetTransitionName(SceneTransitionName);
            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());
        }
    }

    private IEnumerator LoadSceneRoutine()
    {
        while (WaitToLoadTime >= 0)
        {
            WaitToLoadTime -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(SceneToLoad);
    }
}
