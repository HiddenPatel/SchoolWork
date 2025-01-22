using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public string[] itemNames = new string[3]; // Array to hold up to 3 item names
    public int[] prices = new int[3];         // Array to hold the prices for each item
    public Sprite[] itemImages = new Sprite[3]; // Array to hold the sprites for each item
    public bool[] isPurchased = new bool[3];    // Array to track if each item is purchased
}
