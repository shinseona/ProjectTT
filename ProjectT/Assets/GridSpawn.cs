using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> GridSpawnObj;
    
    private int choiceGrid;
    public int maxSize=30;
    public int nowPoint=0;
    
    // Start is called before the first frame update
    private void Start()
    {
        List<GameObject> road1= new List<GameObject>();
        road1.Add(GridSpawnObj[0]);
        road1.Add(GridSpawnObj[1]);
        List<GameObject> road2 = new List<GameObject>();
        road2.Add(GridSpawnObj[2]);
        road2.Add(GridSpawnObj[3]);
        List<GameObject> road3 = new List<GameObject>();
        road3.Add(GridSpawnObj[4]);
        road3.Add(GridSpawnObj[5]);
        for (; nowPoint < maxSize; nowPoint++)
        {
            int ranNum = Random.Range(0, 101);
            var rRanNum=RetrunRandomNum(ranNum);
            var choice
                = road1[rRanNum];
            var grids = Instantiate(choice, new Vector3(0, nowPoint, 0), Quaternion.identity);

        }

        maxSize += 30;
        
        for (; nowPoint < maxSize; nowPoint++)
        {
            int ranNum = Random.Range(0, 101);
            var rRanNum = RetrunRandomNum(ranNum);
            var choice
                = road2[rRanNum];
            var grids = Instantiate(choice, new Vector3(0, nowPoint, 0), Quaternion.identity);

        }

        maxSize += 30;
        for (; nowPoint < maxSize; nowPoint++)
        {
            int ranNum = Random.Range(0, 101);
            var rRanNum = RetrunRandomNum(ranNum);
            var choice
                = road3[rRanNum];
            var grids = Instantiate(choice, new Vector3(0, nowPoint, 0), Quaternion.identity);

        }
    }

    public int RetrunRandomNum(int _num)
    {
        if (_num >= 0 && _num < 50)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

}
