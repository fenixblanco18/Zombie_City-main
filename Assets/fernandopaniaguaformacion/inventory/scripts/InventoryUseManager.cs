using FPFInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUseManager : MonoBehaviour
{
    [Header("Posicion en la que se va crear el objeto asociado al ítem")]
    public Transform useItemPosition;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            if (GetComponent<Inventory>().items.Count > 0) {
                Instantiate(GetComponent<Inventory>().items[0].itemGO, useItemPosition.position, useItemPosition.rotation);
                GetComponent<Inventory>().UseItem(GetComponent<Inventory>().items[0].itemName);
            }
        }    
    }
}
