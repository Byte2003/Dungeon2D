using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 3;
    [SerializeField]
    private GameObject deathVFXPrefab;
    [SerializeField]
    private float baseKnockBackThrust = 15f; 
    private float knockBackThrust;
    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        SetDifficultyStats();
        currentHealth = startingHealth;
    }

    private void SetDifficultyStats()
    {
        switch (GameManager.Instance.currentDifficulty)
        {
            case Difficulty.Easy:
                startingHealth = 2;
                knockBackThrust = baseKnockBackThrust * 1.2f;  
                break;
            case Difficulty.Medium:
                startingHealth = 3;
                knockBackThrust = baseKnockBackThrust;
                break;
            case Difficulty.Hard:
                startingHealth = 5;
                knockBackThrust = baseKnockBackThrust * 0.8f;  
                break;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    public IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);
        }
    }
}
