using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
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
