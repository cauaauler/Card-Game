using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class InventoryController : MonoBehaviour
{
    public Item[] item;
    public GameObject mouseItem;


    public void DragItem(GameObject button)//essse objeto � o objeto que voc� vai puxar
    {
        mouseItem = button;
        mouseItem.transform.position = Input.mousePosition;
        //ver o video do caio sobre invent�rio ap�s os 27 minutos
    }
    public void DropItem(GameObject button)//esse objeto � o objeto que est� recebendo o drop
    {
        Transform backup = mouseItem.transform.parent;    

        if(mouseItem != null)
        {
            mouseItem.transform.SetParent(button.transform.parent);
            button.transform.SetParent(backup);
        }
    }
    
       
}
