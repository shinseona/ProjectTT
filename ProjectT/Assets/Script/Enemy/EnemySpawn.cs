using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public bool _isRight = true;
    private Vector3 spawnVector;
    private GameObject player;
    
    private bool _isSpawn;
    private bool _isPlayerComing; 
   [SerializeField]
    private float spawnSec=1.5f;

    private float playerDistance;
    private int RanNum;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _isPlayerComing = true;
        _isSpawn = true;
        spawnVector = transform.position;
        RanNum = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        float rn = Random.Range(5, 7);
        spawnSec =3.5f;
        playerDistance = player.transform.position.y - transform.position.y;
        
        if (-10>playerDistance||playerDistance>15) return;
        
        if (_isSpawn)
        {
            _isSpawn = false;
            StartCoroutine(SpawnTiem(spawnSec));
            if (_isPlayerComing)
            {
                GameObject enemy =
                   EnemyPoolManager.Static_EnemyPop(RanNum);
                enemy.transform.position = transform.position;
                enemy.GetComponent<EnemyMove>().GridTransform = transform.position;
                enemy.GetComponent<EnemyMove>()._isMoveRight = !_isRight;
                var anim=enemy.GetComponent<Animator>();
                
                if(!_isRight)
                anim.SetTrigger("Right");
                else
                anim.SetTrigger("Left");
            }
        }
    }

    IEnumerator SpawnTiem(float a)
    {
        yield return new WaitForSeconds(a); ;
        _isSpawn = true;
    }
}
