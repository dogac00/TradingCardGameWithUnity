using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TypeWriter description;
    [SerializeField] private GameObject turnImage;
    [SerializeField] private CardDrawer cardDrawer;

    private Player activePlayer, opponentPlayer;

    public Player ActivePlayer => activePlayer;
    public Player OpponentPlayer => opponentPlayer;

    public void StartGame()
    {
        StartCoroutine(Routine());

        IEnumerator Routine()
        {
            description.ChangeText("Player names are set...");
            
            yield return new WaitForSeconds(2.5F);

            description.ChangeText("Selecting active player randomly...");
            int rnd = Random.Range(0, 2);
            var player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
            var player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();
            activePlayer = rnd == 0 ? player1 : player2;
            opponentPlayer = activePlayer == player1 ? player2 : player1;

            yield return new WaitForSeconds(2.5F);

            description.ChangeText($"Active player is selected. Current active player is : { activePlayer.name }");
            turnImage.SetActive(true);
            this.MoveObject(turnImage, activePlayer.gameObject.transform.position + Vector3.left * 6);

            yield return new WaitForSeconds(2.5F);

            BeginTurn();
        }
    }

    private void BeginTurn()
    {
        description.ChangeText("Starting turn...");

        StartCoroutine(Routine());

        IEnumerator Routine()
        {
            yield return new WaitForSeconds(1F);

            description.ChangeText("Giving active player one mana slot...");
            activePlayer.ReceiveManaSlot();

            yield return new WaitForSeconds(1.5F);

            description.ChangeText("Refilling active players mana slots...");
            activePlayer.RefillMana();

            yield return new WaitForSeconds(1.5F);

            description.ChangeText("Active player randomly draws one card from the deck...");
            activePlayer.DrawCardFromDeck();

            yield return new WaitForSeconds(4F);

            PlayTurn();
        }
    }

    private void PlayTurn()
    {
        StartCoroutine(PlayRoutine());

        IEnumerator PlayRoutine()
        {
            description.ChangeText("Fetching active players current hand...");

            yield return new WaitForSeconds(1.5F);

            description.ChangeText("");

            cardDrawer.DrawCardsOnScreen(activePlayer);
            
            yield return new WaitForSeconds(4F);

            
            if (!activePlayer.CanPlayHand())
            {
                description.ChangeText("Active player can not play any hand due to insufficient mana. Switching players...");

                yield return new WaitForSeconds(4);

                SwitchPlayers();

                yield return null;
            }

            description.ChangeText("Please select a card from the hand...");
        }
    }

    private void SwitchPlayers()
    {
        var active = activePlayer;
        activePlayer = opponentPlayer;
        opponentPlayer = active;
        this.MoveObject(turnImage, activePlayer.transform.position + Vector3.left * 6);
    }
}
