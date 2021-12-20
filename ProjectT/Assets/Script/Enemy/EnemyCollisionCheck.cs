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
    private Animator anima;
    public float invincibilityTime = 5.0f;
    private bool isInvincibility = false;
    public FadeManager fader;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        udb = gameManager.transform.GetChild(1).GetComponent<UserDataBase>();
        GetPlayerSpeed = GameObject.Find("backG").GetComponent<GridMove>();


        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        infoObj = gameManager.transform.GetChild(5).gameObject;
        playerInventory = infoObj.GetComponent<PlayerInventoryInfo>();
        hpCount.SetText(PlayerHp.ToString());
        anima = GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyPoolable = other.gameObject.GetComponent<EnemyPoolable>();
            enemyPoolable.Push();

            if (!isInvincibility)
            {
                StartCoroutine(Invincibility());
                GetPlayerSpeed.playerMoveSpeed = 2.0f;
                anima.SetTrigger("crash");
                PlayerHp -= 10;
                Hpbar.fillAmount = (float) PlayerHp / 100;
                hpCount.SetText(PlayerHp.ToString());


                if (PlayerHp <= 0)
                {
                    playerInventory.itemList = new List<ItemInfo>();
                    udb.PlayerisMotorcycle = false;
                    StartCoroutine(fader.FadeInActiveate(fader, "step1"));
                }
            }
        }
        if (other.gameObject.tag == "Impediments")
        {
            Destroy(other.gameObject);
            if (!isInvincibility)
            {
                StartCoroutine(Invincibility());
                GetPlayerSpeed.playerMoveSpeed = 2.0f;
                anima.SetTrigger("crash");
                PlayerHp -= 10;
                Hpbar.fillAmount = (float) PlayerHp / 100;
                hpCount.SetText(PlayerHp.ToString());
                if (PlayerHp <= 0)
                {
                    playerInventory.itemList = new List<ItemInfo>();
                    udb.PlayerisMotorcycle = false;
                    StartCoroutine(fader.FadeInActiveate(fader, "step1"));
                }
            }
        }
    }

    IEnumerator Invincibility()
    {
        isInvincibility = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincibility = false;
    }
}
