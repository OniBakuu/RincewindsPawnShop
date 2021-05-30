using System.Collections;
using System.Collections.Generic;
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
    public bool countered = false;
    public float minNumOffset;
    public float maxNumOffset;
    public void Start()
    {
        
    }
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
            
            // Display text about the item you bought i.e. whether it was real or not
            GameObject dialog = GameObject.Find("DialogController");
            dialog.GetComponent<DialogController>().DisplaySoldText(item.GetComponent<PawnItem>().trueName);
        }
            

    }

    public void CounterOffer()
    {
        countered = true;
        GameObject dialog = GameObject.Find("DialogText");
        if (sharedNum <= acceptNum)
            sharedNum *= Random.Range((float) .05, (float) .10);
        dialog.GetComponent<Text>().text = "Hmmm. Can you do " + sharedNum + "?";
    }
} // end 
