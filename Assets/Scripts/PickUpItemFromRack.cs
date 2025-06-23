using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItemFromRack : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Description descriptor;
    [SerializeField] Button myself;
    [SerializeField] string describe;
    [SerializeField] InventoryManager inventoryManager;

    void Start()
    {
        myself.onClick.AddListener(PickMeUp);
    }

    public void PickMeUp()
    {
        descriptor.RecivedDescription(describe);
        inventoryManager.AddItem(item);
        gameObject.SetActive(false);
    }

    
}
