using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HayMachineSwitcher : MonoBehaviour, IPointerClickHandler
{
    // Vars
    public GameObject blueHayMachine;
    public GameObject redHayMachine;
    public GameObject yellowHayMachine;
    private int selectedIndex;
    private int numHayMachines = Enum.GetValues(typeof(HayMachineColor)).Length;

    // Switch Hay Machine Color
    public void OnPointerClick(PointerEventData eventData) 
    {
        // Update selection index
        selectedIndex++; 
        selectedIndex %= numHayMachines; 
        
        // Get and set hay machine color from enum
        GameSettings.hayMachineColor = (HayMachineColor)selectedIndex; 

        // Activate prefabs depending on the hay machine color
        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                blueHayMachine.SetActive(true);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(false);
                break;

            case HayMachineColor.Yellow:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(true);
                redHayMachine.SetActive(false);
                break;

            case HayMachineColor.Red:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(true);
                break;
        }
    }
}
