using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;

    private int _currentlife;
    private bool _isDead = false;

    [SerializeField] private FlashColor _flashColor;

    private void Awake()
    {
        Init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
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

        if(_flashColor != null)
        {
            _flashColor.Flash();
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
