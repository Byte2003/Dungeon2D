using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameCoinPrefab;

    public void DropItems()
    {
        Instantiate(gameCoinPrefab, transform.position, Quaternion.identity);
    }
}
