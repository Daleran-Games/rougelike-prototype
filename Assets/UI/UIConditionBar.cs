using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConditionBar : MonoBehaviour {

    ConditionBehaviour playerCondition;
    Text conditionBarText;
    Slider conditionBarSlider;


    // Use this for initialization
    void Awake()
    {
        playerCondition = GameObject.FindGameObjectWithTag("Player").GetRequiredComponent<ConditionBehaviour>();
        conditionBarText = GetComponentInChildren<Text>();
        conditionBarSlider = gameObject.GetRequiredComponent<Slider>();


    }

    private void Start()
    {
        conditionBarSlider.value = playerCondition.Condition;
        conditionBarSlider.minValue = 0;
        conditionBarSlider.maxValue = playerCondition.MaxCondition;

        conditionBarText.text = playerCondition.Condition + "/" + playerCondition.Condition;
    }

    private void OnEnable()
    {
        playerCondition.ConditionStatChange += OnEnergyStatChange;
    }

    private void OnDisable()
    {
        playerCondition.ConditionStatChange -= OnEnergyStatChange;
    }

    // Update is called once per frame
    public void OnEnergyStatChange(int amount, bool increase)
    {
        conditionBarSlider.value = amount;
        conditionBarText.text = amount + "/" + playerCondition.MaxCondition;
    }
}
