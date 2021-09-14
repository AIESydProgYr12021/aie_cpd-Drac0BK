using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    //Line parent
    public GameObject LineHolder;

    //Player Scores 
    public int player1;
    public int player2;

    //GUI
    public GameObject p1GameWin;
    public GameObject p2GameWin;
    public GameObject Draw;
    public GameObject escape;

    //Texts
    public Text p1;
    public Text p2;
    public Text turn; //turn counter
    
    //faces of the cube 54 total
    GameObject[] Faces = new GameObject[54];

    void Start()
    {
        //the faces parent holds the script and gets all the faces in the cube
        //and adds to the array

        int j = 0;
        foreach (Transform child in transform)
        {
            Faces[j] = child.gameObject;
            j++;
        }
    }

    void Update()
    {
        //this gets the ints for the players scores to be consistent
        int red = 0;
        int blue = 0;

        //goes through the faces in the array
        for (int i = 0; i < Faces.Length; i++)
        {
            //every face with the material that has red or blue adds to the respective int
            if (Faces[i].GetComponent<MeshRenderer>().material.name.Contains("Red"))
            {
                red++;
            }
            else if (Faces[i].GetComponent<MeshRenderer>().material.name.Contains("Blue"))
            {
                blue++;
            }
        }
        //sets the players scores and the ui corresponding to it
        player1 = red;
        player2 = blue;
        p1.text = player1.ToString();
        p2.text = player2.ToString();
        //the ui corresponding to whose players turn it is
        int check = LineHolder.GetComponent<LineMaterialChange>().playerturn;
        if (check % 2 == 0)
        {
            turn.text = "Player 1's turn";
        }
        if (check % 2 != 0)
        {
            turn.text = "Player 2's turn";
        }

        //Game end conditions
        //(player 1 win)
        if(player1 == 28)
        {
            p1GameWin.SetActive(true);
            escape.SetActive(false);
        }
        //(player 2 win)
        if (player2 == 28)
        {
            p2GameWin.SetActive(true);
            escape.SetActive(false);
        }
        //(players draw)
        if (player2 == 27 && player1 == 27)
        {
            Draw.SetActive(true);
            escape.SetActive(false);
        }
    }
}
