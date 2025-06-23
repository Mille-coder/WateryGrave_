using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    
    [SerializeField] GameObject InventoryItemPrefab;
    [SerializeField] Rack rackClothingState;
    [SerializeField] Button door;
    [SerializeField] AudioSource PickupSound;
    [SerializeField] AudioSource Voicelines;

    [SerializeField] PopUpInventory popUpInventory;
    [SerializeField] GameObject InvTutorialPrompt;

    private void Start() 
    {
        door.onClick.AddListener(CheckClothing);
        Debug.Log("run check");
    }
    public void AddItem(Item item)
    {
        if(popUpInventory.wasIShown == false)
            {
                InvTutorialPrompt.SetActive(true);
            }
        PickupSound.Play();
        Voicelines.Stop();
        Voicelines.PlayOneShot(item.pickupVoicline, 1);
        
        
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            

            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }
    
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(InventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    void CheckClothing()
    {
        if (rackClothingState.howAreYouDressed == 1)
            {
                PutOnTheSuit(rackClothingState.howAreYouDressed);
            }
        else
        {
            PutOnTheSuitWrong(rackClothingState.howAreYouDressed);
        }
    }

    void PutOnTheSuit(int suit)
    {
        
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(3);
    }

    void PutOnTheSuitWrong(int suit)
    {
        StaticData.valueToKeep = suit;
        SceneManager.LoadSceneAsync(2);
    }

}
