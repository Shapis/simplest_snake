using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasHighScoreMenu : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    
    private List<Transform> highScoreEntryTransformList;


    private void Awake()
    {
        entryContainer = GameObject.Find("HighScoreEntryContainer").transform;
        entryTemplate = GameObject.Find("HighScoreEntryTemplate").transform;

        entryTemplate.gameObject.SetActive(false);

        //PlayerPrefs.DeleteAll();
        //AddHighScoreEntry(59);

        //HighScores myAddHighScore = new HighScores();
        //myAddHighScore.AddHighScoreEntry(150);


        

        // Load Highscores from PlayerPrefs and add it to an object of type HighScores, if theres nothing in playerprefs, it creates an empty hghscores table of size 9 then sorts it and trims the elements outside the top9.
        HighScores myHighScoresTable = new HighScores();

        //myHighScoresTable.AddHighScoreEntry(220);
        myHighScoresTable = myHighScoresTable.Load();
        myHighScoresTable.SortAndTrim(myHighScoresTable);


        

        









        highScoreEntryTransformList = new List<Transform>();

        foreach (HighScores.HighScoreEntry highScoreEntry in myHighScoresTable.highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }





        //PlayerPrefs.DeleteAll();


    }


    private void CreateHighScoreEntryTransform(HighScores.HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {

            float templateHeight = 200f;
       
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);


            

            string rankString;

            int rank = transformList.Count + 1;

            switch (rank)
            {
                default: rankString = rank + "TH"; break;

                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;

            }

            entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().text = rankString;

            int score = highScoreEntry.score;
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        transformList.Add(entryTransform);

    }






    private void AddHighScoreEntry(int score)
    {


        // create HighScoreEntry
        HighScores.HighScoreEntry highScoreEntry = new HighScores.HighScoreEntry { score = score };


        // Load saved HighScores
        HighScores highScores = SaveHandler<HighScores>.Load(SaveHandler<HighScores>.SaveFileName.highScoreTable);






        // Add new entry to HighScores
        highScores.highScoreEntryList.Add(highScoreEntry);
        


            // Save updated highscores

            SaveHandler<HighScores>.Save(highScores, SaveHandler<HighScores>.SaveFileName.highScoreTable);
            //string json = JsonUtility.ToJson(highScores);
            //PlayerPrefs.SetString("highScoreTable", json);
            //PlayerPrefs.Save();
        

    }

    //[System.Serializable]
    //private class HighScoreEntry
    //{
    //    public int score;
        

    //}




    public void LoadMainMenu()
    {
        SceneHandler.Load(SceneHandler.Scene.MainMenu);
        Debug.Log("Return Button clicked. Loading main menu!");  
    }

    



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           

                SceneHandler.Load(SceneHandler.Scene.MainMenu);
               
           


        }

    }










}
