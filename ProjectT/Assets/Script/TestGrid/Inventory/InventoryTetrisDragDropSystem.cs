using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class InventoryTetrisDragDropSystem : MonoBehaviour
{

    public static InventoryTetrisDragDropSystem Instance { get; private set; }



    [SerializeField] private List<InventoryTetris> inventoryTetrisList;

    private InventoryTetris draggingInventoryTetris;
    private PlacedObject draggingPlacedObject;
    private Vector2Int mouseDragGridPositionOffset;
    private Vector2 mouseDragAnchoredPositionOffset;
    private PlacedObjectTypeSO.Dir dir;
    [SerializeField] private PlayerInventoryInfo playerInventory;
    [SerializeField]
    private ItemCreater itemCreater;

    private ItemTetrisSO itemSo;
    private string ToolTip= "놓을 수 없습니다.";
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerInventory = GameObject.Find("ItemInfo").gameObject.GetComponent<PlayerInventoryInfo>(); 
        foreach (InventoryTetris inventoryTetris in inventoryTetrisList)
        {
            inventoryTetris.OnObjectPlaced += (object sender, PlacedObject placedObject) =>
            {
            };
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    dir = PlacedObjectTypeSO.GetNextDir(dir);
        //}

        if (draggingPlacedObject != null)
        {
            // Calculate target position to move the dragged item
            RectTransformUtility.ScreenPointToLocalPointInRectangle(draggingInventoryTetris.GetItemContainer(), Input.mousePosition, null, out var targetPosition);
            targetPosition += new Vector2(-mouseDragAnchoredPositionOffset.x, -mouseDragAnchoredPositionOffset.y);

            // Apply rotation offset to target position
            var rotationOffset = draggingPlacedObject.GetPlacedObjectTypeSO().GetRotationOffset(dir);
            targetPosition += new Vector2(rotationOffset.x, rotationOffset.y) * draggingInventoryTetris.GetGrid().GetCellSize();

            // Snap position
            targetPosition /= 10f;// draggingInventoryTetris.GetGrid().GetCellSize();
            targetPosition = new Vector2(Mathf.Floor(targetPosition.x), Mathf.Floor(targetPosition.y));
            targetPosition *= 10f;

            // Move and rotate dragged object
            draggingPlacedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(draggingPlacedObject.GetComponent<RectTransform>().anchoredPosition, targetPosition, Time.deltaTime * 20f);
            draggingPlacedObject.transform.rotation = Quaternion.Lerp(draggingPlacedObject.transform.rotation, Quaternion.Euler(0, 0, -draggingPlacedObject.GetPlacedObjectTypeSO().GetRotationAngle(dir)), Time.deltaTime * 15f);
        }
    }

    public void StartedDragging(InventoryTetris inventoryTetris, PlacedObject placedObject)
    {
        // Started Dragging
        draggingInventoryTetris = inventoryTetris;
        draggingPlacedObject = placedObject;

        Cursor.visible = false;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(inventoryTetris.GetItemContainer(), Input.mousePosition, null, out Vector2 anchoredPosition);
        Vector2Int mouseGridPosition = inventoryTetris.GetGridPosition(anchoredPosition);

        // Calculate Grid Position offset from the placedObject origin to the mouseGridPosition
        mouseDragGridPositionOffset = mouseGridPosition - placedObject.GetGridPosition();

        // Calculate the anchored poisiton offset, where exactly on the image the player clicked
        mouseDragAnchoredPositionOffset = anchoredPosition - placedObject.GetComponent<RectTransform>().anchoredPosition;

        // Save initial direction when started draggign
        dir = placedObject.GetDir();

        // Apply rotation offset to drag anchored position offset
        Vector2Int rotationOffset = draggingPlacedObject.GetPlacedObjectTypeSO().GetRotationOffset(dir);
        mouseDragAnchoredPositionOffset += new Vector2(rotationOffset.x, rotationOffset.y) * draggingInventoryTetris.GetGrid().GetCellSize();

    }

    public void StoppedDragging(InventoryTetris fromInventoryTetris, PlacedObject placedObject)
    {
        draggingInventoryTetris = null;
        draggingPlacedObject = null;
        Cursor.visible = true;
        var tempiteminfo = placedObject.gameObject.GetComponent<ItemInfo>();

        // Remove item from its current inventory
        fromInventoryTetris.RemoveItemAt(placedObject.GetGridPosition());
        InventoryTetris toInventoryTetris = null;

        // Find out which InventoryTetris is under the mouse position
        foreach (InventoryTetris inventoryTetris in inventoryTetrisList)
        {
            Vector3 screenPoint = Input.mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(inventoryTetris.GetItemContainer(), screenPoint, null, out Vector2 anchoredPosition);
            Vector2Int placedObjectOrigin = inventoryTetris.GetGridPosition(anchoredPosition);
            placedObjectOrigin = placedObjectOrigin - mouseDragGridPositionOffset;

            if (inventoryTetris.IsValidGridPosition(placedObjectOrigin))
            {
                toInventoryTetris = inventoryTetris;
                break;
            }
        }
        itemSo = placedObject.GetComponent<ItemInfo>().ItemSo;
        // Check if it's on top of a InventoryTetris
        if (toInventoryTetris != null)
        {
            Vector3 screenPoint = Input.mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(toInventoryTetris.GetItemContainer(), screenPoint, null, out Vector2 anchoredPosition);
            Vector2Int placedObjectOrigin = toInventoryTetris.GetGridPosition(anchoredPosition);
            placedObjectOrigin = placedObjectOrigin - mouseDragGridPositionOffset;

            PlacedObject tryPlaceItem = toInventoryTetris.TryPlaceItem(placedObject.GetPlacedObjectTypeSO() as ItemTetrisSO, placedObjectOrigin, dir);
            var iteminfo =tryPlaceItem?.gameObject.GetComponent<ItemInfo>();
            if (iteminfo != null)
            {
                iteminfo.NPCName = tempiteminfo.NPCName;
                iteminfo.ShippingAddress = tempiteminfo.ShippingAddress;
                    
            }
            //ItemTetrisSO itemSo = placedObject.GetPlacedObjectTypeSO() as ItemTetrisSO;
            itemSo = placedObject.GetComponent<ItemInfo>().ItemSo;
            if (tryPlaceItem)
            {
                switch (fromInventoryTetris.name)
                {
                    case "InventoryTetris":
                        switch (toInventoryTetris.name)
                        {
                            case "MotorcycleInventoryTetris":
                                iteminfo.SavePoint = placedObjectOrigin; 
                                playerInventory.ItemInit(iteminfo);
                                break;
                            case "CreateInventoryTetris":
                                TooltipCanvas.ShowTooltip_Static(ToolTip);
                                FunctionTimer.Create(() => { TooltipCanvas.HideTooltip_Static(); }, 2f, "HideTooltip", true, true);

                                // Drop on original position
                                PlacedObject fromInventoryTryPlaceItem = fromInventoryTetris.TryPlaceItem(itemSo, placedObject.GetGridPosition(), placedObject.GetDir());
                                var fromInventoryIteminfo = fromInventoryTryPlaceItem.gameObject.GetComponent<ItemInfo>();
                                fromInventoryIteminfo.NPCName = tempiteminfo.NPCName;
                                fromInventoryIteminfo.ShippingAddress = tempiteminfo.ShippingAddress;
                                break;
                        }
                        break;
                    case "MotorcycleInventoryTetris":
                        switch (toInventoryTetris.name)
                        {
                            case "InventoryTetris":
                                playerInventory.ItemRemove(tempiteminfo);
                                break;
                            case "CreateInventoryTetris":
                                TooltipCanvas.ShowTooltip_Static(ToolTip);
                                FunctionTimer.Create(() => { TooltipCanvas.HideTooltip_Static(); }, 2f, "HideTooltip", true, true);

                                // Drop on original position
                                PlacedObject fromInventoryTryPlaceItem = fromInventoryTetris.TryPlaceItem(itemSo, placedObject.GetGridPosition(), placedObject.GetDir());
                                var fromInventoryIteminfo = fromInventoryTryPlaceItem.gameObject.GetComponent<ItemInfo>();
                                fromInventoryIteminfo.NPCName = tempiteminfo.NPCName;
                                fromInventoryIteminfo.ShippingAddress = tempiteminfo.ShippingAddress;
                                break;
                            case "MotorcycleInventoryTetris":
                                playerInventory.CItem(tempiteminfo, iteminfo,placedObjectOrigin);
                               
                                break;
                                
                        }

                        break;
                    case "CreateInventoryTetris":
                        switch (toInventoryTetris.name)
                        {
                            case "MotorcycleInventoryTetris":
                                playerInventory.ItemInit(iteminfo);
                                iteminfo.SavePoint = placedObjectOrigin;
                                itemCreater.CreatItem();
                                break;
                            case "InventoryTetris":
                                itemCreater.CreatItem();
                                break;
                        }

                        break;
                }
            }
            // Item placed!

            else
            {
                // Cannot drop item here!
                TooltipCanvas.ShowTooltip_Static(ToolTip);
                FunctionTimer.Create(() => { TooltipCanvas.HideTooltip_Static(); }, 2f, "HideTooltip", true, true);

                // Drop on original position
                PlacedObject fromInventoryTryPlaceItem = fromInventoryTetris.TryPlaceItem(itemSo, placedObject.GetGridPosition(), placedObject.GetDir());
                var fromInventoryIteminfo = fromInventoryTryPlaceItem.gameObject.GetComponent<ItemInfo>();
                fromInventoryIteminfo.NPCName = tempiteminfo.NPCName;
                fromInventoryIteminfo.ShippingAddress = tempiteminfo.ShippingAddress;
            }
        }
        else
        {
            // Not on top of any Inventory Tetris!

            // Cannot drop item here!
            TooltipCanvas.ShowTooltip_Static(ToolTip);
            FunctionTimer.Create(() => { TooltipCanvas.HideTooltip_Static(); }, 2f, "HideTooltip", true, true);

            // Drop on original position
            PlacedObject fromInventoryTryPlaceItem = fromInventoryTetris.TryPlaceItem(itemSo, placedObject.GetGridPosition(), placedObject.GetDir());
            var fromInventoryIteminfo = fromInventoryTryPlaceItem.gameObject.GetComponent<ItemInfo>();
            fromInventoryIteminfo.NPCName = tempiteminfo.NPCName;
            fromInventoryIteminfo.ShippingAddress = tempiteminfo.ShippingAddress;
        }
    }
}



