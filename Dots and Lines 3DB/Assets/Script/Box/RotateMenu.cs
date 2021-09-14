using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenu : MonoBehaviour
{
    // this operates the cube in the same way in the game
    // however it rotates autmatically
    float speed = 25.0f;

    public GameObject target;

    void Start()
    {
        
    }


    void Update()
    {
        //set rotation to the code
        if (transform.rotation != target.transform.rotation)
        {
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
        }
        //constant rotation
        if (transform.rotation == target.transform.rotation)
        {
            target.transform.Rotate(0, 10, 0, Space.World);
        }
        
    }
}
