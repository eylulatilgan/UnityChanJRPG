using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthFirstLayer;
    [SerializeField]
    private Slider healthSecondLayer;
    [SerializeField]
    private Slider shieldFirstLayer;
    [SerializeField]
    private Slider shieldSecondLayer;
    [SerializeField]
    private Slider[] energyLayers;
    
    [SerializeField]
    private UnitController unitController;

    public float animationSpeed = 1f;
    private Slider energySlider;
    public int energySliderIndex;
    public float currentEnergy;

   
    private void Start()
    {        
        InitializeSliders(healthFirstLayer, unitController.Health.DefaultValue, unitController.Health.CurrentValue);
        InitializeSliders(healthSecondLayer, unitController.Health.DefaultValue, unitController.Health.CurrentValue);
        InitializeSliders(shieldFirstLayer, unitController.Shield.DefaultValue, unitController.Shield.CurrentValue);
        InitializeSliders(shieldSecondLayer, unitController.Shield.DefaultValue, unitController.Shield.CurrentValue);

        foreach (Slider slider in energyLayers)
        {
            InitializeSliders(slider, unitController.Energy.DefaultValue, unitController.Energy.CurrentValue);
        }
        energySlider = energyLayers[0];
        energySliderIndex = 1;
    }

    void InitializeSliders(Slider slider, float defaultValue, float currentValue)
    {
        slider.minValue = 0;
        slider.maxValue = defaultValue;
        slider.value = currentValue;
    }

    void Update()
    {
        ManageHealthShieldBar();

        float energyDiff = currentEnergy - energySlider.value;

        if (energySlider.value <= 0 && energySliderIndex < unitController.EnergyLevel)
        {
            energySlider = energyLayers[energySliderIndex];
            if (energyDiff > 0)
            {
                unitController.Energy.CurrentValue = unitController.Energy.DefaultValue;
                unitController.Energy.CurrentValue -= energyDiff;
                energySlider.value -= energyDiff;
            }        
                
            energySliderIndex++;
            
            
        }

        currentEnergy = energySlider.value;
    }

    private void ManageHealthShieldBar()
    {
        if (shieldSecondLayer.value > shieldFirstLayer.value)
        {
            shieldSecondLayer.value -= animationSpeed;
        }

        if (shieldSecondLayer.value <= 0)
        {
            shieldSecondLayer.gameObject.SetActive(false);

            if (healthSecondLayer.value > healthFirstLayer.value)
                healthSecondLayer.value -= animationSpeed;
        }
    }

    public void UpdateStatUI()
    {
        shieldFirstLayer.value = unitController.Shield.CurrentValue;
        healthFirstLayer.value = unitController.Health.CurrentValue;
        energySlider.value = unitController.Energy.CurrentValue;
    }

}
