using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{

    [SerializeField]
    GameObject gameManager;

    [SerializeField]
    GameObject soundManager;

	// Use this for initialization
	void Awake ()
    {
        if (GameManager.Instance == null)
            Instantiate(gameManager);

        if (SoundManager.Instance == null)
            Instantiate(soundManager);
	}

}
