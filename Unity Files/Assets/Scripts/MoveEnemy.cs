using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float force;
    public GameObject target;
    
    //public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move()
    {
        if (gameObject.name == "ToxicFrog")
        {
            gameObject.GetComponent<Animator>().Play("Jump");
        }
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }

    public void StopMove() {
        if (gameObject.name == "ToxicFrog")
        {
            gameObject.GetComponent<Animator>().Play("Idle");
            
        }
        gameObject.GetComponent<Rigidbody>().Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
            GetComponent<Transform>().LookAt(target.GetComponent<Transform>());
        
    }
}
