using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyCollisionCheck : MonoBehaviour
{
    private GameObject infoObj;
    private PlayerInventoryInfo playerInventory;
    GameObject gameManager;
    UserDataBase udb;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();

        infoObj = gameManager.transform.GetChild(5).gameObject;
        playerInventory = infoObj.GetComponent<PlayerInventoryInfo>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over");
            playerInventory.itemList = new List<ItemInfo>();


            udb.PlayerisMotorcycle = false;
            SceneManager.LoadScene("step1");
        }
    }
}
