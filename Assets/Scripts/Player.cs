using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

///<summary> 
///The bulk of this script was derived from https://www.youtube.com/watch?v=d1oSQdydJsM
///</summary>

public class Player : MonoBehaviour
{
    GameController gameController;
    public TextMeshProUGUI scoreText;
    public Route currentRoute;
    public int routePosition;

    public List<Question> answeredQuestions = new List<Question>();

    float yOffset;
    public int steps;

    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; scoreText.text = value.ToString(); }
    }
    float speed = 6f;
    public bool isMoving, isTurn, isAnsweringQuestion;
    public Image whosTurnImage;


    void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        // sets player to starting block
        transform.position = currentRoute.childNodeList[0].position;
    }

    void Update()
    {
        // if you meet all this conditions, then you can proceed
        if (isTurn && !isMoving && steps > 0)
        {
            StartCoroutine(Move());
        }
    }

    // this is a Coroutine!
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while (MoveToNextNode(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
            steps--;
        }

        if (routePosition > 0 && steps == 0)
        {
            if (!isAnsweringQuestion)
            {
                // sets the next player's turn
                gameController.NextPlayerTurn();
            }
        }
        isMoving = false;
    }

    bool MoveToNextNode(Vector3 targetPos)
    {
        return targetPos != (transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed));
    }

    public void AskQuestion(Question question)
    {
        // shows the main question panel group
        gameController.questionPanel.SetActive(true);
        // shows the invividual question
        question.gameObject.SetActive(true);
        // sets player to answeringQuestion mode
        this.isAnsweringQuestion = true;
    }

    public void AnswerQuestion(Question _question)
    {
        answeredQuestions.Add(_question);
        this.isAnsweringQuestion = false;

    }

}
