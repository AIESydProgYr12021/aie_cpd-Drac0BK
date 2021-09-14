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
        //check the menus that are open
        // stopping rotation when they are open
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
        // Rotating the cube
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
        
        previousMousePosition = Input.mousePosition;
    }
}
