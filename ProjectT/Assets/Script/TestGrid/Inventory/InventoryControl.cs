using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField]
    private GameObject Inventory;
    bool StartActive =true;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(StartActive)
        {
            Inventory.SetActive(false);
            StartActive = false;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }
}
