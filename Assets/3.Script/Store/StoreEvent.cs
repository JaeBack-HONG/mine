using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreEvent : MonoBehaviour
{
    public static bool DestroyItemUI = false;// UI 인벤토리 이미지 제거 Check

    private bool isPlayerInside = false; // 플레이어가 트리거 영역 안에 있는지 여부를 추적하기 위한 변수
    
    private Inventory playerInventory;
    

    private void Start()
    {
        playerInventory = FindObjectOfType<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerInside = true; // 플레이어가 트리거 영역 안에 들어옴
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerInside = false; // 플레이어가 트리거 영역을 나감
        }
    }
    private void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.Y))
        {
            // 플레이어가 트리거 영역 안에 있고 스페이스바가 눌렸을 때 실행
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


