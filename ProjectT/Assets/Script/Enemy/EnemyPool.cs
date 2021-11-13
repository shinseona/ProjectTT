using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject  EnemyObj;
    private EnemyPoolable enemyPoolable;
    public EnemyPoolable EnemyPoolable
    {
        get => enemyPoolable;
    }

    [SerializeField] private int allocateCount;

    private  Stack<EnemyPoolable> poolStack = new Stack<EnemyPoolable>();

    void Awake()
    {
        enemyPoolable = EnemyObj.GetComponent<EnemyPoolable>();
    }
    // Start is called before the first frame update
    void Start()
    {

        Allocate();
    }

    // Update is called once per frame
    public void Allocate()
    {
        for (int i = 0; i < allocateCount; i++)
        {
            EnemyPoolable ep = Instantiate(enemyPoolable, gameObject.transform);
            ep.Create(this);
            poolStack.Push(ep);
        }
    }

    public GameObject Pop()
    {
        EnemyPoolable obj = poolStack.Pop();
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }

    public void Push(EnemyPoolable obj)
    {
        obj.gameObject.SetActive(false);
        poolStack.Push(obj);
    }
}
