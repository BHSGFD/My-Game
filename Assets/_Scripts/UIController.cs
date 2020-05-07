using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void SwitchButtonHandler();

public class UIController : MonoBehaviour
{
    public event SwitchButtonHandler SwitchLeftButton;
    public event SwitchButtonHandler SwitchRightButton;
    [SerializeField]
    private GameObject player;
    public static UIController instance;

    public static UIController _instance => instance;
    
    private GameObject Image;
    private GameObject EndImage;
    [SerializeField]
    private Text text = null;
    [SerializeField]
    private Text score = null;
    private float count = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        instance = this;
        Debug.Log(instance);
        Image = GameObject.Find("Image");
        EndImage = GameObject.Find("end");
        EndImage.SetActive(false);
        
        
    }

    public void clickLeft()
    {
        if (PlayerController._instance != null)
        {
            SwitchLeftButton();
            disableFirstScreenHUD();
            SceneController._instance.Player = SceneController.player.playing;
           
        }
    }

    public void clickRight()
    {
        if (PlayerController._instance != null)
        {
            SwitchRightButton();
            disableFirstScreenHUD();
            SceneController._instance.Player = SceneController.player.playing;
        }
    }

    private void disableFirstScreenHUD(){
        Image.SetActive(false);

}

    public void EnableEndScreenHUD()
    {
        EndImage.SetActive(true);

    }


    public void addScore()
    {
        count++;
        text.text = count.ToString();
    }


    public void Changescore()
    {
        score.text = text.text;
    }


}
