using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart 
{
    private GameObject myGameObject;


    public void Spawn(Vector2 myPosition, float myScale, Color myColor)
    {

        

        myGameObject = new GameObject("SnakePart", typeof(SpriteRenderer));
        myGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.SnakePart;
        myGameObject.transform.position = myPosition;
        myGameObject.transform.localScale = new Vector3(myScale, myScale);
        myGameObject.GetComponent<SpriteRenderer>().color = myColor;
        myGameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Over";




    }



    public void setPosition(Vector2 myVector)
    {

        Vector3 temp = new Vector3(myVector.x, myVector.y, 0);
        myGameObject.transform.position = temp;



    }


    public Vector2 getPosition()
    {
        Vector2 temp = new Vector2();

        temp.x = myGameObject.transform.position.x;
        temp.y = myGameObject.transform.position.y;
        return temp;
    }

    public SnakePart[] Move(SnakePart[] myOldSnake, Vector2 direction)
    {

        SnakePart[] myNewSnake = new SnakePart[myOldSnake.Length];
       

        myNewSnake[0].setPosition(myOldSnake[0].getPosition() + direction);

        for (int i = 0; i < myNewSnake.Length - 1; i++)
        {
            myNewSnake[i + 1] = myOldSnake[i];
        }



        return myNewSnake;
    }


    public void Grow(Vector2[] myOldSnake, Vector2 fruitPosition)
    {
        Vector2[] myNewSnake = new Vector2[500];

        myNewSnake[0] = fruitPosition;
        for (int i = 0; i < myOldSnake.Length - 1; i++)
        {
            myNewSnake[0 + i] = myOldSnake[i];
        }





        
    }


    public void Destroy()
    {
        Object.Destroy(myGameObject);
        

    }

    public SnakePart[] Initialize(SnakePart[] myOldSnake)
    {

        SnakePart[] myNewSnake = new SnakePart[myOldSnake.Length + 3];
       

       
        

        return myNewSnake;
    }
}
