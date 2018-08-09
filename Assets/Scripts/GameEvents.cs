using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

    public delegate void DeathEvent();
    public static event DeathEvent OnHealthDepleted;
    public delegate void EnergyEvent();
    public static event EnergyEvent OnEnergyDepleted;

    public static void TriggerDeath()
    {
        if (OnHealthDepleted != null)
        {
            OnHealthDepleted();
        }
    }

    public static void TriggerEnergyDepleted()
    {
        if (OnEnergyDepleted != null)
        {
            OnEnergyDepleted();
        }
    }
}
