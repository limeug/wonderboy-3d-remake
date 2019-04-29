using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLogic : MonoBehaviour
{
   
    public GameObject axeSpawner;
    private Animator anim;
    public KeyCode RightKey;
    public KeyCode LeftKey;
    public KeyCode JumpKey;
    HeroStats heroStats;
    public bool spring = false;
    public bool hill = false;
   

    private CharacterController myController;
    
    //jump variables
    public float gravityForce;
    public float ySpeed;
    public float jumpForce;
    public float hangTime;
    public float hangTimer;
    public float gravityModifier;

    //run variables
    public float forwardSpeed;
    public float runSpeed;
    public float lerpTime;

    void myGravity()
    {
        ySpeed = myController.velocity.y;
        ySpeed -= gravityForce * Time.deltaTime;
    }

    void ForwardMovement()
    {
        if (Input.GetKey(RightKey) || Input.GetKey(LeftKey))
        {
            if (myController.isGrounded)
            {
                if (forwardSpeed <= runSpeed - .1f || forwardSpeed >= runSpeed + .1f)
                {
                    forwardSpeed = Mathf.Lerp(forwardSpeed, runSpeed, lerpTime);
                }
                else
                {
                    forwardSpeed = runSpeed;
                }
            }
        }
        else
        {
            forwardSpeed = 0;
        }
    }

    void SpeedApply()
    {
        myController.Move(transform.forward * forwardSpeed * Time.deltaTime);
        myController.Move(new Vector3(0, ySpeed, 0) * (Time.deltaTime));
    }

    void Jump()
    {
        if (Input.GetKey(JumpKey))
        {   
            if (myController.isGrounded)
            {
                hangTimer = hangTime;
                ySpeed = jumpForce;
            }
            else
            {
                if (hangTimer > 0)
                {
                    hangTimer -= Time.deltaTime;
                    ySpeed += gravityModifier * hangTimer * Time.deltaTime;
                }
            }
        }

        if (spring)
        {
            if (myController.isGrounded)
            {
                hangTimer = hangTime;
                ySpeed = jumpForce;
            }
            else
            {
                if (hangTimer > 0)
                {
                    hangTimer -= Time.deltaTime;
                    ySpeed += gravityModifier * hangTimer * Time.deltaTime;
                }
                else
                {
                    spring = false;
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        anim = this.gameObject.GetComponent<Animator>();
        heroStats = gameObject.GetComponent<HeroStats>();
        axeSpawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        myGravity();
        Jump();
        ForwardMovement();
        SpeedApply();
        MoveAnimUpdate();
       
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<SpringJump>() != null)
        {
            spring = true;
            hit.gameObject.GetComponent<Animator>().enabled = true;
        }
        if (hit.gameObject.name == "Axe(Clone)" || hit.gameObject.name == "Axe2") {
            Destroy(hit.gameObject);
            axeSpawner.SetActive(true);
        }
        if (hit.gameObject.GetComponent<boulderMovement>() != null)
        {
            hill = true;
        }
    }

    //public void OnControllerColliderHit(ControllerColliderHit collision)
    //{

    //    if (collision.gameObject.GetComponent<isItem>() != null)
    //    {
    //        string item = collision.gameObject.GetComponent<isItem>().item;
    //        Debug.Log(item);
    //        if (item.Equals("apple"))
    //        {
    //            Debug.Log("Apple - 50 points");
    //            Destroy(collision.gameObject);
    //        }
    //        else if (item.Equals("rock"))
    //        {
    //            heroStats.ChangeHealth(-20);
    //            Debug.Log("player health down 25pts");
    //        }
    //    }
    //}

    //animations
    public void MoveAnimUpdate()
    {
        if (anim != null)
        {
            if (myController.isGrounded)
            {
                anim.SetBool("jump", false);
            }
            //getting current animation state
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetInteger("prev_state", 0);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("SlowRun"))
            {
                anim.SetInteger("prev_state", 2);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("FastRun"))
            {
                anim.SetInteger("prev_state", 2);
            }

            //presses right
            if (Input.GetKey(RightKey) == true)
            {
                // if character is facing left
                if (anim.GetBool("right") == false)
                {
                    //anim.Play("SlowRun");
                    turnAround();
                    anim.SetBool("right", true);
                }
                if (Input.GetKeyDown(JumpKey) == true)
                {
                    anim.SetBool("jump", true);
                    //anim.Play("JumpFreeze");

                }
                if (anim.GetBool("jump")) { 
                    anim.SetBool("move", false);
                }
                else
                {
                    anim.SetBool("move", true);
                }

            }
            // presses left
            else if (Input.GetKey(LeftKey) == true)
            {
                
                // facing right
                if (anim.GetBool("right") == true)
                {
                    //anim.Play("SlowRun");
                    turnAround();
                    anim.SetBool("right", false);
                }
                if (Input.GetKeyDown(JumpKey) == true)
                {
                    anim.SetBool("jump", true);
                    //anim.Play("JumpFreeze");

                }
                if (anim.GetBool("jump"))
                {
                    anim.SetBool("jump", true);
                    anim.SetBool("move", false);
                }
                else
                {
                    anim.SetBool("move", true);
                }

            }

            // presses up(jump)
            else if (Input.GetKey(JumpKey) == true)
            {
                anim.SetBool("jump", true);
            }

            //presses nothing
            else
            {
                anim.SetBool("move", false);
            }
        }
    }
    
    void turnAround()
    {
        transform.rotation *= Quaternion.Euler(0, 180, 0);
    }
}
