using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    protected override void Oncollect()
    {
        base.Oncollect();
        ItemManager.Instance.AddCoins();



    }

}
