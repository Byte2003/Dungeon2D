using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyDropdown : MonoBehaviour
{
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            GameManager.Instance.SetDifficulty(Difficulty.Easy);
        }
        if (val == 1)
        {
            GameManager.Instance.SetDifficulty(Difficulty.Medium);
        }
        if (val == 2)
        {
            GameManager.Instance.SetDifficulty(Difficulty.Hard);
        }
    }
}
