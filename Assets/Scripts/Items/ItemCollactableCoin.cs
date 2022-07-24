using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider2D collider;

    protected override void Oncollect()
    {
        base.Oncollect();
        ItemManager.Instance.AddCoins();
        collider.enabled = false;

    }

}
