using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class EnemyCollisionCheck : MonoBehaviour
{
    private GameObject infoObj;
    private PlayerInventoryInfo playerInventory;
    GameObject gameManager;
    UserDataBase udb;
    public int PlayerHp = 100;
    private EnemyPoolable enemyPoolable;
    public Image Hpbar;
    public TextMeshProUGUI hpCount;
    private GridMove GetPlayerSpeed;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();
        GetPlayerSpeed = GameObject.Find("backG").GetComponent<GridMove>();

        infoObj = gameManager.transform.GetChild(5).gameObject;
        playerInventory = infoObj.GetComponent<PlayerInventoryInfo>();
        hpCount.SetText(PlayerHp.ToString());

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetPlayerSpeed.playerMoveSpeed = 2.0f;
            PlayerHp -= 10;
            Hpbar.fillAmount = (float)PlayerHp / 100;
            hpCount.SetText(PlayerHp.ToString());
            Debug.Log("playerHp:"+PlayerHp);
            enemyPoolable = other.gameObject.GetComponent<EnemyPoolable>();
            enemyPoolable.Push();
            if (PlayerHp <= 0)
            {
                playerInventory.itemList = new List<ItemInfo>();
                Debug.Log("Game Over");
                udb.PlayerisMotorcycle = false;
                SceneManager.LoadScene("step1");
            }
        }
        if (other.gameObject.tag == "Impediments")
        {
            GetPlayerSpeed.playerMoveSpeed = 2.0f;
            Destroy(other.gameObject);
            PlayerHp -= 10;
            Hpbar.fillAmount = (float)PlayerHp /100;
            hpCount.SetText(PlayerHp.ToString());
            if (PlayerHp <= 0)
            {
                playerInventory.itemList = new List<ItemInfo>();
                Debug.Log("Game Over");
                udb.PlayerisMotorcycle = false;
                SceneManager.LoadScene("step1");
            }
        }
    }
}
