using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnergyBar : MonoBehaviour {

    EnergyBehaviour playerEnergy;
    Text energyBarText;
    Slider energyBarSlider;


	// Use this for initialization
	void Awake ()
    {
        playerEnergy = GameObject.FindGameObjectWithTag("Player").GetRequiredComponent<EnergyBehaviour>();
        energyBarText = GetComponentInChildren<Text>();
        energyBarSlider = gameObject.GetRequiredComponent<Slider>();

	}

    private void Start()
    {
        energyBarSlider.value = playerEnergy.Energy;
        energyBarSlider.minValue = 0;
        energyBarSlider.maxValue = playerEnergy.MaxEnergy;

        energyBarText.text = playerEnergy.Energy + "/" + playerEnergy.MaxEnergy;
    }

    private void OnEnable()
    {
        playerEnergy.EnergyStatChange += OnEnergyStatChange;
    }

    private void OnDisable()
    {
        playerEnergy.EnergyStatChange -= OnEnergyStatChange;
    }

    // Update is called once per frame
    public void OnEnergyStatChange (float amount, bool increase)
    {
        energyBarSlider.value = amount;
        energyBarText.text = amount + "/" + playerEnergy.MaxEnergy;
    }
}
