using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderMovement : MonoBehaviour
{
    public bool hill = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WonderBoy_Packed0_Diffuse")
        {
            hill = true;
            // GameObject.Find("Boulder").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Boulder").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("Boulder (1)").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("Boulder (2)").GetComponent<Rigidbody>().isKinematic = false;
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
