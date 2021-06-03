using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.UI;

//Holds customer information and methods
public class Customer : MonoBehaviour
{
    public string personalty; //have different if time
    public string[] personalities;
    public float sharedNum;
    public float acceptNum;
    public GameObject item;
    public bool countered;
    public float minNumOffset;
    public float maxNumOffset;

    //Receives offer made by player
    public void HandleOffer(float offer)
    {

        if (acceptNum > offer)
        {
            CounterOffer();
        }
        else
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerComp>().RemoveMoney(offer);
            player.GetComponent<PlayerComp>().AddMoney(item.GetComponent<PawnItem>().worth);
            item.GetComponent<PawnItem>().sold = true;
            
            
            GameObject dialog = GameObject.Find("DialogController");
            // Display text about the item you bought i.e. whether it was real or not
            dialog.GetComponent<DialogController>().DisplaySoldText(item.GetComponent<PawnItem>().trueName);
            dialog.GetComponent<DialogController>().UpdateMoney((int)player.GetComponent<PlayerComp>().playerMoney);
        }
            

    }

    public void CounterOffer()
    {
        countered = true;
        GameObject dialog = GameObject.Find("DialogText");
        sharedNum = sharedNum - (sharedNum * Random.Range(.05f, .10f));
        if (sharedNum <= acceptNum)
        {
            sharedNum = acceptNum;
        }
        
        dialog.GetComponent<Text>().text = "Hmmm. Can you do " + (int)sharedNum + "?";
    }
} // end 
