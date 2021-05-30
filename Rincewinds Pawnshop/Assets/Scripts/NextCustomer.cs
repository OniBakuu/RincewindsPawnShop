using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextCustomer : MonoBehaviour
{
    public Button nextButton;
    // Start is called before the first frame update
    void Awake()
    {
        
        nextButton.onClick.AddListener(DoNextCustomer);
    }

    // Update is called once per frame
    public void DoNextCustomer()
    {
        GameObject setup = GameObject.Find("EventSystem");
        GameObject dialog = GameObject.Find("DialogController");
        setup.GetComponent<SetupScene>().CreateNPC();
        setup.GetComponent<SetupScene>().CreateItem();
        dialog.GetComponent<DialogController>().DoGreeting();
        
    }
}
