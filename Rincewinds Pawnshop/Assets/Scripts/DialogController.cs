using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DialogController : MonoBehaviour
{
    public Text dialogBox;
    public string[] greetings;
    private GameObject item;
    public GameObject customer;
    public bool soldText = false;
    void Start()
    {
        

    }

    private void Update()
    {
        if (Input.anyKeyDown && customer.GetComponent<Customer>().countered == false)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
                return;
            
            dialogBox.text = "I'm looking to get " + (int)customer.GetComponent<Customer>().sharedNum + " for this " + item.GetComponent<PawnItem>().sharedName + ".";
        }
        
    }

    public void DoGreeting()
    {
        item = GameObject.Find("CustomerItem");
        dialogBox.text = greetings[Random.Range(0, greetings.Length)] + "\nPress Any Key...";
        
        //greetings.Append("Hark Friend, I have offer that you may quite intriguing.");
        //greetings.Append("Ohoho I'd sell you one of my relatives if I had any. Hahaha. That's a little joke.");
        //greetings.Append("I have goods if you have coin.");
    }

    // Displays text about sold item
    public void DisplaySoldText(string itemName)
    {
        soldText = true;
        // string display;
        switch (itemName)
        {
            case "Goblet":
                dialogBox.text = "placeholder text";
                break;
        }

    }
}
