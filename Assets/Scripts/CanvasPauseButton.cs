using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPauseButton : MonoBehaviour
{
    [SerializeField] Canvas myCanvas = new Canvas(); // the "new Canvas()" isnt needed but I was getting a warning in unity when I did this exact same thing in the MainCamera class, so i did a new here too for uniformity.



    private void Start()
    {
        GameObject pauseBackground = GameObject.Find("PauseBackground");

        myCanvas.transform.position = pauseBackground.GetComponent<Transform>().transform.position;

        myCanvas.transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(Screen.width / 1080f, Screen.width / 1080f, Screen.width / 1080f);

    }







}
