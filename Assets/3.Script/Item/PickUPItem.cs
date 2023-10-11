using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUPItem : MonoBehaviour
{

    public GameObject slotItem;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.tag.Equals("Player"))
        {
            Inventory inven = col.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++)
            {                
                if (inven.slots[i].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;
                    Destroy(this.gameObject);
                    break;
                }
            }

        }
    }
}
