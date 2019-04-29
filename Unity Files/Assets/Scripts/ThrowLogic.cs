using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLogic : MonoBehaviour
{
    public GameObject axe;
    public KeyCode fireKey;
    public float rateOfFire;
    private float fireDelay;
    public float speed;
    // can set spam break to 0 if needed
    private int spamBreak = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(fireKey) && Time.time > fireDelay)
        {
            Debug.Log(Input.inputString);
            //if (spamBreak != 2)
            //{
            SoundMgr.instance.PlayThrow();
                fireDelay = Time.time + rateOfFire;
                GameObject clone = Instantiate(axe, transform.position, transform.rotation);
                clone.GetComponent<ConstantForce>().enabled = true;
                clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                spamBreak += 1;
            //}
            //else
            //{
            //    fireDelay = Time.time + (float) 0.5;
            //    spamBreak = 0;
            //}
            Debug.Log(spamBreak);

        }
    }
}
