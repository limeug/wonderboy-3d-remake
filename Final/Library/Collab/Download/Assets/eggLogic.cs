using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WonderBoy_Packed0_Diffuse") {
            
            this.gameObject.GetComponentInParent<Animator>().enabled = true;
            

        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
