using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugConnector : MonoBehaviour
{
    public GameObject lugParent;
    public Transform BoxHold;
    public LineRenderer LineToSpawn;

    //int i = 0;
    //int j = 0;
    Vector3[] arrayList = new Vector3[2];
    string[] checkLug = new string[2];
    LineRenderer[] lineArray = new LineRenderer[144];
    GameObject[] CubeArray = new GameObject[144];
    public GameObject CubetoSpawn;
    void Start()
    {
    }


    void Update()
    {
       // if (Input.GetMouseButtonDown(0))
       // {
       //     RaycastHit hit;
       //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       //     
       //     if (Physics.Raycast(ray, out hit))
       //     {
       //         string name = hit.transform.parent.parent.name;
       //         string name2 = hit.transform.name;
       //         checkLug[i] = hit.transform.name;
       //         //Debug.Log("You selected the " + name2);
       //         //Debug.Log(i);
       //         if (name == lugParent.name)
       //         {
       //             arrayList[i] = hit.transform.position;
       //             i++;
       //             if(i == 2 && checkLug[0] != checkLug[1])
       //             {
       //                 if (arrayList[1].x < arrayList[0].x + 1 && arrayList[1].x > arrayList[0].x - 1 &&
       //                     arrayList[1].y < arrayList[0].y + 1 && arrayList[1].y > arrayList[0].y - 1 &&
       //                     arrayList[1].z < arrayList[0].z + 1 && arrayList[1].z > arrayList[0].z - 1)
       //                 {
       //
       //                     lineArray[j] = Instantiate(LineToSpawn);
       //                     lineArray[j].SetPosition(0, arrayList[0]);
       //                     lineArray[j].SetPosition(1, arrayList[1]);
       //                     lineArray[j].transform.SetParent(BoxHold);
       //                     //Vector3 rotate =new Vector3(90,0);
       //                     CubeArray[j] = Instantiate(CubetoSpawn);
       //                     Vector3 Between = arrayList[1] - arrayList[0];
       //                     float distance = Between.magnitude;
       //                     CubeArray[j].transform.position = arrayList[0] + (Between / 2);
       //                     CubeArray[j].transform.SetParent(BoxHold);
       //                     CubeArray[j].transform.LookAt(arrayList[0]);
       //                     //CubeArray[j].transform.rotation = Quaternion.Euler(0,90,0);
       //
       //
       //                     j++;
       //                 }
       //
       //                 i = 0;
       //             }
       //             if (i == 2) i = 0;
       //
       //             
       //         }
       //         
       //     }
       // }    
    }

}
