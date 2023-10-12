using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Item_Type
{
    R_Gem = 0,
    O_Gem,
    Y_Gem,
    G_Gem,
    B_Gem,
    P_Gem,
}
public class PickUPItem : MonoBehaviour
{

    public GameObject slotItem;
    
    

    public int R_gemPrice = 100;
    public int O_gemPrice = 200;
    public int Y_gemPrice = 400;
    public int G_gemPrice = 600;
    public int B_gemPrice = 1000;
    public int P_gemPrice = 10000;

    public int Total = DisplayUI.TotalMoney;
    private void OnTriggerEnter2D(Collider2D col)
    {               
        if (col.tag.Equals("Player"))
        {
            Inventory inven = col.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++)
            {                
                if (inven.slots[i].isEmpty)
                {
                    switch (slotItem.name)
                    {
                        case "R_GemUI":
                            Total += R_gemPrice;
                            break;
                        case "O_GemUI":
                            Total += O_gemPrice;
                            break;
                        case "Y_GemUI":
                            Total += Y_gemPrice;
                            break;
                        case "G_GemUI":
                            Total += G_gemPrice;
                            break;
                        case "B_GemUI":
                            Total += B_gemPrice;
                            break;
                        
                    }
                    DisplayUI.TotalMoney += Total;

                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;
                    Destroy(this.gameObject);
                    break;
                }
            }

        }
    }
}
