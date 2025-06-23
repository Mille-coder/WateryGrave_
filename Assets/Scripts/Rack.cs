using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rack : MonoBehaviour, IDropHandler
{
    [SerializeField] private PickUpItemFromRack[] rackItems;
    [SerializeField] Item item;
    [SerializeField] Description descriptor;
    [SerializeField] string describe;
    [SerializeField] Button dressUp;
    [SerializeField] AudioSource AudioPutOn;

    [SerializeField] RackPopup rackPopup;
    [SerializeField] GameObject RackTutorialPrompt;

    public int howAreYouDressed= 0;

    private void Start() 
    {
      
    dressUp.onClick.AddListener(PutOnSuit);

    }

    public void PutOnSuit()
    {
        if(rackItems[1].gameObject.activeSelf && rackItems[3].gameObject.activeSelf && rackItems[5].gameObject.activeSelf && rackItems[7].gameObject.activeSelf)
            {
                howAreYouDressed = 1;
                for (int i = 0; i< rackItems.Length; i++)
                {
                    rackItems[i].gameObject.SetActive(false);
                }
                dressUp.interactable = false;
                return;
            }
        if(rackItems[0].gameObject.activeSelf)
            {
                Debug.Log("Test");
                howAreYouDressed = 2;
                for (int i = 0; i< rackItems.Length; i++)
                {
                    rackItems[i].gameObject.SetActive(false);
                }
                dressUp.interactable = false;
                return;
            }
        if(rackItems[2].gameObject.activeSelf && rackItems[1].gameObject.activeSelf)
            {
                howAreYouDressed = 3;
                for (int i = 0; i< rackItems.Length; i++)
                {
                    rackItems[i].gameObject.SetActive(false);
                }
                dressUp.interactable = false;
                return;
            }
        if(rackItems[6].gameObject.activeSelf == false && rackItems[1].gameObject.activeSelf && rackItems[3].gameObject.activeSelf)
            {
                howAreYouDressed = 4;
                for (int i = 0; i< rackItems.Length; i++)
                {
                    rackItems[i].gameObject.SetActive(false);
                }
                dressUp.interactable = false;
                return;
            }
        if(rackItems[4].gameObject.activeSelf && rackItems[1].gameObject.activeSelf && rackItems[3].gameObject.activeSelf)
            {
                howAreYouDressed = 5;
                for (int i = 0; i< rackItems.Length; i++)
                {
                    rackItems[i].gameObject.SetActive(false);
                }
                dressUp.interactable = false;
                return;
            }
        if (rackItems[6].gameObject.activeSelf)
            {
                howAreYouDressed = 6;
                for (int i = 0; i< rackItems.Length; i++)
                {
                    rackItems[i].gameObject.SetActive(false);
                }
                dressUp.interactable = false;
                return;
            }
        for (int i = 0; i< rackItems.Length; i++)
                {
                    rackItems[i].gameObject.SetActive(false);
                }
                dressUp.interactable = false;
        
        howAreYouDressed = 0;
        
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        GameObject dropped = eventData.pointerDrag;
        InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
        

        

       if (inventoryItem.item.type == ItemFunction.Suit)
       {
            if(rackPopup.wasIShown == false)
            {
                RackTutorialPrompt.SetActive(true);
            }
        inventoryItem.parentAfterDrag = transform;
        AudioPutOn.Play();
        Destroy(dropped);
            if(inventoryItem.item.piece == Suitpiece.Helmet)
            {
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    rackItems[0].gameObject.SetActive(true);
                    return;
                }
                rackItems[1].gameObject.SetActive(true);
                return;
            }
            if(inventoryItem.item.piece == Suitpiece.Cloth)
            {
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    rackItems[2].gameObject.SetActive(true);
                    return;
                }
                rackItems[3].gameObject.SetActive(true);
                return;
            }
            if(inventoryItem.item.piece == Suitpiece.Boots)
            {
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    rackItems[4].gameObject.SetActive(true);
                    return;
                }
                rackItems[5].gameObject.SetActive(true);
                return;
            }
            if(inventoryItem.item.piece == Suitpiece.Bottles)
            {
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    rackItems[6].gameObject.SetActive(true);    
                    return;
                }
                rackItems[7].gameObject.SetActive(true);
                return;
                
            }
            
            
       }
       descriptor.RecivedDescription(describe);
       
        
    }
}

