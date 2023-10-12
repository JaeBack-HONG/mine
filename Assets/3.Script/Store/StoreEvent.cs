using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreEvent : MonoBehaviour
{
    public static bool DestroyItemUI = false;// UI �κ��丮 �̹��� ���� Check

    private bool isPlayerInside = false; // �÷��̾ Ʈ���� ���� �ȿ� �ִ��� ���θ� �����ϱ� ���� ����
    
    private Inventory playerInventory;
    

    private void Start()
    {
        playerInventory = FindObjectOfType<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerInside = true; // �÷��̾ Ʈ���� ���� �ȿ� ����
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerInside = false; // �÷��̾ Ʈ���� ������ ����
        }
    }
    private void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.Y))
        {
            // �÷��̾ Ʈ���� ���� �ȿ� �ְ� �����̽��ٰ� ������ �� ����
            DisplayUI.playerMoney += DisplayUI.TotalMoney;
            DestroyItemUI = true;
                        
            for (int i = 0; i < playerInventory.slots.Count; i++)
            {
                if (playerInventory.slots[i].isEmpty == false)
                {
                    playerInventory.slots[i].isEmpty = true;                   

                }
            }
            DisplayUI.TotalMoney = 0;
        }
        if (isPlayerInside == false)
        {
            DestroyItemUI = false;
        }
    }
}


