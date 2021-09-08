using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public GameObject LineHolder;

    public int player1;
    public int player2;
    public GameObject p1GameWin;
    public GameObject p2GameWin;
    public GameObject Draw;
    public GameObject escape;
    public Text p1;
    public Text p2;
    public Text turn;
    GameObject[] Faces = new GameObject[54];

    // Start is called before the first frame update
    void Start()
    {
        int j = 0;
        foreach (Transform child in transform)
        {
            Faces[j] = child.gameObject;
            j++;
        }

        Debug.Log(j);
    }

    // Update is called once per frame
    void Update()
    {
        int red = 0;
        int blue = 0;

        for (int i = 0; i < Faces.Length; i++)
        {

            if (Faces[i].GetComponent<MeshRenderer>().material.name.Contains("Red"))
            {
                red++;
            }
            else if (Faces[i].GetComponent<MeshRenderer>().material.name.Contains("Blue"))
            {
                blue++;
            }
        }
        
        player1 = red;
        player2 = blue;
        p1.text = player1.ToString();
        p2.text = player2.ToString();
        int check = LineHolder.GetComponent<LineMaterialChange>().playerturn;
        if (check % 2 == 0)
        {
            turn.text = "Player 1's turn";
        }
        if (check % 2 != 0)
        {
            turn.text = "Player 2's turn";
        }
        if(player1 == 28)
        {
            p1GameWin.SetActive(true);
            escape.SetActive(false);
        }
        if (player2 == 28)
        {
            p2GameWin.SetActive(true);
            escape.SetActive(false);
        }
        if (player2 == 27 && player1 == 27)
        {
            Draw.SetActive(true);
            escape.SetActive(false);
        }
    }
}
