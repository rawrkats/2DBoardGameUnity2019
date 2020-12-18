using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    GameController gameController;
    float timeOnNode = 0f;
    public bool hasQuestion;
    public Question question;


    void Start()
    {
        // i get tired of dragging things into the inspector too
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    // we use Stay instead of Enter to register the question trigger
    void OnTriggerStay2D(Collider2D other)
    {
        // defining a reference once at the start makes the code more efficient and easier to read/edit
        Player player = other.gameObject.GetComponent<Player>();

        // only allow player to stop and answer question if this waypoint has one
        if (hasQuestion && question != null)
        {
            // if this is the player's last stop on this round, and they haven't answered this question already
            if (player.steps == 0 && !player.answeredQuestions.Contains(question))
            {
                // obviously
                player.AskQuestion(question);
            }
        }
    }



}
