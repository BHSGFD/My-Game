using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonDrager : MonoBehaviour
{
    #region declaration
    private enum SizeVector {add, remove }

    SizeVector sizeVector = SizeVector.add;

    private RectTransform recttransform;

    private float x = 1;
    private float y = 1;
    private float min_x = 0.7f;
    private float max_x = 1f;


    [SerializeField]
    private float speed = 0;

    #endregion

    #region unity methods
    private void Start()
    {
        recttransform = gameObject.GetComponent<RectTransform>();

        
    }
    void FixedUpdate()
    {
       if (x < max_x && sizeVector == SizeVector.add)
        {

            x += 0.01f;
            y += 0.01f;
          
      }
       else sizeVector = SizeVector.remove;
  
       if (x > min_x && sizeVector == SizeVector.remove)
       {
            x -= 0.01f;
            y -= 0.01f;
        }
       else sizeVector = SizeVector.add;


       //change scale
        recttransform.localScale = new Vector2(x*speed, y*speed);
    }
    #endregion

}

