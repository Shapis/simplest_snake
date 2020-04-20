using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPauseScreen : MonoBehaviour
{

    

     void ResumeGame()

    {

        
        

        if (GameHandler.isPaused)
        {

            GameHandler.Resume();

            GameObject.Find("CanvasPauseScreen").transform.Find("PauseMenu").gameObject.SetActive(false);

        }
        //else
        //{
        //    GameHandler.Resume();
        //    isPaused = false;
        //    Debug.Log("Clicked the pause button: resume!");
        //}



    }

    public void returnToMainMenu()

    {
        
        SceneHandler.Load(SceneHandler.Scene.MainMenu);
        GameHandler.Resume();



        

        //GameObject.Find("CanvasPauseScreen").transform.Find("GameOverMenu").gameObject.SetActive(false);






    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameHandler.isPaused) 
            {

                SceneHandler.Load(SceneHandler.Scene.MainMenu);
                GameHandler.Resume();
            } 
            else
            {
                GameHandler.Pause();
                GameObject.Find("CanvasPauseScreen").transform.Find("PauseMenu").gameObject.SetActive(true);
                
                


            }


        }

    }



}
