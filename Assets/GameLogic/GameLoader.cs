using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.Effects;

namespace DaleranGames
{
    public class GameLoader : MonoBehaviour
    {

        [SerializeField]
        GameObject gameManager;

        [SerializeField]
        GameObject soundManager;

        [SerializeField]
        GameObject inputManager;

        // Use this for initialization
        void Awake()
        {
            if (GameManager.Instance == null)
                Instantiate(gameManager);

            if (SoundManager.Instance == null)
                Instantiate(soundManager);

            if (GameInput.Instance == null)
                Instantiate(inputManager);
        }

    } 
}
