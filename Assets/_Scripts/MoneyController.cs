using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : EnemyController
{

    public override void DoOnEnter(Collider2D collision)
    {
        Destroy(gameObject);
        UIController.instance.addScore();
    }
}
