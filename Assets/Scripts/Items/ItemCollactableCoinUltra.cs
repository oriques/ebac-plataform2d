using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoinUltra : ItemCollactableBase
{
    protected override void Oncollect()
    {
        base.Oncollect();
        ItemManager.Instance.AddCoinsUltra();



    }

}
