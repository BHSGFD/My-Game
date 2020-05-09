using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPointController : MonoBehaviour
{
    private Vector3 radius;
   
    void Start()
    {
       //subscribe
        UIController._instance.SwitchLeftButton += LeftSideSwap;
        UIController._instance.SwitchRightButton += RightSideSwap;
       
    }


    public void LeftSideSwap() {
        if (SceneController._instance.Player == SceneController.player.playing)
        {
            PlayerController.changeAngle();
            radius = transform.position - PlayerController._instance.returnTransform().position;
            transform.position = transform.position + -2 * radius;

            PlayerController.ChangeVector();
        }
    }

    public void RightSideSwap()
    {
        if (SceneController._instance.Player == SceneController.player.playing)
        {
            PlayerController.changeAngle();
            radius = transform.position - PlayerController._instance.returnTransform().position;
            transform.position = transform.position + -2 * radius;

            PlayerController.ChangeX();
        }
    }
}
