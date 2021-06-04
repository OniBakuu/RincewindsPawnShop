using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Numerics;
using UnityEditor;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
public class SetupScene : MonoBehaviour
{
    public GameObject player;
    public GameObject customer;
    public Sprite custSprite;
    public GameObject[] pawnItems;
    public GameObject dialogController;
    public GameObject customerItem;
    private int sales;
    public List<String> bought;


    // Start is called before the first frame update
    void Awake()
    {
        // Assigns new values to item
        CreateItem();
        // Create NPC 
        CreateNPC();
        
        dialogController.GetComponent<DialogController>().UpdateMoney((int)player.GetComponent<PlayerComp>().playerMoney);
        dialogController.GetComponent<DialogController>().DoGreeting();
    }
    
    public void CreateItem()
    {
        customerItem.transform.position = new Vector2(0, -3);
        
        // Set it's attributes to the same as chosen item
        int num = Random.Range(0, pawnItems.Length);
        
        // prevent items from spawning more than once a playthrough
        if (bought.Contains(pawnItems[num].GetComponent<PawnItem>().trueName)) // this loop does not work as intended
        {
            CreateItem();
        }
        
        Debug.Log(pawnItems[num].GetComponent<PawnItem>().trueName);
        bought.Add(pawnItems[num].GetComponent<PawnItem>().trueName);
        
        customerItem.GetComponent<SpriteRenderer>().sprite = pawnItems[num].GetComponent<PawnItem>().itemSprite;
        customerItem.GetComponent<PawnItem>().sharedName = pawnItems[num].GetComponent<PawnItem>().sharedName;
        customerItem.GetComponent<PawnItem>().trueName = pawnItems[num].GetComponent<PawnItem>().trueName;
        customerItem.GetComponent<PawnItem>().auth = pawnItems[num].GetComponent<PawnItem>().auth;
        customerItem.GetComponent<PawnItem>().worth = pawnItems[num].GetComponent<PawnItem>().worth;
        customerItem.GetComponent<PawnItem>().transform.localScale = new Vector3((float) .15, (float) .15, (float) .15);

        customerItem.GetComponent<PawnItem>().sold = false;
        //Scale rings smaller with an if

        sales++;

        if (sales > pawnItems.Length)
            SceneManager.LoadScene(3);
    }

    public void CreateNPC()
    {
        customer.GetComponent<SpriteRenderer>().sprite = custSprite;
        customer.transform.position = new Vector2(-2, 0);
        customer.transform.localScale = new Vector2(.2f, .2f);
            
        customer.GetComponent<Customer>().personalty = customer.GetComponent<Customer>().personalities[Random.Range(0, customer.GetComponent<Customer>().personalities.Length)];
                if(customerItem.GetComponent<PawnItem>().auth == false)
                    customer.GetComponent<Customer>().personalty = "dishonest";
                
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
                if (customer.GetComponent<Customer>().personalty == "unaware")
                {
                    customer.GetComponent<Customer>().acceptNum = customerItem.GetComponent<PawnItem>().worth +
                                                                  (customerItem.GetComponent<PawnItem>().worth *
                                                                   Random.Range(.25f, .50f));

                    if (customer.GetComponent<Customer>().sharedNum < customer.GetComponent<Customer>().acceptNum)
                        customer.GetComponent<Customer>().acceptNum = customer.GetComponent<Customer>().sharedNum -
                                                                      (customer.GetComponent<Customer>().sharedNum *
                                                                       Random.Range(.10f, .20f));
                }

                customer.GetComponent<Customer>().acceptNum = customerItem.GetComponent<PawnItem>().worth -
                                                              (customerItem.GetComponent<PawnItem>().worth * Random.Range(.35f, .50f));

                // Number that customer tells player that item is worth
                customer.GetComponent<Customer>().sharedNum = customerItem.GetComponent<PawnItem>().worth + (customerItem.GetComponent<PawnItem>().worth *
                    Random.Range(customer.GetComponent<Customer>().minNumOffset, customer.GetComponent<Customer>().maxNumOffset));
                

    }

    public void ResetGame()
    {
        sales = 0;
        player.GetComponent<PlayerComp>().playerMoney = player.GetComponent<PlayerComp>().baseMoney;
    }

}