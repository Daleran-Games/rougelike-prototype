using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour {

    public Text levelText;
    SaveData save;

    private void Awake()
    {
        levelText = GetComponentInChildren<Text>();
        save = GameManager.Instance.Save;
        gameObject.SetActive(true);

        if (levelText == null)
            Debug.LogError("DG ERROR: No text component on level panel");
    }

    private void OnEnable()
    {
        GameManager.Instance.LoadScene.StateEnabled += OnBeginLevelLoading;
        GameManager.Instance.LoadScene.StateDisabled += OnFinishLevelLoading;
        GameManager.Instance.GameOver.StateEnabled += OnGameOver;
        GameManager.Instance.GameOver.StateDisabled += OnFinishLevelLoading;
    }

    private void OnDestroy()
    {
        GameManager.Instance.LoadScene.StateEnabled -= OnBeginLevelLoading;
        GameManager.Instance.LoadScene.StateDisabled -= OnFinishLevelLoading;
        GameManager.Instance.GameOver.StateEnabled -= OnGameOver;
        GameManager.Instance.GameOver.StateDisabled -= OnFinishLevelLoading;

    }

    public void OnBeginLevelLoading (GameState newState)
    {
        levelText.text = "System Loading: Zone " + save.SavedZone + Environment.NewLine + Environment.NewLine + "*  Initiating sensors: 0028:C0034B23" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Load success. Standby for initialization _";
        gameObject.SetActive(true);
    }

    public void OnFinishLevelLoading (GameState newState)
    {
        gameObject.SetActive(false);
    }

    public void OnGameOver (GameState newState)
    {
        levelText.text = "A fatal exception has occurred at zone " + save.SavedZone + ". The current application will be terminated." + Environment.NewLine + Environment.NewLine + "*  Unable to load kernal." + Environment.NewLine + "*  Hardware fault located at 0031:D0014F09" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Press ESC to continue or F1 to terminate _";
        gameObject.SetActive(true);
    }



}
