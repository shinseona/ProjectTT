using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryObj;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit rayHit;

    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out rayHit,Mathf.Infinity))
            {
                if(rayHit.transform.CompareTag("InventoryTile"))
                {
                    Instantiate(inventoryObj, rayHit.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
