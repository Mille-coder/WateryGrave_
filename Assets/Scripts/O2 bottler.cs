using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class O2bottler : MonoBehaviour, IDropHandler
{
    [SerializeField] private PickUpItemFromRack[] O2Items;

    [SerializeField] AudioSource Voicelines;
    [SerializeField] AudioClip VoicelineBottle;
    [SerializeField] Item item;
    [SerializeField] Description descriptor;
    [SerializeField] GameObject Puzzle;
    [SerializeField] Button turnOn;
    [SerializeField] Button Pannel;
    [SerializeField] Button closebutton;
    [SerializeField] Button Pipe1;
    [SerializeField] Button Pipe2;
    [SerializeField] Button Pipe3;
    [SerializeField] Button Pipe4;
    [SerializeField] Button Pipe5;
    [SerializeField] Button Pipe6;
    [SerializeField] Button Pipe7;
    [SerializeField] Button Pipe8;
    [SerializeField] Button Pipe9;
    [SerializeField] Button Pipe10;
    [SerializeField] Button Wheel;

    bool loaded = false;
    bool repaired = false;

    void Start()
    {
        turnOn.onClick.AddListener(TurnedOn);
        Pannel.onClick.AddListener(OpenPuzzle);
        closebutton.onClick.AddListener(ClosePuzzle);

        Pipe1.onClick.AddListener(RotatePipe1);
        Pipe2.onClick.AddListener(RotatePipe2);
        Pipe3.onClick.AddListener(RotatePipe3);
        Pipe4.onClick.AddListener(RotatePipe4);
        Pipe5.onClick.AddListener(RotatePipe5);
        Pipe6.onClick.AddListener(RotatePipe6);
        Pipe7.onClick.AddListener(RotatePipe7);
        Pipe8.onClick.AddListener(RotatePipe8);
        Pipe9.onClick.AddListener(RotatePipe9);
        Pipe10.onClick.AddListener(RotatePipe10);
        Wheel.onClick.AddListener(CheckPuzzle);

    }

    void TurnedOn()
        {
            if (loaded == false)
                {
                    descriptor.RecivedDescription("ERROR no bottles detected");
                    return;
                }
            else
                {
                    if(repaired == false)
                    {
                    descriptor.RecivedDescription("ERROR internal damage detected");
                    return;
                    }
                    descriptor.RecivedDescription("Machine hums");
                    O2Items[0].gameObject.SetActive(false);
                    O2Items[1].gameObject.SetActive(true);
                    loaded = false;
                }
        }
    
    void OpenPuzzle()
    {
        Puzzle.gameObject.SetActive(true);
    }

    void ClosePuzzle()
    {
        Puzzle.gameObject.SetActive(false);
    }

    void CheckPuzzle()
    {
        if(Pipe1.transform.eulerAngles.z == 0 && Pipe3.transform.eulerAngles.z == 0 && Pipe5.transform.eulerAngles.z == 0 && Pipe7.transform.eulerAngles.z == 0 && Pipe8.transform.eulerAngles.z == 0 && Pipe9.transform.eulerAngles.z == 0 && Pipe10.transform.eulerAngles.z == 0)
            {
                if(Pipe2.transform.eulerAngles.z == 0 || Pipe2.transform.eulerAngles.z == 180 && Pipe4.transform.eulerAngles.z == 0 || Pipe4.transform.eulerAngles.z == 180 && Pipe6.transform.eulerAngles.z == 0 || Pipe6.transform.eulerAngles.z == 180)
                {
                    repaired = true;
                    Pannel.interactable = false;
                    Puzzle.gameObject.SetActive(false);
                }
            }
    }

    void RotatePipe1()
    {
        
        Pipe1.transform.Rotate(0, 0, 90);

    }

    void RotatePipe2()
    {
        
        Pipe2.transform.Rotate(0, 0, 90);
        
    }                                       

    void RotatePipe3()
    {
        
        Pipe3.transform.Rotate(0, 0, 90);
        
    }

    void RotatePipe4()
    {
        
        Pipe4.transform.Rotate(0, 0, 90);
        
    }

    void RotatePipe5()
    {
        
        Pipe5.transform.Rotate(0, 0, 90);
        
    }

    void RotatePipe6()
    {
        
        Pipe6.transform.Rotate(0, 0, 90);
        
    }

    void RotatePipe7()
    {
        
        Pipe7.transform.Rotate(0, 0, 90);
        
    }

    void RotatePipe8()
    {
        
        Pipe8.transform.Rotate(0, 0, 90);
        
    }

    void RotatePipe9()
    {
        
        Pipe9.transform.Rotate(0, 0, 90);
        
    }

    void RotatePipe10()
    {
        
        Pipe10.transform.Rotate(0, 0, 90);
        
    }
    

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        
        GameObject dropped = eventData.pointerDrag;
        InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();

        if (inventoryItem.item.piece == Suitpiece.Bottles)
            {
                Destroy(dropped);
                if(inventoryItem.item.state == SuitState.Broken)
                {
                    O2Items[0].gameObject.SetActive(true);
                    Voicelines.Stop();
                    Voicelines.PlayOneShot(VoicelineBottle);
                    loaded = true;
                    return;
                }

                if(inventoryItem.item.state == SuitState.Fixed)
                {
                    O2Items[1].gameObject.SetActive(true);
                    return;
                }
            }
        else
        {
            descriptor.RecivedDescription("This wont fit here");
        }

    }
    void Update()
    {
        
    }
}
