using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionBehaviour : MonoBehaviour {

    public event IntStatChangeHandler ConditionStatChange;

    [SerializeField]
    int condition = 8;
    public int Condition
    {
        get { return condition; }
        set
        {
            if (value > MaxCondition)
            {
                condition = MaxCondition;
                if (ConditionStatChange != null)
                    ConditionStatChange(MaxCondition, true);
            }
            else
            {
                condition = value;
                if (ConditionStatChange != null)
                {

                    bool up = (value > condition) ? true : false;
                    ConditionStatChange(value, up);
                }
            }

        }
    }

    [SerializeField]
    int maxCondition = 8;
    public int MaxCondition
    {
        get { return maxCondition; }
        set
        {
            if (value < 0)
                maxCondition = 0;
            else
                maxCondition = value;
        }
    }
}
