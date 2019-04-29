using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJump : MonoBehaviour
{
    private CharacterController myCharacterController;
    private float ySpeed;

    
   
    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.name == "WonderBoy_Packed0_Diffuse")
        //other.gameObject.GetComponent<CharacterController>().velocity.y = 500f;
        //ySpeed = 500;
       

    }
    
    // Start is called before the first frame update
    void Start()
    {
        //myCharacterController = GameObject.Find("WonderBoy_Packed0_Diffuse").GetComponent<CharacterController>();
        //ySpeed = myCharacterController.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
