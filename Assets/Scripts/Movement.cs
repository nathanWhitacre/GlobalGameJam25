using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var movement = GetComponent<PlayerInput>().actions.FindAction("movement");
    }

    // Update is called once per frame
    void Update()
    {
        //movement
    }
}
