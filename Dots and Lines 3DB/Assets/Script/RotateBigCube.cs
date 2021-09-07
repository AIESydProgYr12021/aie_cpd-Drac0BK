using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    float speed = 200.0f;
    public GameObject escape;
    public GameObject win1;
    public GameObject win2;
    public GameObject turn;


    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rb;



    Vector3 previousMousePosition;
    Vector3 mouseDelta;

    public GameObject target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        dragging = true;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escape.SetActive(true);
            turn.SetActive(false);
        }
        bool win = win2.activeSelf != true | win1.activeSelf != true;
        if (escape.activeSelf != true || win != true)
        {
            Drag();
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
        if (Input.GetMouseButton(1))
        {
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.13f;
            transform.rotation= Quaternion.Euler(mouseDelta.y, -mouseDelta.x,0) * transform.rotation;
        }
        previousMousePosition = Input.mousePosition;
    }
}
