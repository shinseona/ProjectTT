using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> GridSpawnObj;
    
    private int choiceGrid;
    public int maxSize=65;
    private int nowSize = 0;
    public int nowPoint=0;
    public GameObject BackGrid;
    // Start is called before the first frame update
    private void Start()
    {
        List<GameObject> road1= new List<GameObject>();
        road1.Add(GridSpawnObj[0]);
        road1.Add(GridSpawnObj[1]);
        road1.Add(GridSpawnObj[2]);
        List<GameObject> road2 = new List<GameObject>();
        road2.Add(GridSpawnObj[3]);
        road2.Add(GridSpawnObj[4]);
        road2.Add(GridSpawnObj[5]);
        List<GameObject> road3 = new List<GameObject>();
        road3.Add(GridSpawnObj[6]);
        road3.Add(GridSpawnObj[7]);
        road3.Add(GridSpawnObj[8]);

        nowSize += maxSize;
        for (; nowPoint < nowSize; nowPoint++)
        {
            int ranNum = Random.Range(0, 101);
            var rRanNum=RetrunRandomNum(ranNum,2);
            var choice
                = road1[rRanNum];
            var grids = Instantiate(choice, new Vector3(0, nowPoint, 0), Quaternion.identity);
            grids.transform.parent = BackGrid.transform;
        }

        nowSize += maxSize;
        for (; nowPoint < nowSize; nowPoint++)
        {
            int ranNum = Random.Range(0, 101);
            var rRanNum = RetrunRandomNum(ranNum,10);
            var choice
                = road2[rRanNum];
            var grids = Instantiate(choice, new Vector3(0, nowPoint, 0), Quaternion.identity);
            grids.transform.parent = BackGrid.transform;
        }

        nowSize += maxSize;
        for (; nowPoint < nowSize; nowPoint++)
        {
            int ranNum = Random.Range(0, 101);
            var rRanNum = RetrunRandomNum(ranNum,15);
            var choice
                = road3[rRanNum];
            var grids = Instantiate(choice, new Vector3(0, nowPoint, 0), Quaternion.identity);
            grids.transform.parent = BackGrid.transform;
        }
    }

    public int RetrunRandomNum(int _num,int RanMaker)
    {
        if (_num >= 0 && _num < RanMaker)
        {
            return 0;
        }
        else if(_num >= RanMaker && _num < RanMaker*2)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

}
