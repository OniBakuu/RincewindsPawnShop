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
    public Text money;

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
            case "Fool's Gold Goblet":
                dialogBox.text = "Hmmm turns out it was a goblet made of fool's gold. Better luck next time!";
                break;
            case "Bottomless Grail":
                dialogBox.text = "The clay goblet turned out to be a bottomless grail! What a find!";
                break;
            case "Clay Goblet":
                dialogBox.text = "Oh. It's just a normal clay goblet. No magic here.";
                break;
            case "Jeweled Goblet":
                dialogBox.text = "Wow this actually was a jeweled goblet.";
                break;
            case "Band of Fool's Gold":
                dialogBox.text = "A band of fool's gold is all this is. A pity.";
                break;
            case "Glass Tiara":
                dialogBox.text = "The gem is simply glass. At least it looks pretty huh?";
                break;
            case "Ring of Water Walking":
                dialogBox.text = "Not just a sapphire. A ring of water walking. How rare!";
                break;
            case "Red Glass":
                dialogBox.text = "Fat red crystal? Nope just red glass, nothing to see here.";
                break;
            case "Shard of Crystal Golem":
                dialogBox.text = "A clueless adventurer indeed. This is a shard of a crystal golem!";
                break;
            case "Greater Mana Crystal":
                dialogBox.text = "This pretty purple crystal is packed full of mana, valuable indeed";
                break;
        }

    }

    public void UpdateMoney(int amount)
    {
        money.text = "Gold: " + amount;
    }
}
