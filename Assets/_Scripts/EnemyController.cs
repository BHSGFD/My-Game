using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region declaration
    [SerializeField]
    public float speed;
    #endregion

    #region unity methods

    void FixedUpdate()
    {
        //move enemy
        if (SceneController._instance.Player == SceneController.player.playing)
        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

        if (transform.position.x < -7.5f) Destroy(gameObject);

        if(SceneController._instance.Player == SceneController.player.destroyed) { Destroy(gameObject); }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy player
        DoOnEnter(collision);
    }

    #endregion

    public virtual void DoOnEnter(Collider2D collision)

    {
        PlayerController._instance.GetAnimator().SetBool("IsDead", true);
        SceneController._instance.Player = SceneController.player.waiting;
        StartCoroutine(wait(collision));
      
        
    }

    IEnumerator wait(Collider2D collision)
    {
       
        yield return new WaitForSeconds(2);
        Destroy(collision.gameObject);
       
    }

}
