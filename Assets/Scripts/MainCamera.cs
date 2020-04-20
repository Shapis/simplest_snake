using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Camera myMainCamera = new Camera(); // the new Camera() isnt needed but I was getting a warning in unity so who the heck knows man.
    


    // Start is called before the first frame update
    void Start()
    {

        //StaticBackground myMainBackground = GameObject.Find("mainStaticBackground").GetComponent<StaticBackground>();
        //myMainCamera.transform.position = new Vector3(0, 0, 0);
        //myMainCamera.orthographicSize = Mathf.Max(Screen.width,Screen.height);
        myMainCamera.orthographicSize = (Screen.height/2);
        myMainCamera.transform.position = new Vector3(0, ((Screen.height - GameObject.Find("MainStaticBackground").GetComponent<Transform>().localScale.y) / 2)-GameLogic.myScale, -1);
        //myMainCamera.transform.position = new Vector3(0, (Screen.height - GameObject.Find("mainStaticBackground").GetComponent<Transform>().localScale.y) / 2, -1);
        

    }

    private void Update()
    {

        //Debug.Log((Screen.height - GameObject.Find("mainStaticBackground").GetComponent<Transform>().localScale.y) / 2);
        //myMainCamera.transform.position = new Vector3(0, (Screen.height - GameObject.Find("mainStaticBackground").GetComponent<Transform>().localScale.y) / 2, -1);
    }


}
