using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealWeapon : MonoBehaviour
{
    public GameObject axe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "egg" || other.gameObject.name == "egg (1)" || other.gameObject.name == "egg (2)") {

            //Instantiate(axe, new Vector3(-7736,65,559), transform.rotation);
            other.gameObject.GetComponentInParent<Animator>().enabled = false;
            Instantiate(axe, other.gameObject.transform.position, transform.rotation);
            Destroy(other.gameObject);
            axe.GetComponent<Rigidbody>().useGravity = false;
            Debug.Log("egg should be destroyed");
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
