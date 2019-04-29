using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WonderBoy_Packed0_Diffuse")
        {
            if (other.gameObject.GetComponent<MoveLogic>().isInvincible == true) {
                //if player is invincible do nothing
            }else
                HeroStats.instance.ChangeHealth(-(int)HeroStats.instance.currentHealth);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WonderBoy_Packed0_Diffuse")
        {
            if (collision.gameObject.GetComponent<MoveLogic>().isInvincible == true)
            {
                //if player is invincible do nothing
            }
            else
                HeroStats.instance.ChangeHealth(-(int)HeroStats.instance.currentHealth);
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
