using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

namespace FPFInventory
{
    public class Inventory : MonoBehaviour
    {
        public bool duplicateEnabled = true;
        public List<FPFInventory.InventoryItem> items;
        public static UnityAction<FPFInventory.InventoryItem> OnAddItem;
        public static UnityAction<string> OnUseItem;

        void OnEnable()
        {
            ItemsDetector.OnCollectItem += AddItem;
        }


        void OnDisable()
        {
            ItemsDetector.OnCollectItem -= AddItem;
        }

        private void Start()
        {
            items = new List<InventoryItem>();
        }

        public void AddItem(FPFInventory.InventoryItem item)
        {
            if (!duplicateEnabled)
            {
                InventoryItem existingItem = items.Find(i => i.itemName ==  item.itemName);                
                if (existingItem != null)
                {
                    existingItem.itemsCounter += item.itemsCounter;
                    OnAddItem?.Invoke(item);
                } 
                else
                {
                    items.Add(item);
                    OnAddItem?.Invoke(item);
                }
            }
            else
            {
                items.Add(item);
                OnAddItem?.Invoke(item);
            }
        }
        public void UseItem(string name)
        {
            InventoryItem existingItem = items.Find(i => i.itemName == name);
            if (existingItem != null)
            {
                existingItem.itemsCounter--;
                if (existingItem.itemsCounter == 0)
                {
                    items.Remove(existingItem);
                }
                OnUseItem?.Invoke(name);
            }
        }
    }
}
