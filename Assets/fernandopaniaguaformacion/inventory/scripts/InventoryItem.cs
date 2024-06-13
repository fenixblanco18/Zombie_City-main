using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPFInventory
{
    [Serializable]
    public class InventoryItem
    {
        public string itemName;
        public int itemsCounter;
        public Sprite imageUI;
        public GameObject itemGO;
        
        public InventoryItem(string itemName, int itemsCounter, Sprite imageUI, GameObject itemGO)
        {
            this.itemName = itemName;
            this.itemsCounter = itemsCounter;
            this.imageUI = imageUI;
            this.itemGO = itemGO;
        }
    }
}
