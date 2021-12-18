using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawn : MonoBehaviour
{
    public GameObject spawnGameObject;
    public void Spawn(float size, int layerAdd,int icN)
    {
        float posY = 0;
        int orderLayerNum = 0;
        for (int i = 0; i < icN; i++)
        {
            posY += size;
            Vector3 bushpos = new Vector3(transform.position.x, transform.position.y + posY + transform.position.z);
            var instantBush = Instantiate(spawnGameObject, bushpos, spawnGameObject.transform.rotation);
            orderLayerNum += layerAdd;
            instantBush.GetComponent<SpriteRenderer>().sortingOrder += orderLayerNum;
            instantBush.transform.parent = transform;
        }
    }
}
