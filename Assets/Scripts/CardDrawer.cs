using TMPro;
using UnityEngine;

public class CardDrawer : MonoBehaviour
{
    [SerializeField] private Card[] cards;

    public void DrawCardsOnScreen(Player player)
    {
        foreach (var card in cards)
        {
            card.gameObject.SetActive(false);
        }

        var hand = player.GetHand();

        for (int i = 0; i < hand.Count; i++)
        {
            var card = cards[i];

            var cardTmp = card.transform.GetChild(0).GetComponent<TextMeshPro>();
            card.gameObject.SetActive(true);
            cardTmp.text = hand[i].ToString();
        }
    }
}
