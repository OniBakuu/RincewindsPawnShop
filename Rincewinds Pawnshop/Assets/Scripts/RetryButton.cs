using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{

    public Button retryButton;
    //public GameObject setup;
    // Start is called before the first frame update
    void Start()
    {
        retryButton.onClick.AddListener(Retry);
    }

    // Update is called once per frame
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
