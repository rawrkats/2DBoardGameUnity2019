using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public int diceRollValue = 0;
    public Player[] players;
    public GameObject questionPanel;
    // Start is called before the first frame update

    void Awake()
    {
        InitializeGame();
    }



    public void RollDice()
    {
        Player whichPlayer;
        diceRollValue = Random.Range(1, 7);

        if (players[0].isTurn)
        {
            whichPlayer = players[0];
        }
        else
        {
            whichPlayer = players[1];
        }

        whichPlayer.steps = diceRollValue;
        Debug.Log(whichPlayer.gameObject.name + " rolled a " + diceRollValue);

    }

    void InitializeGame()
    {
        // we swap these right now
        players[0].isTurn = false;
        players[1].isTurn = true;
        // and flip it back here, because it initializes things
        NextPlayerTurn();
        questionPanel.SetActive(false);
    }


    public void NextPlayerTurn()
    {
        players[0].isTurn = !players[0].isTurn;
        players[1].isTurn = !players[1].isTurn;

        // player's turn status on UI
        players[0].whosTurnImage.gameObject.SetActive(players[0].isTurn);
        players[1].whosTurnImage.gameObject.SetActive(players[1].isTurn);


    }
}
