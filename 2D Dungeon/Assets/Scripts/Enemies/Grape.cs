using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour, IEnemy
{
    [SerializeField]
    private GameObject grapeProjectilePrefab;
    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;
    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);
        if (transform.position.x - PlayerController.Instance.transform.position.x < 0)
        {
            spriteRenderer.flipX = false;
        } else
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SpawnProjectileAnimEvent()
    {
        Instantiate(grapeProjectilePrefab, transform.position, Quaternion.identity);
    }
}
