using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCheck : MonoBehaviour
{

    public GameObject LineHolder;

    public Material Blue;
    public Material Red;
    public Material BlueFace;
    public Material RedFace;
    private Material SeeThrough;
    public GameObject TopLine;
    public GameObject BotLine;
    public GameObject LeftLine;
    public GameObject RightLine;
    GameObject[] lines = new GameObject[4];
    GameObject[] linesCom = new GameObject[4];
    int[] AlreadyHave = new int[4];
    int linesCount = 0;

    // Start is called before the first frame update
    void Start()
    {

        lines[0] = TopLine;
        lines[1] = BotLine;
        lines[2] = LeftLine;
        lines[3] = RightLine;
        for (int i = 0; i < linesCom.Length; i++)
        {
            linesCom[i] = TopLine;
            AlreadyHave[i] = 5;
        }
        SeeThrough = lines[0].GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < lines.Length; i++)
        {
            bool hasnot = false;
            for(int j = 0; j  < AlreadyHave.Length; j++)
            {
                if(AlreadyHave[j] == i)
                {
                    hasnot = true;
                }
            }

            string name = lines[i].GetComponent<MeshRenderer>().material.name;
            if (name.Contains(Blue.name) && hasnot == false || name.Contains(Red.name) && hasnot == false)
            {
                AlreadyHave[linesCount] = i;
                linesCom[linesCount] = lines[i];
                linesCount++;
            }
        }
        if(linesCount == 4)
        {
            if (linesCom[3].GetComponent<MeshRenderer>().material.name.Contains(Red.name))
            {
                GetComponent<MeshRenderer>().material = RedFace;
            }
            else if (linesCom[3].GetComponent<MeshRenderer>().material.name.Contains(Blue.name))
            {
                GetComponent<MeshRenderer>().material = BlueFace;
            }
            LineHolder.GetComponent<LineMaterialChange>().playerturn--;
            linesCount = 0;

        }

    }
}
