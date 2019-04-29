using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//
//  this script determines which way to turn, so we can face the 'target'
//  then we respond (send a message, fire the weapon etc etc)
//
public class AimingLogic : MonoBehaviour
{
    public GameObject targetObj;
    public Vector3 vToTarget;
    public float dp;
    public float fireAngle;

    public float rotSpeed;      // how fast we should turn
    public float facingThresh;  // to decide if we are facing 'enough' to fire!

    private MoveEnemy move;
    

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponentInChildren<MoveEnemy>();
       
    }

    private void AimLogicUpdate()
    {
        // 1) compute vToTarget
        if (targetObj)
        {
            vToTarget = targetObj.transform.position - this.transform.position;
            vToTarget.Normalize();
        }

        // 2) vFacing, is our transform.forward
        // done

        // 3) compute dp of vRight and vToTarget
        dp = Vector3.Dot(this.transform.right, vToTarget);

        // 4) turn to face the target (careful if enemy is not facing upwards...)
        this.transform.Rotate(Vector3.up, dp * rotSpeed * Time.deltaTime);

        // 5) fire if we are 'facing' the target
        //    which means, fire if the dp of (forward, vToTarget) is > fireThresh)
        fireAngle = Vector3.Dot(this.transform.forward, vToTarget);
        if (fireAngle > facingThresh)
        {

            //// check for distance between hero and enemy, start enemy movement when hero and enemy are in camera's view
            if (Vector3.Distance(targetObj.transform.position, this.transform.position) < 200)
                move.Move();
            else if (Vector3.Distance(targetObj.transform.position, this.transform.position) > 200)
                move.StopMove();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        AimLogicUpdate();
    }
}
