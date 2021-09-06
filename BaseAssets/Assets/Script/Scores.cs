using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public int player1;
    public int player2;
    public Text p1;
    public Text p2;
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

        //foreach (Transform child in transform)
        //{
        //    if (child.GetComponent<MeshRenderer>().material.name.Contains("Red"))
        //    {
        //        player1++;
        //    }
        //
        //    else if (child.GetComponent<MeshRenderer>().material.name.Contains("Blue"))
        //    {
        //        player2++;
        //    }
        //}
    }
}
