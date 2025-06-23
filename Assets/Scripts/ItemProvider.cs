using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProvider : MonoBehaviour
{
    public static ItemProvider Instance;

    [SerializeField] private bool useAsSingleton;
    [SerializeField] private Item item;
    public Item GetItem() => item;
    private void Awake()
    {
        if (useAsSingleton)
        {
            if (Instance == null)
            {
                Instance = this;

            }
            else
            {
                Destroy(Instance.gameObject);
                return;
            }
           
        }

    }

   
}
