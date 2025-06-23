using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popups : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Button left;
    [SerializeField] Button right;
    [SerializeField] Button inventory;
    void Start()
    {
        left.interactable = false;
        right.interactable = false;
        inventory.interactable = false;
        closeButton.onClick.AddListener(ClosePopup);

    }

    void ClosePopup()
    {
        Debug.Log("Click");
        left.interactable = true;
        right.interactable = true;
        inventory.interactable = false;
        Destroy(gameObject);
    }
}
