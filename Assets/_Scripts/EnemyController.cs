using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (SceneController._instance.Player == SceneController.player.playing)
        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

        if (transform.position.x < -7.5f) Destroy(gameObject);

        if(SceneController._instance.Player == SceneController.player.destroyed) { Destroy(gameObject); }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoOnEnter(collision);
    }

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
