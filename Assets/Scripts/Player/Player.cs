using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public HealthBase healthbase;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    // public Animator animator;

    private Animator _currentPlayer;

    private float _currentSpeed;



    private void Awake()
    {
       if(healthbase != null)
        {
            healthbase.OnKill += OnPlayerKill;

        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);


    }

    private void OnPlayerKill()
    {
        healthbase.OnKill -= OnPlayerKill;

        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }



    private void Update()
    {
        HandleMoviment();
        HandleJump();
        
    } 

    private void HandleMoviment()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.SetBool(soPlayerSetup.runFaster, true);
        }

        else 
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.SetBool(soPlayerSetup.runFaster, false);
        }
            

        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }

        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
            _currentPlayer.SetBool(soPlayerSetup.runFaster, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;
            DOTween.Kill(myRigidbody.transform);

        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
