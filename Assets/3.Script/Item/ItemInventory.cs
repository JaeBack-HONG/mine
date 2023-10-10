using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    // 아이템을 저장할 딕셔너리
    private Dictionary<Item_Type, int> inventory;

    private void Start()
    {
        inventory = new Dictionary<Item_Type, int>();
    }

    // 아이템을 추가하는 메서드
    public void AddItem(Item_Type itemType, int quantity)
    {
        if (inventory.ContainsKey(itemType))
        {
            inventory[itemType] += quantity;
        }
        else
        {
            inventory[itemType] = quantity;
        }

        Debug.Log($"획득: {itemType}, 수량: {inventory[itemType]}");
    }

    // 아이템을 사용하는 메서드 (추가 구현 필요)
    public void UseItem(Item_Type itemType)
    {
        if (inventory.ContainsKey(itemType) && inventory[itemType] > 0)
        {
            // 아이템 사용 로직을 여기에 추가
            // 예: 아이템 사용 후 수량 감소
            inventory[itemType]--;
            Debug.Log($"사용: {itemType}, 수량: {inventory[itemType]}");
        }
        else
        {
            Debug.Log($"아이템 {itemType}을 가지고 있지 않거나 수량이 부족합니다.");
        }
    }
}
