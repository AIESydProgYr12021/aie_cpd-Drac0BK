using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public Material red;
    public Material blue;

    public void ChangeLine(string playerturn)
    {
        if(playerturn == "red")
        GetComponent<MeshRenderer>().material = red;
        else if (playerturn == "blue")
            GetComponent<MeshRenderer>().material = blue;
    }

}
