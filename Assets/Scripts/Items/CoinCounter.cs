using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public ItemManager _itemManager;

    Text coinText;

    void Start()
    {
        coinText = GetComponent<Text>();
    }

    void Update()
    {
        coinText.text = _itemManager.coins.ToString();
    }
}
