using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Description descriptor;
    [SerializeField] Button myself;
    [SerializeField] string describe;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameObject InvTutorialPrompt;

    void Start()
    {
        myself.onClick.AddListener(PickMeUp);
    }

    public void PickMeUp()
    {
        
        descriptor.RecivedDescription(describe);
        inventoryManager.AddItem(item);
        Destroy(gameObject);
    }

    
}
