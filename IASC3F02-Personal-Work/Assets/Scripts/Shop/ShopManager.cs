using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int playerCoins = 0; // Player's starting coins
    public Text coinText;                          // UI element showing player's coins
    public ShopItem[] shopItems;                   // Array of shop items
    public GameObject shopUI;                      // The shop UI container
    public GameObject itemPrefab;
    void Start()
    {
        UpdateCoinUI();
        GenerateShopUI();
    }

    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + playerCoins;
    }


    void GenerateShopUI()
    {
        foreach (ShopItem shopItem in shopItems)
        {
            for (int i = 0; i < shopItem.itemNames.Length; i++)
            {
                if (string.IsNullOrEmpty(shopItem.itemNames[i])) continue; // Skip empty items

                // Instantiate a shop item button
                GameObject itemButton = Instantiate(itemPrefab, shopUI.transform);

                // Set the UI elements for the item
                itemButton.transform.Find("ItemName").GetComponent<Text>().text = shopItem.itemNames[i];
                itemButton.transform.Find("ItemPrice").GetComponent<Text>().text = shopItem.prices[i] + " Coins";
                itemButton.transform.Find("ItemImage").GetComponent<Image>().sprite = shopItem.itemImages[i];

                // Configure the "Buy" button
                Button buyButton = itemButton.transform.Find("BuyButton").GetComponent<Button>();
                if (shopItem.isPurchased[i])
                {
                    buyButton.interactable = false;
                    buyButton.transform.Find("Text").GetComponent<Text>().text = "Purchased";
                }
                else
                {
                    int index = i; // Capture the loop variable to avoid closure issues
                    buyButton.onClick.AddListener(() => BuyItem(shopItem, index, buyButton));
                }
            }
        }
    }

    void BuyItem(ShopItem shopItem, int index, Button button)
    {
        // Check if the player has enough coins and the item hasn't been purchased
        if (playerCoins >= shopItem.prices[index] && !shopItem.isPurchased[index])
        {
            playerCoins -= shopItem.prices[index];         // Deduct the item's price from the player's coins
            shopItem.isPurchased[index] = true;           // Mark the item as purchased
            UpdateCoinUI();                               // Update the coin display
            button.interactable = false;                  // Disable the "Buy" button
            button.transform.Find("Text").GetComponent<Text>().text = "Purchased";
            Debug.Log("Bought: " + shopItem.itemNames[index]);
        }
        else if (shopItem.isPurchased[index])
        {
            Debug.Log("Item already purchased.");
        }
        else
        {
            Debug.Log("Not enough coins.");
        }

    }







}
