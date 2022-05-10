using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;

    private int _currentlife;
    private bool _isDead = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentlife = startLife;
    }

    public void Damage (int damage)
    {
        if (_isDead) return;
        
        _currentlife -= damage;
        
        if (_currentlife <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        _isDead = true;
        
        if(destroyOnKill)
        {
            Destroy(gameObject);
        }
    }



}
