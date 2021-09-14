using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineMaterialChange : MonoBehaviour
{
    //empty line holder
    public GameObject lineHolder;
    //playerturn to change player 
    //set to 100 to avoid going negetive in game 
    public int playerturn = 100;
    int pt = 100;

    //Menu's
    public GameObject escape;
    public GameObject win1;
    public GameObject win2;

    int lineArrayLoc = 0;

    //Saves The Empty variables allowing the lines on the cube to be saved here
    GameObject[] LineArray = new GameObject[144];

    //Change Cube Face
    public Material red;
    public Material blue;
    float deltaTime = 0.0f;


    void Start()
    {
        //fill array with empty variable 
        for (int i = 0; i < LineArray.Length; i++)
        {
            LineArray[i] = lineHolder;
        }
        //makes sure pt = playerturn
        pt = playerturn;
    }


    void Update()
    {
        // makes sure that line can't be selected in menu
        bool win = win2.activeSelf != true | win1.activeSelf != true;
        if (escape.activeSelf != true || win != true)
        {
            if (pt - playerturn == 2) // makes sure that a players turn is accurate (when two faces are taken)
            {
                playerturn--;
            }

            ///This is for android controls
            ///the touch is checked on stationary and after 3 deltaTime it continues with the code
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Stationary)
                    deltaTime += Time.deltaTime;
                if (deltaTime > 3.0f)
                    if (Input.GetMouseButtonDown(0))
                    {
                        //sets pt to playerturn to not cause previous code to repeadetly occur
                        //using raycast to set the material of the lines
                        pt = playerturn;
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                        if (Physics.Raycast(ray, out hit))
                        {
                            //makes sure that click is connected to the lines by using a parent
                            string name = hit.transform.parent.name;
                            string objectname = hit.transform.name;
                            GameObject objectTransFrom = hit.transform.gameObject;

                            if (name == lineHolder.name)
                            {
                                bool isInArray = false;
                                for (int i = 0; i < LineArray.Length; i++)
                                {
                                    //checks the array for the line clicked on else it wont let it change
                                    if (LineArray[i].name == objectname && LineArray[i].gameObject == hit.transform.gameObject)
                                    {
                                        isInArray = true;
                                        break;
                                    }
                                }

                                if (isInArray == false)
                                {
                                    //adds line to the array 
                                    LineArray[lineArrayLoc] = hit.transform.gameObject;
                                    // goes to the next spot that is availbe in the array (only increments here)
                                    lineArrayLoc++;

                                    // checks whose turn it is and changes the line accordingly
                                    if (playerturn % 2 == 0)
                                    {
                                        hit.transform.GetComponent<MeshRenderer>().material = red;
                                    }
                                    else if (playerturn % 2 != 0)
                                    {
                                        hit.transform.GetComponent<MeshRenderer>().material = blue;
                                    }
                                    //to next players turn and pt again since playerturn has changed
                                    Debug.Log(playerturn);
                                    playerturn++;
                                    pt = playerturn;

                                }
                            }
                            //for android resets deltaTime
                            //deltaTime = 0.0f;
                        }
                    }
            }
            //}
        }
    }
}
