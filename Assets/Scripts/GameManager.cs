using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    //Vari�veis
    public static int intelliegenceRight;
    public static int happinessRight;
    public static int lifeRight;
    public static int intelligenceLeft;
    public static int happinessLeft;
    public static int lifeLeft;

    int x = 0;

    //GameObjects
    public GameObject cardGameObject;
    public SpriteRenderer cardSpriteRenderer;
    public cardController mainCardController;
    public resourceManager resourceManager;
    public Vector2 defaultPositionCard;
    public Vector3 cardRotation;

    //Vari�veis diversas
    public float fMovingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public float fTransparency;
    public float fRotation;
    public float divideValue;
    public float backgroundDivideValue;
    public Color textColor;
    public Color quoteBackgroundColor;
  
    //UI
    public TMP_Text actionQuote;
    public TMP_Text characterDialogue;
    public TMP_Text characterName;
    public SpriteRenderer quoteBackground;
    public Image intelligenceImage;
    public Image happinessImage;
    public Image lifeImage;
    public Image intelligenceImageImpact;
    public Image happinessImageImpact;
    public Image lifeImageImpact;

    //Vari�veis dos cards
    private string charName;
    private string dialogue;
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;


    private void Start()
    {
        LoadCard(testCard);
        defaultPositionCard = cardGameObject.transform.position;
        
    }

    public void UpdateActionQuote()
    {
        //dependendo da dire��o vai uma resposta
        if(cardGameObject.transform.position.x > 0)
        {
            actionQuote.text = rightQuote;
        }
        else
        {
            actionQuote.text = leftQuote;
        }
    }
    public void Update()
    {
        
        //Transparency
        characterName.text = charName;
        characterDialogue.text = dialogue;
        textColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x/divideValue), 1); //para ver a posi��o da carta em tempo real, para fazer o gradiente da cor do texto
        quoteBackgroundColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x/backgroundDivideValue), fTransparency);
       
        actionQuote.color = textColor;
        quoteBackground.color = quoteBackgroundColor;

        UpdateActionQuote();

        //Card Movement
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // se o mouse estiver sobre o objeto ele move
            cardGameObject.transform.position = pos;
        }
        else
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultPositionCard, fMovingSpeed); 
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);// se soltar o mouse o objeto volta para o meio

        }

        //Card Text
        textColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin, 1); //transparecia do texto
    
        //Fill Icons
        if (cardGameObject.transform.position.x >= fSideTrigger) 
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (currentCard.lifeRight != 0)
                {
                    lifeImage.fillAmount += currentCard.lifeRight / 100f;
                }
                if (currentCard.intelligenceRight != 0)
                {
                    intelligenceImage.fillAmount += currentCard.intelligenceRight / 100f;
                }
                if (currentCard.happinessRight != 0)
                {
                    happinessImage.fillAmount += currentCard.happinessRight / 100f;
                }
                NewCardRight();

                x++;
            }
        }
        else if(cardGameObject.transform.position.x >= fSideMargin){
            if (cardGameObject.transform.position.x > 0)
            {
                //UI
                if (currentCard.intelligenceRight != 0)
                    intelligenceImageImpact.transform.localScale = new Vector3(20, 20, -1);
                if (currentCard.happinessRight != 0)
                    happinessImageImpact.transform.localScale = new Vector3(20, 20, -1);
                if (currentCard.lifeRight != 0)
                    lifeImageImpact.transform.localScale = new Vector3(20, 20, -1); //esse vetor é uma gambiarra

            }
        }
        
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            textColor.a = 0;
            //UI
            intelligenceImageImpact.transform.localScale = new Vector3(0, 0, 0);
            happinessImageImpact.transform.localScale = new Vector3(0, 0, 0);
            lifeImageImpact.transform.localScale = new Vector3(0, 0, 0);
        }
       //else if(cardGameObject.transform.position.x > fSideTrigger){}
        else
        {
            //UI
            if (currentCard.intelligenceLeft != 0)
                intelligenceImageImpact.transform.localScale = new Vector3(20, 20, -1);
            if (currentCard.happinessLeft != 0)
                happinessImageImpact.transform.localScale = new Vector3(20, 20, -1);
            if (currentCard.lifeLeft != 0)
                lifeImageImpact.transform.localScale = new Vector3(20, 20, -1);
 
            if (Input.GetMouseButtonUp(0))
            {
              
                if (currentCard.lifeLeft != 0)
                {
                    lifeImage.fillAmount += currentCard.lifeLeft / 100f;
                }
                if (currentCard.intelligenceLeft != 0)
                {
                    intelligenceImage.fillAmount += currentCard.intelligenceLeft / 100f;
                }
                if (currentCard.happinessLeft != 0)
                {
                    happinessImage.fillAmount += currentCard.happinessLeft / 100f;
                }
                NewCardLeft();

                x++;
            }
        }

        //Rotation of the card

        cardGameObject.transform.eulerAngles = new Vector3(0, 0, -cardGameObject.transform.position.x*1.5f);
    }

    public void LoadCard(Card card)
    {

        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        charName = card.cardName;
        dialogue = card.dialogue;
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
    }
    public void NewCardLeft()
    {
            LoadCard(currentCard.leftCard);
    }
    public void NewCardRight()
    {
            LoadCard(currentCard.rightCard);
    }
}
