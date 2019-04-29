using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingDeath : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WonderBoy_Packed0_Diffuse")
        {
            other.gameObject.GetComponent<MoveLogic>().isInvincible = false;
            HeroStats.instance.ChangeHealth((int)-HeroStats.instance.currentHealth);
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
