using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEditor;
using Vector2 = UnityEngine.Vector2;
public class SetupScene : MonoBehaviour
{

    public Sprite CustSprite;
    public  GameObject[] pawnItems;

    
    
    // Start is called before the first frame update
    void Awake()
    {
        // Create NPC 
        GameObject cus = GameObject.Find("Customer");
        cus.GetComponent<SpriteRenderer>().sprite = CustSprite;
        cus.transform.position = new Vector2(-7, 0);

        GameObject pItem = new GameObject();
        pItem.AddComponent<SpriteRenderer>();
        pItem.AddComponent<PawnItem>();
        ChooseItem(pItem);
        pItem.transform.position = new Vector2(0, -1);
    }

    private void ChooseItem(GameObject item)
    {
        int num = Random.Range(0, pawnItems.Length);
        item.GetComponent<SpriteRenderer>().sprite = pawnItems[num].GetComponent<PawnItem>().itemSprite;
        item.GetComponent<PawnItem>().name = pawnItems[num].GetComponent<PawnItem>().name;
        item.GetComponent<PawnItem>().auth = pawnItems[num].GetComponent<PawnItem>().auth;
        item.GetComponent<PawnItem>().cost = pawnItems[num].GetComponent<PawnItem>().cost;
        item.name = pawnItems[num].GetComponent<PawnItem>().name;
    }

}
