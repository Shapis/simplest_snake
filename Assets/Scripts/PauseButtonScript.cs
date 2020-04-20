using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseButtonScript : MonoBehaviour
{

    

    private void OnMouseUp()
    {
        if (!GameHandler.isPaused)
        {

            GameHandler.Pause();
            

            GameObject.Find("CanvasPauseScreen").transform.Find("PauseMenu").gameObject.SetActive(true);

            


        }
    }


    //void OnMouseUpAsButton()
    //{


        

    //    if (!GameHandler.isPaused)
    //    {
            
    //        GameHandler.Pause();
    //        Debug.Log("Clicked the pause button: pause! Game is pause: " + GameHandler.isPaused);
            
    //        GameObject.Find("CanvasPauseScreen").transform.Find("PauseMenu").gameObject.SetActive(true);


            
            
    //    }
    //    //else
    //    //{
    //    //    GameHandler.Resume();

    //    //    Debug.Log("Clicked the pause button: resume!");
    //    //}



    //}





}
