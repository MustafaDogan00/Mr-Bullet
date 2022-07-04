using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

    void Death()
    {
        gameObject.tag = "Untagged";
        FindObjectOfType<GameManager>().EnemyCountCheck();
        foreach (Transform obj in transform)
        {
            obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        }             
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 direction=transform.position - other.transform.position;
        if (other.gameObject.tag=="Bullet")
        {
            if(transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale<1)
            Death();
            GetComponent<Rigidbody2D>().AddForce(new Vector2((direction.x > 0 ? 1 : -1)*5, direction.y > 0 ? .3f : -.3f), ForceMode2D.Impulse);
        }

        if (other.gameObject.tag=="Plank")
        {
            if (other.GetComponent<Rigidbody2D>().velocity.magnitude>1.5f)
            {
                Death();
            }
        }
        if (other.gameObject.tag == "Ground")
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude > 1.5f)
            {
                Death();
            }
        }



    }

}
