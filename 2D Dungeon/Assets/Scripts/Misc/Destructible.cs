using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    private GameObject DestroyVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSource>() || collision.GetComponent<Projectile>())
        {
            GetComponent<PickUpSpawner>().DropItems();
            Instantiate(DestroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
