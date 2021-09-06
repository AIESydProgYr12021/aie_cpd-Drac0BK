using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    float speed = 200.0f;

    Vector3 previousMousePosition;
    Vector3 mouseDelta;

    public GameObject target;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        Swipe();
        Drag();
    }

    void Drag()
    {
        if (Input.GetMouseButton(1))
        {
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.13f;
            transform.rotation= Quaternion.Euler(mouseDelta.y, -mouseDelta.x,0) * transform.rotation;
        }
        else
        {
            if (transform.rotation != target.transform.rotation)
            {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        previousMousePosition = Input.mousePosition;
    }


    void Swipe()
    {
            if (Input.GetMouseButtonDown(1))
            {
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                print(firstPressPos);
            }


            if (Input.GetMouseButtonUp(1))
            {


                secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                print(secondPressPos);

                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                currentSwipe.Normalize();

                // Left and Right
                if (LeftSwipe(currentSwipe))
                {
                    target.transform.Rotate(0, 45, 0, Space.World);
                }
                else if (RightSwipe(currentSwipe))
                {
                    target.transform.Rotate(0, -45, 0, Space.World);
                }

                //Up
                else if (UpLeftSwipe(currentSwipe))
                {
                    target.transform.Rotate(45, 0, 0, Space.World);
                }
                else if (UpRightSwipe(currentSwipe))
                {
                    target.transform.Rotate(0, 0, -45, Space.World);
                }

                //Down
                else if (DownLeftSwipe(currentSwipe))
                {
                    target.transform.Rotate(0, 0, 45, Space.World);
                }
                else if (DownRightSwipe(currentSwipe))
                {
                    target.transform.Rotate(-45, 0, 0, Space.World);
                }
            }
        
    }

    bool LeftSwipe(Vector2 swipe)
    {
        return swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe) 
    {
       return swipe.x > 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector2 swipe)
    {
        return swipe.y > 0 && swipe.x < 0;
    }

    bool UpRightSwipe(Vector2 swipe)
    {
        return swipe.y > 0 && swipe.x > 0;
    }
    bool DownLeftSwipe(Vector2 swipe)
    {
        return swipe.y < 0 && swipe.x < 0;
    }

    bool DownRightSwipe(Vector2 swipe)
    {
        return swipe.y < 0 && swipe.x > 0;
    }
}
