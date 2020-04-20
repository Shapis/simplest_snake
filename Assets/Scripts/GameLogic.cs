using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{



    private Vector2 snakeDirection = new Vector2();
    private Vector2 lastSnakeDirection = new Vector2();

    private Food myFood = new Food();
    private SnakePart[] mySnakePartArray = new SnakePart[4];


    private float mainBackgroundWidth;
    private float mainBackgroundHeight;
    public static float myScale;
    [SerializeField] private float heightPercentage = 0.8f;
    private float nextTime = 0f;
    [SerializeField] private float interval = 0.05f; // time between updates in seconds.







    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("GameLogic Start Method running.");
        GameHandler.Resume();
        initializeGame();

    }

    // Update is called once per frame
    void Update()
    {



        if (!GameHandler.isPaused)
        {
            HandleInput();
            HandleMovement();
            HandleCollision();
        }







    }

    private void HandleInput()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) || SwipeInput.swipedUp == true)
        {
            if (lastSnakeDirection.y != -myScale)
            {
                snakeDirection.x = 0;
                snakeDirection.y = myScale;
                



            }
        }
        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) || SwipeInput.swipedLeft == true)
        {
            if (lastSnakeDirection.x != myScale)
            {
                snakeDirection.x = -myScale;
                snakeDirection.y = 0;
            }
        }
        else if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) || SwipeInput.swipedDown == true)
        {
            if (lastSnakeDirection.y != myScale)
            {
                snakeDirection.x = 0;
                snakeDirection.y = -myScale;

            }
        }
        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) || SwipeInput.swipedRight == true)
        {
            if (lastSnakeDirection.x != -myScale)
            {
                snakeDirection.x = myScale;
                snakeDirection.y = 0;

            }
        }
    }

    private void HandleMovement()
    {
        if (Time.timeSinceLevelLoad >= nextTime)
        {

            lastSnakeDirection = snakeDirection;
            SnakeMovement.Move(mySnakePartArray, snakeDirection);



            //Debug.Log("MySnakeDirection:" + snakeDirection/2);




            nextTime += interval;

        }

    }




    private void HandleCollision()
    {

        //Debug.Log("MySnakePosition:" + mySnakePartArray[0].getPosition());
        //Debug.Log("My Food Position:" + myFood.getPosition());



        if (Mathf.Abs(mySnakePartArray[0].getPosition().x - myFood.getPosition().x) < 0.01 && Mathf.Abs(mySnakePartArray[0].getPosition().y - myFood.getPosition().y) < 0.1)
        {


            myFood.Destroy();
            mySnakePartArray = SnakeMovement.Grow(mySnakePartArray, snakeDirection, myFood.getPosition(), myScale);


            myFood.SpawnRandomSpot(mainBackgroundWidth, mainBackgroundHeight, myScale, mySnakePartArray);
            FindObjectOfType<AudioHandler>().Play(AudioHandler.SoundName.SnakeAte);
            Debug.Log("Snek ate food!");

        }

        for (int i = 0; i < mySnakePartArray.Length - 1; i++) // handles collision between snake itself
        {




            if (Mathf.Abs(mySnakePartArray[0].getPosition().x - mySnakePartArray[i + 1].getPosition().x) < 0.1 && Mathf.Abs(mySnakePartArray[0].getPosition().y - mySnakePartArray[i + 1].getPosition().y) < 0.1)
            {
                
                Debug.Log("snek collided with itself!");
                GameOver();

            }


        }
        if (mySnakePartArray[0].getPosition().x > mainBackgroundWidth / 2 || mySnakePartArray[0].getPosition().x < -mainBackgroundWidth / 2 || mySnakePartArray[0].getPosition().y > mainBackgroundHeight / 2 || mySnakePartArray[0].getPosition().y < -mainBackgroundHeight / 2)
        // handles whether the snake is within bounds.
        {


            Debug.Log("snek out of bounds! it's on the loose!");
            GameOver();

        }



    }


    private void initializeGame()
    {

        myScale = Screen.width / SettingsHandler.horizontalRows;
        mainBackgroundWidth = Screen.width - myScale * 2;





        // Initializing main background height as a % of the screen height.
        for (int i = 0; mainBackgroundHeight < (heightPercentage * Screen.height); i++)
        {
            mainBackgroundHeight = myScale * i;
        }

        mainBackgroundHeight -= myScale * 2;



        //Debug.Log("Width: " + mainBackgroundWidth + " Height: " + mainBackgroundHeight);



        // Initializing backgrounds.

        StaticBackground myStaticBackground = new StaticBackground();
        myStaticBackground.Spawn(new Vector2(mainBackgroundWidth, mainBackgroundHeight), new Vector2(0, 0), Color.black, "MainStaticBackground");

        //StaticBackground myScoreBackground = new StaticBackground();
        //myStaticBackground.Spawn(new Vector2((float)(Screen.width * scoreBoardWidthFactor)-myScale, Screen.height - mainBackgroundHeight -myScale), new Vector2((float)(((-Screen.width * (1 - scoreBoardWidthFactor)) /2) - (myScale / 2)), ((Screen.height-mainBackgroundHeight)/2)+(mainBackgroundHeight/2)+(myScale/2)), Color.black, "ScoreBackground");

        //StaticBackground myPauseBackground = new StaticBackground();
        //myStaticBackground.Spawn(new Vector2(Screen.height - mainBackgroundHeight - myScale, Screen.height - mainBackgroundHeight - myScale), new Vector2((float)(Screen.width * scoreBoardWidthFactor) / 2, ((Screen.height - mainBackgroundHeight) / 2) + (mainBackgroundHeight / 2) + (myScale / 2)), Color.yellow, "PauseBackground");


        StaticBackground myScoreBackground = new StaticBackground();
        myStaticBackground.Spawn(new Vector2(Screen.width - (Screen.height - mainBackgroundHeight), Screen.height - mainBackgroundHeight - myScale * 3), new Vector2(((Screen.width - (Screen.height - mainBackgroundHeight)) / 2) - (Screen.width / 2) + myScale, ((Screen.height - mainBackgroundHeight) / 2) + (mainBackgroundHeight / 2) + (myScale / 2) - myScale), Color.black, "ScoreBackground");




        StaticBackground myPauseBackground = new StaticBackground();
        myStaticBackground.Spawn(new Vector2(Screen.height - mainBackgroundHeight - myScale * 3, Screen.height - mainBackgroundHeight - myScale * 3), new Vector2((float)(((Screen.width) / 2) - (Screen.height - mainBackgroundHeight - myScale) / 2), ((Screen.height - mainBackgroundHeight) / 2) + (mainBackgroundHeight / 2) + (myScale / 2) - myScale), Color.black, "PauseBackground");

        GameObject.Find("PauseBackground").AddComponent<PauseButtonScript>();
        GameObject.Find("PauseBackground").AddComponent<BoxCollider2D>();





        // initializing my snake array position
        for (int i = 0; i < mySnakePartArray.Length; i++)
        {
            SnakePart tempSnakePart = new SnakePart();
            Vector2 tempVector = new Vector2(((-mainBackgroundWidth / 2) + myScale / 2) - (i * myScale) + 4 * myScale, (-mainBackgroundHeight / 2) + (myScale / 2) + 2 * myScale);

            if (i == 0)
            {
                tempSnakePart.Spawn(tempVector, myScale, Color.cyan);
            }
            else
            {
                tempSnakePart.Spawn(tempVector, myScale, Color.blue);
            }



            mySnakePartArray[i] = tempSnakePart;
            //Debug.Log("MySnakePosition:" + mySnakePartArray[i].getPosition());

        }


        snakeDirection.x = myScale;
        snakeDirection.y = 0;

        // Initializing food position.
        myFood.SpawnRandomSpot(mainBackgroundWidth, mainBackgroundHeight, myScale, mySnakePartArray);


    }

    private void GameOver()
    {


        Debug.Log("Game Over");
        FindObjectOfType<AudioHandler>().Play(AudioHandler.SoundName.SnakeDeath);
        //HighScores myAddHighScore = new HighScores();
        //myAddHighScore.AddHighScoreEntry(SnakeMovement.snakeSize - 4);
        GameHandler.Pause();
        GameObject.Find("CanvasPauseScreen").transform.Find("GameOverMenu").gameObject.SetActive(true);
        //Restart();
        //PlayerPrefs.DeleteAll();

    }

    private void Restart()
    {



        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }



}

