using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
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

        [SerializeField]
        Color32 defaultHitColor = Color.red;
        public Color32 DefaultHitColor
        {
            get
            {
                return defaultHitColor;
            }

            set
            {
                defaultHitColor = value;
            }
        }

        [SerializeField]
        Color32 defaultChargeColor = Color.blue;
        public Color32 DefaultChargeColor
        {
            get
            {
                return defaultChargeColor;
            }

            set
            {
                defaultChargeColor = value;
            }
        }

        [SerializeField]
        AudioClip[] defaultChargeSounds;
        public AudioClip[] DefaultChargeSounds
        {
            get
            {
                return defaultChargeSounds;
            }

            set
            {
                defaultChargeSounds = value;
            }
        }



        private void Awake()
        {
            inititalFixedDeltaTime = Time.fixedDeltaTime;
        }


    } 
}
