using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Toggle heal;
    private TextMeshProUGUI descr;

    void Start()
    {
        heal = GameObject.Find("HealSwitch").GetComponent<Toggle>();
        descr = GameObject.Find("Description").GetComponent<TextMeshProUGUI>();
    }

    void OnMouseDown()
    {
        var activePlayer = GameObject.Find("GameManager").GetComponent<GameManager>().ActivePlayer;
        var opponentPlayer = GameObject.Find("GameManager").GetComponent<GameManager>().ActivePlayer;
        var text = this.transform.GetChild(0).GetComponent<TextMeshPro>().text;
        var value = int.Parse(text);

        if (value > activePlayer.Mana)
        {
            descr.text = "Not enough mana to play that hand.";
            return;
        }

        activePlayer.GetHand().Remove(value);

        if (heal.isOn)
        {
            this.gameObject.SetActive(false);
            activePlayer.Heal(value);
        }
        else
        {
            this.gameObject.SetActive(false);
            opponentPlayer.TakeDamage(value);
        }

        if (!activePlayer.CanPlayHand())
        {

        }
    }
}
