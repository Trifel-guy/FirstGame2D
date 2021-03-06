using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponentInParent<Player>();
        if(player != null)
        {
            //Debug.LogWarning("Player"+ player.gameObject.name+ "is dead");
            player.Die();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255 , 0 , 0 , 0.7f);
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}
