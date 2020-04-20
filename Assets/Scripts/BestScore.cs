using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText = null;
    HighScores myHighScoresTable = new HighScores();

    // Start is called before the first frame update
    void Start()
    {

        myHighScoresTable = myHighScoresTable.Load();
        myHighScoresTable.AddHighScoreEntry(SnakeMovement.snakeSize - 4);
        myHighScoresTable.SortAndTrim(myHighScoresTable);
        
    }
    





    private void Update()
    {
        if ((SnakeMovement.snakeSize - 4) < myHighScoresTable.highScoreEntryList[0].score)
        {
            scoreText.text = (myHighScoresTable.highScoreEntryList[0].score).ToString();
        }else
        {
            scoreText.text = (SnakeMovement.snakeSize - 4).ToString();
        }



    }


}
