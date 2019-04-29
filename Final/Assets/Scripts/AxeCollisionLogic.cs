using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCollisionLogic : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
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
