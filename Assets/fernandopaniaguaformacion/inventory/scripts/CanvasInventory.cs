using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace FPFInventory
{
    public class CanvasInventory : MonoBehaviour
    {
        [Header("Panel del Inventario")]
        public GameObject panelInventory;
        [Header("Panel del Item")]
        public GameObject panelItemPrefab;
        [Header("Admite duplicados")]
        public bool duplicateEnabled = false;

        void OnEnable()
        {
            Inventory.OnAddItem += AddItem;
            Inventory.OnUseItem += UseItem;
        }

        void OnDisable()
        {
            ItemsDetector.OnCollectItem -= AddItem;
        }

        public void AddItem(FPFInventory.InventoryItem item)
        {
            if (duplicateEnabled)
            {
                this.AddNewItem(item);
            }
            else
            {
                Transform transformExistingItem = panelInventory.transform.Find(item.itemName);
                if (transformExistingItem)
                {
                    int numberOfItems = Int32.Parse(panelInventory.transform.Find(item.itemName).GetComponentInChildren<TextMeshProUGUI>().text);
                    numberOfItems+=item.itemsCounter;
                    transformExistingItem.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = numberOfItems.ToString();
                }
                else
                {
                    this.AddNewItem(item);
                }
            }
        }

        public void UseItem(string name)
        {
            Transform transformExistingItem = panelInventory.transform.Find(name);
            if (transformExistingItem)
            {
                int numberOfItems = Int32.Parse(panelInventory.transform.Find(name).GetComponentInChildren<TextMeshProUGUI>().text);
                numberOfItems--;
                transformExistingItem.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = numberOfItems.ToString();
                if (numberOfItems == 0)
                {
                    Destroy(transformExistingItem.gameObject);
                }
            } 
            else
            {
                Debug.LogError("Hay un error en la gestión del inventario");
            }
            
        }

        private void AddNewItem(FPFInventory.InventoryItem item)
        {
            GameObject itemPanel = Instantiate(panelItemPrefab, panelInventory.transform);
            itemPanel.name = item.itemName;
            itemPanel.GetComponentInChildren<TextMeshProUGUI>().text = item.itemsCounter.ToString();
            itemPanel.GetComponentsInChildren<Image>()[1].sprite = item.imageUI;
        }
    }
}