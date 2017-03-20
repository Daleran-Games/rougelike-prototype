using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.RPGFramework;
using DaleranGames.UI;

namespace DaleranGames.RPGFramework
{
    public class Character : MonoBehaviour, INameable
    {
        [SerializeField]
        private string characterName;
        public string Name
        {
            get
            {
                return characterName;
            }
            set
            {
                characterName = value;
            }
        }

        //public ScaleFloatStat ActionTimer;

        public Action CharacterDeathEvent;

        public StatCollection CharacterStats = new StatCollection();

        private void Start()
        {

        }


    } 
}
