using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cardController : MonoBehaviour
{
    public BoxCollider2D thisCard;
    public bool isMouseOver;
    

    private void Start()
    {
        thisCard = GetComponent<BoxCollider2D>();

    }
    private void OnMouseDown()
    {
        isMouseOver = true;
    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
    
    
}

public enum CardSprite //enum é basicamente um array, como esse está público posso usar nos outros scripts
{
    //Present
        MainChar,
        Agent,
        Dad,
        DadToy,
        Grandma, 
        GrandmaHologram,
        Boy1,
        Boy2,
        Boy3,
        Girl1,   
    //1889
        Marie,
        Pierre,
        Scientist1,
        Scientist2,
        ScientistToy,
    //1883
        Ada, 
        Babbage,
        Professor1,
        Professor2,
        ProfessorToy
       

}

