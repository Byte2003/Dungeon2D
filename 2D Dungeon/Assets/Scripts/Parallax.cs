using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float ParallaxOffset = 0.5f; // Parallax coefficient, a value less than 1 gives the illusion of the object being further away

    private Camera Cam;
    private Vector2 StartPos;
    private Vector2 StartCamPos;

    private void Awake()
    {
        Cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        StartCamPos = Cam.transform.position;
    }

    void FixedUpdate()
    {
        Vector2 travel = (Vector2)Cam.transform.position - StartCamPos; // Calculate the change in the camera's position
        transform.position = StartPos + travel * ParallaxOffset; // Apply the standard formula for parallax
    }
}