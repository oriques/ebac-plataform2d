using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public HealthBase healthbase;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f,0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string runFaster = "Faster";
    public string triggerDeath = "Death";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    private float _currentSpeed;



    private void Awake()
    {
       if(healthbase != null)
        {
            healthbase.OnKill += OnPlayerKill;

        }
    }

    private void OnPlayerKill()
    {
        healthbase.OnKill -= OnPlayerKill;

        animator.SetTrigger(triggerDeath);
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
            _currentSpeed = speedRun;
            animator.SetBool(runFaster, true);
        }

        else 
        {
            _currentSpeed = speed;
            animator.SetBool(runFaster, false);
        }
            

        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }

        else
        {
            animator.SetBool(boolRun, false);
            animator.SetBool(runFaster, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += friction;
        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            myRigidbody.velocity = Vector2.up * forceJump;
            DOTween.Kill(myRigidbody.transform);

        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
