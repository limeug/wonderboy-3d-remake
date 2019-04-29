using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEnemy : MonoBehaviour
{
    public GameObject explosionParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("WonderBoy_Packed0_Diffuse")) {
            if (other.gameObject.GetComponent<MoveLogic>().isInvincible == true) {
                SoundMgr.instance.PlayEnemyDeath();
                Instantiate(explosionParticle, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }else { 
                other.gameObject.GetComponent<Animator>().SetTrigger("stumble");
                SoundMgr.instance.PlayStumbleSound();
                HeroStats.instance.ChangeHealth(-20);
                if (GameObject.Find("AxeSpawner") != null)
                {
                    GameObject.Find("AxeSpawner").SetActive(false);
                    Debug.Log(this.gameObject.name + " axe spawner off");
                }
            }
            Debug.Log(this.gameObject.name);
        }
        if (other.gameObject.name.Equals("Axe(Clone)") ) {
            Instantiate(explosionParticle, this.gameObject.transform.position, Quaternion.identity);
            SoundMgr.instance.PlayEnemyDeath();
            Destroy(this.gameObject);
            
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
