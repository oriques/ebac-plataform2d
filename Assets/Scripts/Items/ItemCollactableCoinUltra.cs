using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoinUltra : ItemCollactableBase
{

    public Collider2D collider;
    protected override void Oncollect()
    {
        base.Oncollect();
        ItemManager.Instance.AddCoinsUltra();
        collider.enabled = false;



    }

}
