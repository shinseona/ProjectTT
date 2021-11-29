using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpedimentsSpwan : MonoBehaviour
{
    public List<GameObject> ImpedimentsObjects = new List<GameObject>();
    private List<int> RandomPoint = new List<int>();
    private int ranNum;

    private bool _isRanTrue = true;
    private bool _isBreak;
    // Start is called before the first frame update
    void Start()
    {
        int spawnNum = Random.Range(0,101);
        ranNum = RandNum(spawnNum);
        spawnObj();
    }
    
    void spawnObj()
    {
        for (int j = 0; j < ranNum; j++)
        {
            int spawnObjNum = Random.Range(0, 3);
            int spawnPoint = CreateUnDuplicateRandom(-3, 4);

            var impediment = Instantiate(ImpedimentsObjects[spawnObjNum],
                new Vector3(spawnPoint, transform.position.y, 1),
                Quaternion.identity);
            impediment.transform.parent = transform;
        }
    }

    private int RandNum(int _ran)
    {
        if (_ran < 50)
        {
            return 0;
        }
        else if(50 <= _ran && _ran < 80)
        {
            return 1;
        }else if (80 <= _ran && _ran < 95)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }  

    // 랜덤 생성 (중복 배제)
    int CreateUnDuplicateRandom(int min, int max)
    {
        int currentNumber = Random.Range(min, max);

        for (int i = min; i < max; i++)
        {
            if (RandomPoint.Contains(currentNumber))
            {
                currentNumber = Random.Range(min, max);
            }
            else
            {
                RandomPoint.Add(currentNumber);
                return currentNumber;
                break;
            }
        }

        return 100;
    }
}
