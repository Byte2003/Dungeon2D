using System.Collections;
using System.Collections.Generic;
using Assets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyArea : MonoBehaviour
{
    [SerializeField]
    private BuffType buffType;
    [SerializeField]
    private int amount = 5;
    [SerializeField]
    private int cost = 5;

    private GameObject confirmMenu;
    private TMP_InputField titleText;

    void Start()
    {
        var uiCanvas = GameObject.Find("UI Canvas");
        confirmMenu = uiCanvas.transform.Find("ConfirmMenu").gameObject;
        GameObject titleObject = confirmMenu.transform.Find("Title").gameObject;
        titleText = titleObject.GetComponent<TMP_InputField>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            titleText.text = $"Do you want to buy {amount} {buffType.ToString().Replace("_", " ").ToLower()} with {cost} coins?";
            confirmMenu.SetActive(true);

            var isEnoughCoin = EconomyManager.Instance.GetCurrentGold() >= cost;
            var yesButton = confirmMenu.transform.Find("YesButton").GetComponent<Button>();
            yesButton.gameObject.SetActive(isEnoughCoin);

            if (isEnoughCoin)
            {
                yesButton.onClick.RemoveAllListeners();
                yesButton.onClick.AddListener(() => ConfirmManager.Instance.Buff(buffType, amount, cost));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            confirmMenu.SetActive(false);
        }
    }
}
