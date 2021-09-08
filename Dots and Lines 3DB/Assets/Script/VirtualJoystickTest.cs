using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystickTest : MonoBehaviour
{
    [SerializeField] private VJS inputSource;
    private Rigidbody rigid;

    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        rigid.velocity = inputSource.Direction;
    }
}
