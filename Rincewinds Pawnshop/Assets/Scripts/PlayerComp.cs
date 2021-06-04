using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComp : MonoBehaviour
{
    public float playerMoney = 500;
    public float baseMoney = 500;
    public void AddMoney(float money)
    {
        playerMoney += money;
    }

    public void RemoveMoney(float money)
    {
        playerMoney -= money;
    }
}
