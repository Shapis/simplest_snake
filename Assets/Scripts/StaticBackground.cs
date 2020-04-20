using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBackground
{
    public void Spawn(Vector2 mySize, Vector2 myPosition,  Color myColor, string myBackgroundName)
    {




        GameObject myGameObject = new GameObject(myBackgroundName, typeof(SpriteRenderer));
        myGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.staticBackgroundSprite;
        myGameObject.transform.position = myPosition;
        myGameObject.transform.localScale = mySize;
        myGameObject.GetComponent<SpriteRenderer>().color = myColor;
        myGameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";



    }

    //public void Initialize(Vector2 mySize, Vector2 myPosition, Color myColor, StaticBackground myBackground)
    //{

        
    //    myBackground.Spawn(mySize, myPosition, myColor);

    //}
}
