using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Item item;
    [HideInInspector] public Item _item;

   [HideInInspector] public Transform parentAfterDrag;

   public void InitialiseItem(Item newItem)
   {
        item = newItem;
        image.sprite = newItem.image;
        

   }
   public void OnBeginDrag(PointerEventData eventData)
   {
        
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
   }

   public void OnDrag(PointerEventData eventData)
   {
        
        transform.position = Input.mousePosition;
   }

   public void OnEndDrag(PointerEventData eventData)
   {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
   }


}
