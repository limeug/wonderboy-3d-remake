using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{
    public bool endHill = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WonderBoy_Packed0_Diffuse")
        {
            GameObject.Find("BoulderTrigger").GetComponent<boulderMovement>().hill = false;
            endHill = true;
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
