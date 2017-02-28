using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DalLib;



public class UIManager : Singleton<UIManager> {

    protected UIManager () { }

    public Text levelText;
    public GameObject levelPanel;
    public GameObject helpPanel;

    SaveData save;

    void Awake()
    {
        save = GameManager.Instance.Save;
    }


    public void SetUpUI()
    {
        levelPanel = GameObject.Find("LevelPanel");
        levelText = GameObject.Find("LevelText").GetRequiredComponent<Text>();
        levelText.text = "System Loading: Zone " + save.SavedZone + Environment.NewLine + Environment.NewLine + "*  Initiating sensors: 0028:C0034B23" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Load success. Standby for initialization _";
        levelPanel.SetActive(true);
        helpPanel = GameObject.Find("HelpPanel");

    }

    public void HideLevelScreen()
    {
        levelPanel.SetActive(false);
    }

    public void SetTutorialScreen(bool state)
    {
        helpPanel.SetActive(state);
    }


    public void ShowGameOverScreen()
    {
        levelText.text = "A fatal exception has occurred at zone " + save.SavedZone + ". The current application will be terminated." + Environment.NewLine + Environment.NewLine + "*  System will attempt to reboot automatically." + Environment.NewLine + "*  Hardware fault located at 0031:D0014F09" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Reboot failed _";
        levelPanel.SetActive(true);
    }
}
