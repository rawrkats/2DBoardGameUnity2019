using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{

    public GameController gameController;
    public GameObject incorrectText, correctText;

    void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    // triggered from Answer button
    public void CorrectAnswer()
    {
        incorrectText.SetActive(false); // hide UIText
        correctText.SetActive(true);// hide UIText

        // find player that is currently answering a question
        for (int i = 0; i < gameController.players.Length; i++)
        {
            // bingo
            if (gameController.players[i].isAnsweringQuestion == true)
            {
                // this is where the Score is set if correctly answered
                gameController.players[i].Score += 1;
                // mark this question as read for the player, they will not encounter it again
                gameController.players[i].AnswerQuestion(this);
                // there is only one, so stop when you find it.
                break;
            }
        }
        // hide this question UI gameobject
        this.gameObject.SetActive(false);

    }
    // triggered from Answer button

    public void IncorrectAnswer()
    {
        incorrectText.SetActive(true);
        correctText.SetActive(false);

        for (int i = 0; i < gameController.players.Length; i++)
        {
            if (gameController.players[i].isAnsweringQuestion)
            {
                // this is where the Score is set if correctly answered
                gameController.players[i].Score -= 1;
                // mark this question as read for the player, they will not encounter it again
                gameController.players[i].AnswerQuestion(this);
                break;
            }
        }
        this.gameObject.SetActive(false);

    }
}
