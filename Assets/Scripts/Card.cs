using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public CardSprite sprite;
    public string cardName;
    public int cardID;
    public string dialogue;
    public string leftQuote;
    public string rightQuote;

    //Logic
    public int intelligenceRight;
    public int happinessRight;
    public int lifeRight;

    public int intelligenceLeft;
    public int happinessLeft;
    public int lifeLeft;


    public Card rightCard;
    public Card leftCard;

    
}
