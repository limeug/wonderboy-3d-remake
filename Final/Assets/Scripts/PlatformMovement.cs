using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{


    //Start position
    private Vector3 positionA;

    //Next Position
    private Vector3 positionB;

    //Will be either positionA or positionB depending on the last position of the platform
    private Vector3 nextPosition;

    //Movement speed
    public float speed;

    //Reference to platform
    public Transform childTransfrm;

    //Reference to position B
    public Transform transformB;


    // Start is called before the first frame update
    void Start()
    {
        positionA = childTransfrm.localPosition;
        positionB = transformB.localPosition;
        nextPosition = positionB;
    }

    // Update is called once per frame
    void Update()
    {
        platformMovement();
    }

    //This method is responsible for moving the platform from position A to position B
    private void platformMovement()
    {
        childTransfrm.localPosition = Vector3.MoveTowards(childTransfrm.localPosition, nextPosition, speed * Time.deltaTime);

        //If distance between current position of the platform and next position is <= 0.1 we are at our destination point
        //so we must change the position.
        if(Vector3.Distance(childTransfrm.localPosition, nextPosition) <= 0.1)
        {
            ChangePosition();
        }
    }

    //Checks position of platform and moves it accordingly
    private void ChangePosition()
    {
        //if next position is different from PositionA it will it will use position A, if its the same it will use position B.
        nextPosition = nextPosition != positionA ? positionA : positionB;
    }
}
