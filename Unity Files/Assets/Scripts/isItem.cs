using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isItem : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("WonderBoy_Packed0_Diffuse"))
        {
            if (this.gameObject.name == "girl")
            {
                SoundMgr.instance.PlayItemPickUp();
                Destroy(this.gameObject);
                ScoreMgr.instance.SetScore(4800);
                Debug.Log("Bonus Item!");
            }
            else
            {
                SoundMgr.instance.PlayItemPickUp();
                Destroy(this.gameObject);
                ScoreMgr.instance.SetScore(50);
                HeroStats.instance.ChangeHealth(5);
                Debug.Log("Total Score: " + ScoreMgr.instance.GetScore().ToString());
            }
        }
    }
}
