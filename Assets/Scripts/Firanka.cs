using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Firanka : MonoBehaviour, IDropHandler
{

    [SerializeField] Button me;
    [SerializeField] AudioSource Voicelines;
    [SerializeField] AudioClip VoicelineInspect;
    [SerializeField] AudioClip VoicelineCut;
    [SerializeField] Item Cloth;
    [SerializeField] Description descriptor;
    [SerializeField] string describe;
    [SerializeField] InventoryManager inventoryManager;

    // Start is called before the first frame update
    private void Start() 
    {
        me.onClick.AddListener(FlavourText);
    }

    public void FlavourText()
    {
        descriptor.RecivedDescription("The rod it’s hanging on is all rusted over. Will need something to cut it’");
        Voicelines.Stop();
        Voicelines.PlayOneShot(VoicelineInspect);
    }
  public void OnDrop(PointerEventData eventData)
    {
        
        GameObject dropped = eventData.pointerDrag;
        InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();

         if (inventoryItem.item.type == ItemFunction.Tool)
       {
        
            if(inventoryItem.item.piece == Suitpiece.Bottles)
            {
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    Destroy(dropped);
                    descriptor.RecivedDescription(describe);
                    inventoryManager.AddItem(Cloth);
                    Voicelines.Stop();
                    Voicelines.PlayOneShot(VoicelineCut);
                    Destroy(gameObject);
                    return;
                }
                return;
            }
       }
        
    }
}
