using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public delegate void IntStatChangeHandler(int amount, bool increase);
    public delegate void FloatStatChangeHandler(float amount, bool increase);

    public class EnergyBehaviour : MonoBehaviour
    {

        public event FloatStatChangeHandler EnergyStatChange;

        [SerializeField]
        float energy = 0;
        public float Energy
        {
            get { return energy; }
            set
            {

                if (value > MaxEnergy)
                {
                    energy = MaxEnergy;
                    if (EnergyStatChange != null)
                        EnergyStatChange(MaxEnergy, true);
                }
                else
                {
                    energy = value;
                    if (EnergyStatChange != null)
                    {
                        bool up = (value > energy) ? true : false;
                        EnergyStatChange(value, up);
                    }
                }

            }
        }

        [SerializeField]
        float maxEnergy = 150;
        public float MaxEnergy
        {
            get { return maxEnergy; }
            set
            {
                if (value < 0)
                    maxEnergy = 0;
                else
                    maxEnergy = value;
            }
        }


    }

}