using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewConfigSettings", menuName = "Data/Config Settings", order = 99)]
    public class ConfigSettings : ScriptableObject
    {

        [SerializeField]
        private float turnDelay = 0.1f;
        public float TurnDelay
        {
            get { return turnDelay; }
            set { turnDelay = value; }
        }

        [SerializeField]
        private float levelStartDelay = 3f;
        public float LevelStartDelay
        {
            get { return levelStartDelay; }
            set { levelStartDelay = value; }
        }

        [SerializeField]
        private AudioClip gameOverSound;
        public AudioClip GameOverSound
        {
            get { return gameOverSound; }
            set { gameOverSound = value; }
        }

        [SerializeField]
        private float inititalFixedDeltaTime;
        public float InititalFixedDeltaTime
        {
            get { return inititalFixedDeltaTime; }
            set { inititalFixedDeltaTime = value; }
        }

        [SerializeField]
        private float flashTime = 0.2f;
        public float FlashTime
        {
            get { return flashTime; }
            set { flashTime = value; }
        }

        [SerializeField]
        private Color32 positiveColor = Color.green;
        public Color32 PositiveColor
        {
            get
            {
                return positiveColor;
            }

            set
            {
                positiveColor = value;
            }
        }

        [SerializeField]
        private Color32 negativeColor = Color.red;
        public Color32 NegativeColor
        {
            get
            {
                return negativeColor;
            }

            set
            {
                negativeColor = value;
            }
        }

        [SerializeField]
        Sprite defaultIcon;
        public Sprite DefaultIcon
        {
            get
            {
                return defaultIcon;
            }

            set
            {
                defaultIcon = value;
            }
        }

        private void Awake()
        {
            inititalFixedDeltaTime = Time.fixedDeltaTime;
        }


    } 
}
