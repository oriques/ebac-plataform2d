using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.GetComponent<HealthBase>();
        
        if (health != null)
        {
            health.Damage(damage);
        }
    }
}
