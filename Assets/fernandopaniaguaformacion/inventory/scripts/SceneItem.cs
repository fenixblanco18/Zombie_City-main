using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FPFInventory
{
    public class SceneItem : MonoBehaviour
    {
        [Header("Nombrel del ítem")]
        public string itemName;
        [Header("Número de unidades del ítem que se recogen")]
        public int itemsCounter;
        [Header("Imagen que se muestra en la UI")]
        public Sprite imageUI;
        [Header("Ítem del juego")]
        public GameObject itemGO;
        [Header("Objeto a spawnear cuando se recoge el ítem (opcional)")]
        public GameObject collectGO;
    }
}
