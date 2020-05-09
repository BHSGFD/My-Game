using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drager : MonoBehaviour
{
    #region declaration
    [SerializeField]
    private float speed;

    float count = 0;

    #endregion

    void FixedUpdate()
    {
        //rotate game object to create a not static effect
        if (SceneController._instance.Player == SceneController.player.playing)
        {
            transform.Rotate(new Vector3(0.1f * speed, 0, 0.01f * speed));
            count++;
            if (count >= 60) { count = 0; speed = speed * -1; }
        }
                
    }
 
    
}
