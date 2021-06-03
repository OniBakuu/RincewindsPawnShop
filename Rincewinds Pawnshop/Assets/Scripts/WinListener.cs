using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinListener : MonoBehaviour
{
    public float goal;

    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerComp>().playerMoney >= goal)
        {
            SceneManager.LoadScene(2);
        }

        if (player.GetComponent<PlayerComp>().playerMoney == 0)
            SceneManager.LoadScene(3);


    }
}
