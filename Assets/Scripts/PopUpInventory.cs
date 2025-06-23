using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpInventory : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Button inventory;
    public bool wasIShown = false;
    void Start()
    {
        wasIShown = true;
        inventory.interactable = true;
        closeButton.onClick.AddListener(ClosePopup);

    }

    void ClosePopup()
    {
        Destroy(gameObject);
    }
}
