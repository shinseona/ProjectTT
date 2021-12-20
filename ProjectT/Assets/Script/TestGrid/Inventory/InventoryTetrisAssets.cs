using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTetrisAssets : MonoBehaviour {


    public static InventoryTetrisAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public ItemTetrisSO[] itemTetrisSOArray;

    public ItemTetrisSO box;
    public ItemTetrisSO post;
    public ItemTetrisSO shovel;
    public ItemTetrisSO Pick;
    public ItemTetrisSO Rake;
    public ItemTetrisSO Homi;
    public ItemTetrisSO TV;
    public ItemTetrisSO Refrigerator;

    public ItemTetrisSO GetItemTetrisSOFromName(string itemTetrisSOName) {
        foreach (ItemTetrisSO itemTetrisSO in itemTetrisSOArray) {
            if (itemTetrisSO.name == itemTetrisSOName) {
                return itemTetrisSO;
            }
        }
        return null;
    }


    public Sprite gridBackground;
    public Sprite gridBackground_2;
    public Sprite gridBackground_3;

    public Transform gridVisual;

}