using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    // �������� ������ ��ųʸ�
    private Dictionary<Item_Type, int> inventory;

    private void Start()
    {
        inventory = new Dictionary<Item_Type, int>();
    }

    // �������� �߰��ϴ� �޼���
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

        Debug.Log($"ȹ��: {itemType}, ����: {inventory[itemType]}");
    }

    // �������� ����ϴ� �޼��� (�߰� ���� �ʿ�)
    public void UseItem(Item_Type itemType)
    {
        if (inventory.ContainsKey(itemType) && inventory[itemType] > 0)
        {
            // ������ ��� ������ ���⿡ �߰�
            // ��: ������ ��� �� ���� ����
            inventory[itemType]--;
            Debug.Log($"���: {itemType}, ����: {inventory[itemType]}");
        }
        else
        {
            Debug.Log($"������ {itemType}�� ������ ���� �ʰų� ������ �����մϴ�.");
        }
    }
}
