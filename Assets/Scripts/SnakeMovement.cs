using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SnakeMovement
{

    private static Vector2 lastTailPosition = new Vector2Int();
    public static int snakeSize;
    

    public static void Move(SnakePart[] myOldSnake, Vector2 direction)
    {

        lastTailPosition = myOldSnake[myOldSnake.Length - 1].getPosition();

      

        for (int i = 0; i < myOldSnake.Length - 1; i++)
        {
            myOldSnake[myOldSnake.Length-1-i].setPosition(myOldSnake[myOldSnake.Length-2-i].getPosition());
            //Debug.Log(i);
        }

        myOldSnake[0].setPosition(myOldSnake[0].getPosition() + direction);

        snakeSize = myOldSnake.Length;


    }


     


    public static SnakePart[] Grow(SnakePart[] myOldSnake, Vector2 direction, Vector2 foodPosition, float myScale)
    {

        SnakePart[] myNewSnake = new SnakePart[myOldSnake.Length + 1];
        SnakePart newSnakePart = new SnakePart();
        newSnakePart.Spawn(lastTailPosition, myScale, Color.blue);
        myNewSnake[myNewSnake.Length - 1] = newSnakePart;



        for (int i = 0; i < myOldSnake.Length; i++)
        {
            myNewSnake[i] = myOldSnake[i];
            
        }



        snakeSize = myNewSnake.Length;
        return myNewSnake;

    }












}
