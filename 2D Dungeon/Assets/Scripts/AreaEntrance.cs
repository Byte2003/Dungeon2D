using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    [SerializeField]
    private string TransitionName;


    // Start is called before the first frame update
    void Start()
    {
        if (TransitionName == SceneManagement.Instance.SceneTransitionName)
        {
            PlayerController.Instance.transform.position = transform.position;
        }
    }
}
