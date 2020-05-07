using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region declation
   


    [SerializeField]
    float angle;
    [SerializeField]
    float speed;
    [SerializeField]
    private GameObject controllPoint = null;
    [SerializeField]
    private float radius = 0;

    private Animator anim;

    private static PlayerController instance;

    public static PlayerController _instance { get {  return instance;  } }

    float x = 0;
    float y = 0;
    
    
    private Vector3 moveOnRadius;
    private Rigidbody2D _rigidbody;

    public static float xmover = 1;
    private static float Speed;
    private static float Angle;
    

    #endregion

    #region Unity methods
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        _rigidbody = GetComponent<Rigidbody2D>();
        Speed = speed;
        Angle = angle;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rotatePlayer();
    }

    private void OnDestroy()
    {

        SceneController._instance.Player = SceneController.player.destroyed;
    }



    #endregion

    #region geometric calculations
    private float fromAngleToRad(float Angle) {
        float rad;
        rad = Angle * 0.174f;

        return rad;
    }

    private float addRad(float Angle)
    {
        return fromAngleToRad(Angle);
    }

    private float addRad()
    {
        return fromAngleToRad(1);
    }

    private void rotatePlayer()
    {
        
        if (controllPoint != null)
        {
            if (SceneController._instance.Player == SceneController.player.playing)
            {
                

                speed = Speed;
                angle = Angle;

                x = addRad(angle);
                y = addRad(angle * xmover);

                moveOnRadius = new Vector2(Mathf.Sin(x) + radius, Mathf.Cos(y) + radius) * Time.deltaTime * speed;
                _rigidbody.MovePosition(new Vector2(Mathf.Sin(x) * radius + controllPoint.transform.position.x, Mathf.Cos(y) * radius + controllPoint.transform.position.y));

                angle += addRad(speed);
                Angle = angle;
                if (transform.position.x < -7.5f) Destroy(gameObject);

            }
        }
        else return;
    }

   public static void ChangeVector()
   {
       Speed = Speed * -1;
       
   }

   public static void ChangeX()
   {
       xmover = xmover * -1;
  
   }

    public static void changeAngle()
    {
        Angle = Angle + 90;
        
    }
    #endregion

    #region return

    public Transform returnTransform()
    {
        return transform;
    }


    public Animator GetAnimator()
    {
        return anim;
    }
    #endregion

}

