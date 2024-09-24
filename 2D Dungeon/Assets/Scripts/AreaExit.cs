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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            SceneManager.LoadScene(SceneToLoad);
            SceneManagement.Instance.SetTransitionName(SceneTransitionName);
        }
    }
}
