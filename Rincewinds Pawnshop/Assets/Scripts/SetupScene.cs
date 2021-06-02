using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEditor;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
public class SetupScene : MonoBehaviour
{
    public GameObject player;
    public GameObject customer;
    public Sprite CustSprite;
    public GameObject[] pawnItems;
    public GameObject dialogController;
    public GameObject customerItem;



    // Start is called before the first frame update
    void Awake()
    {
        // Assigns new values to item
        CreateItem();
        // Create NPC 
        CreateNPC();
        
        dialogController.GetComponent<DialogController>().DoGreeting();
    }

    public void CreateItem()
    {
        customerItem.transform.position = new Vector2(0, -3);

        // Set it's attributes to the same as chosen item
        int num = Random.Range(0, pawnItems.Length);
        customerItem.GetComponent<SpriteRenderer>().sprite = pawnItems[num].GetComponent<PawnItem>().itemSprite;
        customerItem.GetComponent<PawnItem>().sharedName = pawnItems[num].GetComponent<PawnItem>().sharedName;
        customerItem.GetComponent<PawnItem>().trueName = pawnItems[num].GetComponent<PawnItem>().trueName;
        customerItem.GetComponent<PawnItem>().auth = pawnItems[num].GetComponent<PawnItem>().auth;
        customerItem.GetComponent<PawnItem>().worth = pawnItems[num].GetComponent<PawnItem>().worth;
        customerItem.GetComponent<PawnItem>().transform.localScale = new Vector3((float) .15, (float) .15, (float) .15);
        //Scale rings smaller with an if
    }

    public void CreateNPC()
    {
        customer.GetComponent<SpriteRenderer>().sprite = CustSprite;
        customer.transform.position = new Vector2(-7, 0);
        
        customer.GetComponent<Customer>().personalty = customer.GetComponent<Customer>().personalities[Random.Range(0, customer.GetComponent<Customer>().personalities.Length)];
                
                switch (customer.GetComponent<Customer>().personalty)
                {
                    case "default":
                        customer.GetComponent<Customer>().minNumOffset = .25f;
                        customer.GetComponent<Customer>().maxNumOffset = .50f;
                        break;
                    case "dishonest":
                        customer.GetComponent<Customer>().minNumOffset = .50f;
                        customer.GetComponent<Customer>().maxNumOffset = .75f;
                        break;
                    case "unaware":
                        customer.GetComponent<Customer>().minNumOffset = -.35f;
                        customer.GetComponent<Customer>().maxNumOffset = -.50f;
                        break;
                }
                
                // Minimum number that customer would sell item for
                if(customer.GetComponent<Customer>().personalty == "unaware")
                    customer.GetComponent<Customer>().acceptNum = customerItem.GetComponent<PawnItem>().worth +
                                                              (customerItem.GetComponent<PawnItem>().worth * Random.Range(.25f, .50f));

                customer.GetComponent<Customer>().acceptNum = customerItem.GetComponent<PawnItem>().worth -
                                                              (customerItem.GetComponent<PawnItem>().worth * Random.Range(.25f, .50f));

                // Number that customer tells player that item is worth
                customer.GetComponent<Customer>().sharedNum = customerItem.GetComponent<PawnItem>().worth + (customerItem.GetComponent<PawnItem>().worth *
                    Random.Range(customer.GetComponent<Customer>().minNumOffset, customer.GetComponent<Customer>().maxNumOffset));
                

    }

}