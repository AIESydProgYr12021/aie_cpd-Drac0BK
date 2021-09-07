using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineMaterialChange : MonoBehaviour
{
    public GameObject lineHolder;
    public int playerturn = 100;
    int pt = 100;
    public GameObject escape;
    public GameObject win1;
    public GameObject win2;
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
        pt = playerturn;
    }

    // Update is called once per frame
    void Update()
    {
        bool win = win2.activeSelf != true | win1.activeSelf != true;
        if (escape.activeSelf != true || win != true)//|| win2.activeSelf != true || win1.activeSelf != true)
        {
            if (pt - playerturn == 2)
            {
                playerturn--;
            }

            if (Input.GetMouseButtonDown(0))
            {
                pt = playerturn;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    string name = hit.transform.parent.name;
                    string objectname = hit.transform.name;
                    GameObject objectTransFrom = hit.transform.gameObject;
                    // if(playerturn % 2 == 0)
                    // {
                    //     Debug.Log("Player 1");
                    // }
                    // else
                    // {
                    //     Debug.Log("Player 2");
                    // }

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
                            Debug.Log(playerturn);
                            playerturn++;
                            pt = playerturn;

                        }
                    }
                }

            }
        }
    }
}
