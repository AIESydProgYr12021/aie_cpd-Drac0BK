using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCheck : MonoBehaviour
{
    //line parent
    public GameObject LineHolder;

    //line colors
    public Material Blue;
    public Material Red;

    //face colors
    public Material BlueFace;
    public Material RedFace;
    
    //line base color
    private Material SeeThrough;

    //the lines that faces are connected to
    public GameObject TopLine;
    public GameObject BotLine;
    public GameObject LeftLine;
    public GameObject RightLine;

    //Line arrays
    GameObject[] lines = new GameObject[4];
    GameObject[] linesCom = new GameObject[4];

    //what lines are already entered
    int[] AlreadyHave = new int[4];

    //count of lines that are taken
    int linesCount = 0;

    void Start()
    {
        //sets the lines array to the corresponding lines
        lines[0] = TopLine;
        lines[1] = BotLine;
        lines[2] = LeftLine;
        lines[3] = RightLine;

        for (int i = 0; i < linesCom.Length; i++)
        {
            linesCom[i] = TopLine; //sets the lines com to the same line(perfectly fine in this code)
            AlreadyHave[i] = 5; //already have uses 0,1,2,3 anything higher works
        }
        SeeThrough = lines[0].GetComponent<MeshRenderer>().material; //sets seethrough to the lines material
    }

    void Update()
    {
        //checks through the lines
        for (int i = 0; i < lines.Length; i++)
        {
            //checks which lines are in the array already by using their number in lines
            bool hasnot = false;
            for(int j = 0; j  < AlreadyHave.Length; j++)
            {
                if(AlreadyHave[j] == i)
                {
                    hasnot = true;
                }
            }
            //gets the string name to check their material name (blue or red in it)
            string name = lines[i].GetComponent<MeshRenderer>().material.name;
            if (name.Contains(Blue.name) && hasnot == false || name.Contains(Red.name) && hasnot == false)
            {
                //if it does it is added to the alreadyhave with i count
                //another one on lines com
                // increment lines count
                AlreadyHave[linesCount] = i;
                linesCom[linesCount] = lines[i];
                linesCount++;
            }
        }
        //lines count is checked each update
        if(linesCount == 4)
        {
            // this occurs when all the lines that the face is connected to it are all taken
            if (linesCom[3].GetComponent<MeshRenderer>().material.name.Contains(Red.name))
            {
                GetComponent<MeshRenderer>().material = RedFace;
            }
            else if (linesCom[3].GetComponent<MeshRenderer>().material.name.Contains(Blue.name))
            {
                GetComponent<MeshRenderer>().material = BlueFace;
            }
            //with a face taken the player gets another turn 
            LineHolder.GetComponent<LineMaterialChange>().playerturn--;

            //lines count reset to make sure this code isn't called again on the face
            linesCount = 0;

        }

    }
}
