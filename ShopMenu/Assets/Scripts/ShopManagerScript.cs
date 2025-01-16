using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[4,4];
    public float coins;
    public Text CoinsTXT;
   // public float quantity;



   
    void Start()
    {
        CoinsTXT.text = "Coins:" + coins.ToString();


       //Id's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        // Price 
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;

        //Quantity 
        //shopItems[3, 1] = 1;
       // shopItems[3, 2] = 1;
        //shopItems[3, 3] = 1;




    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            //Minus Money
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            //Minus quantity 
            //shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
           // if (quantity >= shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID])
            {
            //    quantity -= shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID];
               // shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
            }  
            

            CoinsTXT.text = "Coins: " + coins.ToString();

           // ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
      
        
    }
}
