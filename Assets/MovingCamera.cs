using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;

    void FixedUpdate()
    {
        if(SceneController._instance.Player == SceneController.player.playing)
        transform.position = new Vector3(transform.position.x - 0.01f * speed, transform.position.y, transform.position.z);  
    }
}
