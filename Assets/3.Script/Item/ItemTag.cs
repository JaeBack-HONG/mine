using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public enum Item_Type
{
    R_Gem=0,
    O_Gem,
    Y_Gem,
    G_Gem,
    B_Gem,
    P_Gem,
}
public class ItemTag : MonoBehaviour
{
    public Tilemap tilemap;


    [System.Serializable]

    public struct ItemInfo
    {
        public Item_Type itemType;
        public int quantity;
    }

    // 아이템 정보를 저장할 리스트
    public List<ItemInfo> itemInventory = new List<ItemInfo>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 젬과 충돌한 경우
        if (collision.CompareTag("Gem"))
        {
            

        }
    }

    
    



}
