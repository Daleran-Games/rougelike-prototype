using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Text levelText;
    public GameObject levelImage;
    public GameObject tutorialImage;



    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetUpUI()
    {
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetRequiredComponent<Text>();
        levelText.text = "System Loading: Zone " + GameManager.instance.Zone + Environment.NewLine + Environment.NewLine + "*  Initiating sensors: 0028:C0034B23" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Load success. Standby for initialization _";
        levelImage.SetActive(true);
        tutorialImage = GameObject.Find("TutorialImage");

    }

    public void HideLevelScreen()
    {
        levelImage.SetActive(false);
    }

    public void SetTutorialScreen(bool state)
    {
        tutorialImage.SetActive(state);
    }


    public void ShowGameOverScreen()
    {
        levelText.text = "A fatal exception has occurred at zone " + GameManager.instance.Zone + ". The current application will be terminated." + Environment.NewLine + Environment.NewLine + "*  System will attempt to reboot automatically." + Environment.NewLine + "*  Hardware fault located at 0031:D0014F09" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Reboot failed _";
        levelImage.SetActive(true);
    }
}
