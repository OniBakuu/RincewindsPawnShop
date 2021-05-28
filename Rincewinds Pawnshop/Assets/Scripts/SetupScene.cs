using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEditor;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

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
        // Create NPC 
        customer.GetComponent<SpriteRenderer>().sprite = CustSprite;
        customer.transform.position = new Vector2(-7, 0);
        // Create the new object in scene
        CreateItem();
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
        
        
    }

}