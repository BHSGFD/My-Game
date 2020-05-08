using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonDrager : MonoBehaviour
{
    private enum SizeVector {add, remove }

    SizeVector sizeVector = SizeVector.add;

    private RectTransform recttransform;

    private float x = 1;
    private float y = 1;
    private float min_x = 0.7f;
    private float max_x = 1f;
    [SerializeField]
    private float speed;

    //  private float x= 700f;
    //  private float y = 140f;
    //

    //
    //  private Text text;

    private void Start()
    {
        recttransform = gameObject.GetComponent<RectTransform>();
   //     text = gameObject.GetComponentInChildren<Text>();
        
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
      //  recttransform.sizeDelta = new Vector2(900 * x, 170 * y);
        recttransform.localScale = new Vector2(x*speed, y*speed);
    }

  
}

