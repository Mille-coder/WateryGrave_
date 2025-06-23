using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button openInv;
    [SerializeField] private Button closeInv;
    [SerializeField] private GameObject Inv;
    [SerializeField] private TextMeshProUGUI descriptions;
    [SerializeField] private Room[] rooms;
    
    private int currentLevel = 0;

 
    void Start() 
    {
        leftButton.onClick.AddListener(GoLeft);
        rightButton.onClick.AddListener(GoRight);
        openInv.onClick.AddListener(OpenInventory);
        closeInv.onClick.AddListener(CloseInventory);

        for (int i = 0; i < rooms.Length; i++)
        {
            if(rooms[i].gameObject.activeSelf)
            {
                currentLevel = i;
                
            }
        }

    }

    private void GoLeft()
    {
        if(currentLevel <= 0)
        {
            rooms[currentLevel].gameObject.SetActive(false);
            currentLevel = 3;
            rooms[currentLevel].gameObject.SetActive(true);
            
        }
        else
        {
            rooms[currentLevel].gameObject.SetActive(false);
            currentLevel--;
            rooms[currentLevel].gameObject.SetActive(true);
        }
    }

    private void GoRight()
    {
        if(currentLevel >= 3)
        {
            rooms[currentLevel].gameObject.SetActive(false);
            currentLevel = 0;
            rooms[currentLevel].gameObject.SetActive(true);
        }
        else
        {
            rooms[currentLevel].gameObject.SetActive(false);
            currentLevel++;
            rooms[currentLevel].gameObject.SetActive(true);
        }
    }

    private void OpenInventory()
    {
        Inv.SetActive(true);
        closeInv.gameObject.SetActive(true);
        openInv.gameObject.SetActive(false);
    }

    private void CloseInventory()
    {
        Inv.SetActive(false);
        closeInv.gameObject.SetActive(false);
        openInv.gameObject.SetActive(true);
    }
    

    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
