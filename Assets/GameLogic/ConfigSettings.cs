using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewConfigSettings", menuName = "Data/Config Settings", order = 99)]
public class ConfigSettings : ScriptableObject
{

    [SerializeField]
    private float turnDelay = 0.1f;
    public float TurnDelay
    {
        get
        {
            return turnDelay;
        }

        set
        {
            turnDelay = value;
        }
    }

    [SerializeField]
    private float levelStartDelay = 2f;
    public float LevelStartDelay
    {
        get
        {
            return levelStartDelay;
        }

        set
        {
            levelStartDelay = value;
        }
    }

    [SerializeField]
    private AudioClip gameOverSound;
    public AudioClip GameOverSound
    {
        get
        {
            return gameOverSound;
        }

        set
        {
            gameOverSound = value;
        }
    }


}
