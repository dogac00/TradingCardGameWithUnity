using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    private int health = 30;
    private int mana = 0;
    private int manaSlots = 0;
    private List<int> deck = new List<int> { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };
    private List<int> hand = new List<int>();
    
    [SerializeField]
    private TextMeshPro text;

    public int Mana => mana;

    void Start()
    {
        for (int i = 0; i < 3; i++)
            DrawCardFromDeck();
    }

    void Update()
    {
        text.text = $"Name : {this.name}\nHealth : { this.health }\nMana: {this.mana}/{this.manaSlots}";
    }

    public List<int> GetHand() => hand;

    public void ReceiveManaSlot() =>
        this.manaSlots = Math.Min(this.manaSlots + 1, 10);

    public void RefillMana() =>
        this.mana = this.manaSlots;

    public void DrawCardFromDeck()
    {
        if (this.deck.Count == 0)
            this.health--;
        else
        {
            var index = Random.Range(0, this.deck.Count);
            var elem = this.deck[index];
            this.deck.RemoveAt(index);
            
            if (this.hand.Count < 5)
                this.hand.Add(elem);
        }
    }

    public bool CanPlayHand() =>
        this.mana >= this.hand.Min();

    public void Heal(int value) =>
           this.health = Math.Min(this.health + value, 30);

    public void TakeDamage(int value) =>
        this.health -= value;
}
