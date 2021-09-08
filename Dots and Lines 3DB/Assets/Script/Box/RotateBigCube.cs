using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RotateBigCube : MonoBehaviour
{
    public GameObject escape;
    public GameObject win1;
    public GameObject win2;
    public GameObject Draw;
    public GameObject turn;
    public GameObject Joystick;
    public GameObject Panel;


    Vector3 previousMousePosition;
    Vector3 mouseDelta;

    public GameObject target;


    void Start()
    {
       
    }


    void Update()
    {

        bool win = win2.activeSelf != true | win1.activeSelf != true;
        bool end = win | Draw.activeSelf != true;
        if (escape.activeSelf != true || end != true)
        {
            Drag();
        }
        if(end != true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                escape.SetActive(true);
                turn.SetActive(false);
            }
        }
    }


    public void MenuGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    void Drag()
    {
         foreach (Touch touch in Input.touches)
         {
            //if (Input.GetMouseButton(1))       
                if (touch.phase == TouchPhase.Moved)
                {
                mouseDelta = Input.mousePosition - previousMousePosition;
                mouseDelta *= 0.13f;
                transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
                }
         }
       // else
       // { 
       //    float x = Joystick.GetComponent<VJS>().Direction.x;
       //    float y = Joystick.GetComponent<VJS>().Direction.y;
       //    
       //    if (x < 0 && y < 0)//down
       //    {
       //        transform.rotation = Quaternion.Euler(0, 1f, 0) * transform.rotation;
       //    }
       //    else if (x > 0 && y > 0)//up
       //    {
       //        transform.rotation = Quaternion.Euler(0, -1f, 0) * transform.rotation;
       //    }      
       //     else if (x <= 0 && y >= 0)//left
       //     {
       //         transform.rotation = Quaternion.Euler(1f, 0, 0) * transform.rotation;
       //     }
       //     else if (x >= 0 && y <= 0)//right
       //     { 
       //     transform.rotation = Quaternion.Euler(-1f, 0, 0) * transform.rotation;
       //     }
       //    //transform.rotation = Quaternion.Euler(Joystick.GetComponent<VJS>().Direction.x, Joystick.GetComponent<VJS>().Direction.y, 0) * transform.rotation;
       //
       // }

        previousMousePosition = Input.mousePosition;
    }
}
