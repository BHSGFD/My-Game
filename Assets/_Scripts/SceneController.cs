using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region declaration
    public enum player { waiting, playing, destroyed };

    public player Player;


    public static SceneController instance;

    public static SceneController _instance => instance;

    [SerializeField]
    private CosmicScriptableObjects[] objects = null;


    private float count = 0;

    #endregion



    #region unity methods
    private void OnEnable()

    {
        instance = this;
    }


    private void Start()
    {

        Player = player.waiting;

    }

    private void FixedUpdate()
    {
        //spawning enemies
        if (Player == player.playing)
        {
            if (objects != null && count >= 80)
            {
                int x = Random.Range(0, objects.Length);
                GameObject game = objects[x].gameObject;
                GameObject gameObject = Instantiate(game);
                gameObject.GetComponent<EnemyController>().speed = objects[x].speed;
                gameObject.transform.position = new Vector3(12, Random.Range(-4, 6), 0);


                count = 0;
            }
            else count++; ;
        }
        //open score screen
        if (Player == player.destroyed)
        {

            UIController._instance.EnableEndScreenHUD();
            UIController._instance.Changescore();

        }
    }

    #endregion


    public void startNewScene()
    {
        SceneManager.LoadScene(1);
    }




}

  


