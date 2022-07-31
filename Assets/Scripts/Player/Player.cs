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

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpVFX;
    public AudioSource jumpSound;


    private void Awake()
    {
       if(healthbase != null)
        {
            healthbase.OnKill += OnPlayerKill;

        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);

    if( collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }


    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
        
    }


    private void OnPlayerKill()
    {
        healthbase.OnKill -= OnPlayerKill;

        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }



    private void Update()
    {
        IsGrounded();
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
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
           
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;
            DOTween.Kill(myRigidbody.transform);

            PlayJumpVFX();
            jumpSound.Play();
         

        }
    }
    private void PlayJumpVFX()
    {
        VFXmanager.Instance.PlayVFXbyType(VFXmanager.VFXType.JUMP, transform.position);
    }

  


    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
