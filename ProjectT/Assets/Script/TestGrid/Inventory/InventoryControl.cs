using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryControl : MonoBehaviour
{
    [SerializeField]
    private GameObject Inventory;
    [SerializeField]
    private List<GameObject> Moto;
    [SerializeField]
    private List<GameObject> NotMoto;
    bool StartActive =true;
    private bool StayMain = false;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(StartActive)
        {
            Inventory.SetActive(false);
            foreach (var VARIABLE in Moto)
            {
                VARIABLE.SetActive(true);
                VARIABLE.GetComponent<RectTransform>().localPosition = new Vector3(-10, -19, 0);
            }

            foreach (var VARIABLE in NotMoto)
            {
                VARIABLE.SetActive(false);
            }
            StartActive = false;
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="MainQ")
        {
            StayMain = true;
            foreach (var VARIABLE in Moto)
            {
                VARIABLE.SetActive(true);
                VARIABLE.GetComponent<RectTransform>().localPosition = new Vector3(14, -19, 0);
            }

            foreach (var VARIABLE in NotMoto)
            {
                VARIABLE.SetActive(true);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "MainQ")
        {
            StayMain = false;
            Inventory.SetActive(false);
            foreach (var VARIABLE in Moto)
            {
                VARIABLE.SetActive(true);
                VARIABLE.GetComponent<RectTransform>().localPosition = new Vector3(-10, -19, 0);
            }
            foreach (var VARIABLE in NotMoto)
            {
                VARIABLE.SetActive(false);
            }
        }

    }
}
