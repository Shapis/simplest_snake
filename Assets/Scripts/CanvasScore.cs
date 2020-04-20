using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasScore : MonoBehaviour
{

    [SerializeField] Canvas myCanvas = new Canvas(); // the "new Canvas()" isnt needed but I was getting a warning in unity when I did this exact same thing in the MainCamera class, so i did a new here too for uniformity.
    //[SerializeField] Canvas myCurrentScoreCanvas = new Canvas();


    // Start is called before the first frame update
    void Start()
    {

        GameObject scoreBoardBackground = GameObject.Find("ScoreBackground");

        ////myCurrentScoreCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(Screen.width, Screen.height);


        

        myCanvas.transform.position = scoreBoardBackground.GetComponent<Transform>().transform.position;

        myCanvas.transform.GetChild(0).GetComponent<Transform>().localPosition = new Vector3((scoreBoardBackground.GetComponent<Transform>().localScale.x/2)- scoreBoardBackground.GetComponent<Transform>().localScale.x/8, 0,0);

        myCanvas.transform.GetChild(1).GetComponent<Transform>().localPosition = new Vector3(-(scoreBoardBackground.GetComponent<Transform>().localScale.x / 2) + scoreBoardBackground.GetComponent<Transform>().localScale.x / 9, 0, 0);


       


        // Make the textmesh scale with resolution, using 1080p as base.

        myCanvas.transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(Screen.width / 1080f,Screen.width / 1080f, Screen.width / 1080f);

        myCanvas.transform.GetChild(1).GetComponent<Transform>().localScale = new Vector3(Screen.width / 1080f, Screen.width / 1080f, Screen.width / 1080f);








        //myCurrentScoreCanvas.transform.GetChild(0).GetComponent<Transform>().localPosition = new Vector3((scoreBoardBackground.GetComponent<Transform>().localScale.x / 2) - scoreBoardBackground.GetComponent<Transform>().localScale.x/20, 0, 0);

        //myCurrentScoreCanvas.transform.localScale = new Vector3(3,3,3);



        //Debug.Log("Canvas local scale: " + myCurrentScoreCanvas);
        //Debug.Log("Text local scale: " + myCurrentScoreCanvas.transform.GetChild(0).GetComponent<Transform>().localScale);











        //myCurrentScoreCanvas.transform.GetChild(0).GetComponent<Transform>().localPosition = scoreBoardBackground.GetComponent<Transform>().position;
        //myCurrentScoreCanvas.transform.GetChild(0).GetComponent<Transform>().localPosition += new Vector3(0, cameraDislocation, 0);

        //Debug.Log(myCurrentScoreCanvas.transform.GetChild(0).GetComponent<Transform>().position);





    }


}
