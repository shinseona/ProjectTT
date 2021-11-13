using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolable : MonoBehaviour
{
    protected EnemyPool pool;
    public int Enemy_ID; 
    public virtual void Create(EnemyPool _pool)
    {
        pool = _pool;
        gameObject.SetActive(false);
    }
    public virtual GameObject Pop()
    {
        return pool.Pop();
    }
    public virtual void Push()
    {
        pool.Push(this);
    }
}
