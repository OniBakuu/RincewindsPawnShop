using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComp : MonoBehaviour
{
    public float playerMoney = 250;
    public void AddMoney(float money)
    {
        playerMoney += money;
    }

    public void RemoveMoney(float money)
    {
        playerMoney -= money;
    }
}
