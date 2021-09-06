using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineMaterialChange : MonoBehaviour
{
    LineController materialLine;
    public GameObject lineHolder;
    public int playerturn = 0;
    public bool isPlayer1Turn = true;
    int lineArrayLoc = 0;
    GameObject[] LineArray = new GameObject[144];
    public Material red;
    public Material blue;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LineArray.Length; i++)
        {
            LineArray[i] = lineHolder;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                string name = hit.transform.parent.name;
                string objectname = hit.transform.name;
                GameObject objectTransFrom = hit.transform.gameObject;
                if(playerturn % 2 == 0)
                {
                    Debug.Log("Player 1");
                }
                else
                {
                    Debug.Log("Player 2");
                }
                
                if (name == lineHolder.name)
                {
                    bool isInArray = false;
                    for (int i = 0; i < LineArray.Length; i++)
                    {
                        if (LineArray[i].name == objectname && LineArray[i].gameObject == hit.transform.gameObject)
                        {
                            isInArray = true;
                            break;
                        }
                    }

                    if (isInArray == false)
                    {
                        LineArray[lineArrayLoc] = hit.transform.gameObject;

                        //if (isPlayer1Turn == true)
                        //{
                        //    hit.transform.GetComponent<MeshRenderer>().material = red;
                        //    isPlayer1Turn = false;
                        //}
                        //else if (isPlayer1Turn == false)
                        //{
                        //    hit.transform.GetComponent<MeshRenderer>().material = blue;
                        //    isPlayer1Turn = true;
                        //}
                        lineArrayLoc++;

                        if (playerturn % 2 == 0)
                        {
                            hit.transform.GetComponent<MeshRenderer>().material = red;
                        }
                        else if (playerturn % 2 != 0)
                        {
                            hit.transform.GetComponent<MeshRenderer>().material = blue;
                        }  
                        playerturn++;


                    }
                    

                }
            }
        }
    }
}
