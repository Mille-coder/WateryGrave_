using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Craftingbench : MonoBehaviour, IDropHandler
{
    [SerializeField] Button me;
    [SerializeField] AudioSource VoicelinesBench;
    [SerializeField] AudioClip VoicelineInspect;
    [SerializeField] AudioClip VoicelineHelmetFix;
    [SerializeField] AudioClip VoicelineSuitFix;
    [SerializeField] AudioClip VoicelineBootsFix;
    [SerializeField] AudioClip VoicelineHelmetPlaced;
    [SerializeField] AudioClip VoicelineSuitPlaced;
    [SerializeField] AudioClip VoicelineBootsPlaced;
    


    [SerializeField] private PickUpItemFromRack[] BenchItems;
    [SerializeField] Item Glass;
    [SerializeField] Button brokenHelmet;
    [SerializeField] Description descriptor;
    [SerializeField] string describe;
    [SerializeField] InventoryManager inventoryManager;
    private bool cloth1 = false;

    private bool itemOnDesk = false;

    private void Start() 
    {
        brokenHelmet.onClick.AddListener(TakeOutTheGlass);
        me.onClick.AddListener(FlavourText);
    }

    public void FlavourText()
    {
        descriptor.RecivedDescription("An old workbench. I could fix my equipment on it.");
        VoicelinesBench.Stop();
        VoicelinesBench.PlayOneShot(VoicelineInspect);
    }
    public void TakeOutTheGlass()
    {
        descriptor.RecivedDescription(describe);
        inventoryManager.AddItem(Glass);
        brokenHelmet.gameObject.SetActive(false);
        BenchItems[6].gameObject.SetActive(true);
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        GameObject dropped = eventData.pointerDrag;
        InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();

        if(BenchItems[0].gameObject.activeSelf == false && BenchItems[1].gameObject.activeSelf == false && BenchItems[2].gameObject.activeSelf == false && BenchItems[3].gameObject.activeSelf == false && BenchItems[4].gameObject.activeSelf == false && BenchItems[5].gameObject.activeSelf == false && BenchItems[6].gameObject.activeSelf == false)
        {
            itemOnDesk = false;
        }

        

       if (inventoryItem.item.type == ItemFunction.Suit && inventoryItem.item.piece != Suitpiece.Bottles) 
       {
        if (itemOnDesk == true)
        {
            descriptor.RecivedDescription("Im already working on something");
            return;
        }
        Destroy(dropped);
        itemOnDesk = true;
        
            if(inventoryItem.item.piece == Suitpiece.Helmet)
            {
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    BenchItems[0].gameObject.SetActive(true);
                    VoicelinesBench.Stop();
                    VoicelinesBench.PlayOneShot(VoicelineHelmetPlaced);
                    return;
                }
                BenchItems[1].gameObject.SetActive(true);
                return;
            }
            if(inventoryItem.item.piece == Suitpiece.Cloth)
            {
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    BenchItems[2].gameObject.SetActive(true);
                    VoicelinesBench.Stop();
                    VoicelinesBench.PlayOneShot(VoicelineSuitPlaced);
                    return;
                }
                BenchItems[3].gameObject.SetActive(true);
                return;
            }
            if(inventoryItem.item.piece == Suitpiece.Boots)
            {
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    BenchItems[4].gameObject.SetActive(true);
                    VoicelinesBench.Stop();
                    VoicelinesBench.PlayOneShot(VoicelineBootsPlaced);
                    return;
                }
                BenchItems[5].gameObject.SetActive(true);
                return;
            }
            
            
       }
       else
       {
            if (BenchItems[6].gameObject.activeSelf && inventoryItem.item.piece == Suitpiece.Helmet)
            {
                Destroy(dropped);
                BenchItems[6].gameObject.SetActive(false);
                BenchItems[1].gameObject.SetActive(true);
                descriptor.RecivedDescription("You replaced the glass in the helmet it fits perfectly");
                VoicelinesBench.Stop();
                VoicelinesBench.PlayOneShot(VoicelineHelmetFix);
                return;
            }
            if (BenchItems[2].gameObject.activeSelf && inventoryItem.item.piece == Suitpiece.Cloth)
            {
                if(cloth1 == true)
                    {
                        Destroy(dropped);
                        descriptor.RecivedDescription("You fix the hole in the diving suit");
                        BenchItems[2].gameObject.SetActive(false);
                        BenchItems[3].gameObject.SetActive(true);
                        VoicelinesBench.Stop();
                        VoicelinesBench.PlayOneShot(VoicelineSuitFix);
                        return;
                    }
                else
                {
                    Destroy(dropped);
                    cloth1 = true;
                    descriptor.RecivedDescription("Great! But you will need something more to repair this suit");
                    return;
                }
            }
            if (BenchItems[4].gameObject.activeSelf && inventoryItem.item.piece == Suitpiece.Boots)
            {
                Destroy(dropped);
                BenchItems[4].gameObject.SetActive(false);
                BenchItems[5].gameObject.SetActive(true);
                descriptor.RecivedDescription("You add additional weights to the boots");
                VoicelinesBench.Stop();
                VoicelinesBench.PlayOneShot(VoicelineBootsFix);
                return;
            }
        descriptor.RecivedDescription("This will not work");
       }
        
    }
}
