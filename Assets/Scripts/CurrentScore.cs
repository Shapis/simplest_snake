using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;



    private void Start()
    {
        scoreText.text = (SnakeMovement.snakeSize - 4).ToString();
    }

    private void Update()
    {

        scoreText.text = (SnakeMovement.snakeSize -4).ToString();
    }

    



}
