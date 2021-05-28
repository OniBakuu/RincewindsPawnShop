using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfferListener : MonoBehaviour
{

    public Button OfferButton;
    public InputField OfferField;
    
    // Start is called before the first frame update
    void Awake()
    {
        OfferButton.onClick.AddListener(DoOffer); 
    }

    // Update is called once per frame
    void DoOffer()
    {
        float offer = float.Parse(OfferField.text);
        
        GameObject customer = GameObject.Find("Customer");
        customer.GetComponent<Customer>().HandleOffer(offer);
    }
}
