using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class InventoryTetrisManualPlacement : MonoBehaviour {

    public static InventoryTetrisManualPlacement Instance { get; private set; }

    public event EventHandler OnSelectedChanged;
    public event EventHandler OnObjectPlaced;
    [SerializeField] private Canvas canvas = null;
    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeSOList = null;
    private PlacedObjectTypeSO placedObjectTypeSO;
    private PlacedObjectTypeSO.Dir dir;
    private InventoryTetris inventoryTetris;
    private RectTransform canvasRectTransform;
    private RectTransform itemContainer;
   


    private void Awake() {
        Instance = this;

        inventoryTetris = GetComponent<InventoryTetris>();

        placedObjectTypeSO = null;

        if (canvas == null) {
            canvas = GetComponentInParent<Canvas>();
        }

        if (canvas != null) {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }

        itemContainer = transform.Find("ItemContainer").GetComponent<RectTransform>();
    }
    private void Update() {

        
        // Try to place
        if (Input.GetMouseButtonDown(0) && placedObjectTypeSO != null) {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(itemContainer, Input.mousePosition, null, out Vector2 anchoredPosition);
            Vector2Int placedObjectOrigin = inventoryTetris.GetGridPosition(anchoredPosition);

            bool tryPlaceItem = inventoryTetris.TryPlaceItem(placedObjectTypeSO as ItemTetrisSO, placedObjectOrigin, dir);


            if (tryPlaceItem) {
                OnObjectPlaced?.Invoke(this, EventArgs.Empty);
            } else {
                // Cannot build here
                TooltipCanvas.ShowTooltip_Static("Cannot Build Here!");
                FunctionTimer.Create(() => { TooltipCanvas.HideTooltip_Static(); }, 2f, "HideTooltip", true, true);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R)) {
            dir = PlacedObjectTypeSO.GetNextDir(dir);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { placedObjectTypeSO = placedObjectTypeSOList[0]; RefreshSelectedObjectType(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { placedObjectTypeSO = placedObjectTypeSOList[1]; RefreshSelectedObjectType(); }

        if (Input.GetKeyDown(KeyCode.Alpha0)) { DeselectObjectType(); }

    }

    public PlacedObject GetItem(ItemInfo _itemInfo)
    {

        PlacedObject tryPlaceItem =
            inventoryTetris.TryPlaceItem(_itemInfo.ItemSo, _itemInfo.SavePoint, dir);
        Debug.Log(tryPlaceItem.name);
        var a = tryPlaceItem.gameObject.GetComponent<ItemInfo>();
            a.NPCName= _itemInfo.NPCName;
            a.ShippingAddress = _itemInfo.ShippingAddress;

        if (tryPlaceItem != null)
        {
            OnObjectPlaced?.Invoke(this, EventArgs.Empty);
            //ItemTetrisSO itemSo = placedObjectTypeSOList[_itemID] as ItemTetrisSO;
            //playerInvenInfo.ItemList.Add(tryPlaceItem.gameObject, itemSo);

        }

        return tryPlaceItem;
    }

    public PlacedObject CreatItem(Vector2Int _itemPoint, ItemTetrisSO itemSo)
    {
        PlacedObject tryPlaceItem = inventoryTetris.TryPlaceItem(itemSo, _itemPoint, dir);
        if (tryPlaceItem != null)
        {
            OnObjectPlaced?.Invoke(this, EventArgs.Empty);
            return tryPlaceItem;
        }
        return null;
    }
    private void DeselectObjectType() {
        placedObjectTypeSO = null; RefreshSelectedObjectType();
    }

    private void RefreshSelectedObjectType() {
        OnSelectedChanged?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetCanvasSnappedPosition() {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(itemContainer, Input.mousePosition, null, out Vector2 anchoredPosition);
        inventoryTetris.GetGrid().GetXY(anchoredPosition, out int x, out int y);

        if (placedObjectTypeSO != null) {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationOffset(dir);
            Vector2 placedObjectCanvas = inventoryTetris.GetGrid().GetWorldPosition(x, y) + new Vector3(rotationOffset.x, rotationOffset.y) * inventoryTetris.GetGrid().GetCellSize();
            return placedObjectCanvas;
        } else {
            return anchoredPosition;
        }
    }

    public Quaternion GetPlacedObjectRotation() {
        if (placedObjectTypeSO != null) {
            return Quaternion.Euler(0, 0, -placedObjectTypeSO.GetRotationAngle(dir));
        } else {
            return Quaternion.identity;
        }
    }

    public PlacedObjectTypeSO GetPlacedObjectTypeSO() {
        return placedObjectTypeSO;
    }



}
