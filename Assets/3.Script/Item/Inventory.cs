using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 15;
    public GameObject slotPrefab;

    private void Start()
    {
        GameObject slot_InventoryUI = GameObject.Find("Panel");

        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slot_InventoryUI.transform, false);

            go.name = "Slot_" + i;
            SlotData slot = new SlotData();            
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }
    }
}
