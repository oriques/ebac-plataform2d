using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ecco.Core.Singleton;

public class UIInGameManager : Singleton<ItemManager>
{
    public TextMeshProUGUI uiTextCoins;

    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }

    public static void UpdateTextCoinsUltra(string s)
    {
        Instance.uiTextCoinsUltra.text = s;
    }

}
