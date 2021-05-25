using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComp : MonoBehaviour
{
    private float playerMoney = 250;

    public void AddMoney(float money)
    {
        playerMoney += money;
    }

    public void RemoveMoney(float money)
    {
        playerMoney -= money;
    }
}
