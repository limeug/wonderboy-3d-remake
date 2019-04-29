using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImgr : MonoBehaviour
{
    
   public static GameObject pausePanel;
    
    void Awake()
    {
        pausePanel = GameObject.Find("PauseMenuPanel");
    }

    // Start is called before the first frame update
    private void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
