using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private UnitController unitController;

    public UnitController selectedUnit;
    private Camera cam;
    private Animator animator;

    private void Awake()
    {
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                UnitController hitUnit = hit.collider.GetComponent<UnitController>();

                if (hitUnit != null)
                {
                    SetFocus(hitUnit);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Deselect();
        }
    }
    private void Deselect()
    {
        if (selectedUnit != null)
        {
            selectedUnit.DisableSelection();
            selectedUnit = null;
        }
    }

    void SetFocus(UnitController hitUnit)
    {
        if(selectedUnit != null)
        {
            Deselect();
        }
        selectedUnit = hitUnit;
        selectedUnit.EnableSelection();
    }

    public void Attack()
    {
        if (selectedUnit != null && unitController.Energy.CurrentValue > 0)
        {
            selectedUnit.TakeDamage(unitController.Damage);
            unitController.ConsumeEnergy();
            animator.SetTrigger("Spinkick");
        }
            
    }
}
