using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePrefab : MonoBehaviour
{
    public LineRenderer line;
    public Vector3 ps1;
    public Vector3 ps2;


    // Start is called before the first frame update
    public void Start()
    {
       line.positionCount = 2;
    }

    // Update is called once per frame
    public void spawnLine(Vector3 pos1, Vector3 pos2)
    {
        Instantiate(line);
        line.SetPosition(0, pos1);
        line.SetPosition(1, pos2);
       
    }
}
