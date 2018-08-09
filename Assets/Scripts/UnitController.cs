using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{

    [SerializeField]
    private string ID;
    [SerializeField]
    private Health health;
    [SerializeField]
    private Shield shield;
    [SerializeField]
    private Energy energy;

    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float energyConsumption;
    [SerializeField]
    private float energyLevel;
    [SerializeField]
    private Material deselectMaterial;
    [SerializeField]
    private Material selectMaterial;

    private Animator animator;
    private bool isSelected = false;

    private void Awake()
    {
        health.CurrentValue = health.DefaultValue;
        shield.CurrentValue = shield.DefaultValue;
        energy.CurrentValue = energy.DefaultValue;
        animator = GetComponent<Animator>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        GameEvents.OnEnergyDepleted += OnEnergyDepleted;
    }

    private void OnDisable()
    {
        GameEvents.OnEnergyDepleted -= OnEnergyDepleted;
    }

    private void OnEnergyDepleted()
    {
        energy.CurrentValue = energy.DefaultValue;
    }

    public void TakeDamage(float damage)
    {
        if (shield.CurrentValue - damage < 0)
        {
            health.DecreaseValue(Math.Abs(shield.CurrentValue - damage));
        }

        shield.DecreaseValue(damage);
        uiManager.UpdateStatUI();
        animator.SetTrigger("GetDamage");
    }

    public void ConsumeEnergy()
    {
        energy.DecreaseValue(energyConsumption);
        uiManager.UpdateStatUI();
    }

    public void EnableSelection()
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material = selectMaterial;
        isSelected = true;
    }

    public void DisableSelection()
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material = deselectMaterial;
        isSelected = false;
    }

    #region GettersSetters
    public Health Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public Shield Shield
    {
        get
        {
            return shield;
        }

        set
        {
            shield = value;
        }
    }

    public Energy Energy
    {
        get
        {

            return energy;
        }

        set
        {
            energy = value;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public bool IsSelected
    {
        get
        {
            return isSelected;
        }

        set
        {
            isSelected = value;
        }
    }

    public string Id
    {
        get
        {
            return ID;
        }

        set
        {
            ID = value;
        }
    }

    public float EnergyLevel
    {
        get
        {
            return energyLevel;
        }

        set
        {
            energyLevel = value;
        }
    }
    #endregion
}
