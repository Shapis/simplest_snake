using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food
{
    

    private GameObject myGameObject;


    public void SpawnRandomSpot(float width, float height, float myScale, SnakePart[] mySnakePartArray)
    {

        bool safePositionCheck = true;
        
           Vector2 randomPosition = new Vector2(((int)Random.Range(0, (width / myScale))) * myScale -(width/2) +myScale/2, ((int)Random.Range(0, (height / myScale))) * myScale - (height/2) + myScale / 2);



        



        while (safePositionCheck == true)
        {
            safePositionCheck = false;
            for (int i = 0; i < mySnakePartArray.Length; i++)
            {
                if (Mathf.Abs(randomPosition.x - mySnakePartArray[i].getPosition().x) < 0.1 && Mathf.Abs(randomPosition.y - mySnakePartArray[i].getPosition().y) < 0.1)
                {
                    randomPosition = new Vector2(((int)Random.Range(0, (width / myScale))) * myScale - (width / 2) + myScale / 2, ((int)Random.Range(0, (height / myScale))) * myScale - (height / 2) + myScale / 2);
                    safePositionCheck = true;
                }
            }
        }






        myGameObject = new GameObject("Food", typeof(SpriteRenderer));
            myGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.foodSprite;
            myGameObject.transform.position = randomPosition;
            myGameObject.transform.localScale = new Vector3(myScale, myScale);
            myGameObject.GetComponent<SpriteRenderer>().color = Color.red;
            myGameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Over";
        



    }

    public void Initialize(Food tempFood)
    {
    }

    public Vector2 getPosition()
    {
        Vector2 temp = new Vector2();

        temp.x = myGameObject.transform.position.x;
        temp.y = myGameObject.transform.position.y;
        return temp;
    }

    public void Destroy()
    {
        Object.Destroy(myGameObject);
        

    }
}

