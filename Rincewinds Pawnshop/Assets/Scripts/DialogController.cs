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
    void Start()
    {
        item = GameObject.Find("CustomerItem");
        //greetings.Append("Hark Friend, I have offer that you may quite intriguing.");
        //greetings.Append("Ohoho I'd sell you one of my relatives if I had any. Hahaha. That's a little joke.");
        //greetings.Append("I have goods if you have coin.");

        dialogBox.text = greetings[Random.Range(0, greetings.Length)];
    }

    private void Update()
    {
        if (Input.anyKey && customer.GetComponent<Customer>().countered == false)
        {
            dialogBox.text = "I'm looking to get " + (int)customer.GetComponent<Customer>().sharedNum + " for this " + item.GetComponent<PawnItem>().name + ".";
        }
    }
}
