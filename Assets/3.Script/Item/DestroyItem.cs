using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    
    private void Update()
    {
        
        if (StoreEvent.DestroyItemUI == true)
        {
            
            Destroy(this.gameObject);
        }
    }

}
