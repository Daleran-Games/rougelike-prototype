using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void IntStatChangeHandler(int amount, bool increase);

public class EnergyBehaviour : MonoBehaviour {

    public event IntStatChangeHandler EnergyStatChange;

    [SerializeField]
    int energy = 0;
    public int Energy
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
                if (EnergyStatChange !=null )
                {
                    bool up = (value > energy) ? true : false;
                    EnergyStatChange(value, up);
                }
            }
                
        }
    }

    [SerializeField]
    int maxEnergy = 150;
    public int MaxEnergy
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
