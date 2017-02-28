using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : MonoBehaviour {

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.Instance.GameMenu.StateEnabled += OnEnterMenuState;
        GameManager.Instance.GameMenu.StateDisabled += OnExitMenuState;

    }

    private void OnDestroy()
    {
        GameManager.Instance.GameMenu.StateEnabled -= OnEnterMenuState;
        GameManager.Instance.GameMenu.StateDisabled -= OnExitMenuState;
    }

    void OnEnterMenuState(GameState newState)
    {
        gameObject.SetActive(true);
    }

    void OnExitMenuState (GameState newState)
    {
        gameObject.SetActive(false);
    }

}
