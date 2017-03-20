using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.RPGFramework
{
    [CreateAssetMenu(fileName = "NewStatType", menuName = "Data/Stat Type", order = 101)]
    public class StatType : ScriptableObject
    {
        [SerializeField]
        private string statName = "DefualtStat";

        [SerializeField]
        [TextArea]
        private string description = "Default Stat Description";

        [SerializeField]
        private string units = "m";

        [SerializeField]
        private Sprite icon;

        [SerializeField]
        private Color32 statColor = Color.white;

        public string StatName
        {
            get
            {
                return statName;
            }

            protected set
            {
                statName = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            protected set
            {
                description = value;
            }
        }

        public Sprite Icon
        {
            get
            {
                return icon;
            }

            protected set
            {
                icon = value;
            }
        }

        public Color32 StatColor
        {
            get
            {
                return statColor;
            }

            protected set
            {
                statColor = value;
            }
        }

        public string Units
        {
            get
            {
                return units;
            }

            protected set
            {
                units = value;
            }
        }

    }
}
