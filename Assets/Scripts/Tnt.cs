using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tnt : MonoBehaviour
{
    public GameObject exlopeObj;

    private float _radius = 1;
    private float _power = 10;

    void Explode()
    {
        Vector2 expPos=transform.position;
        Collider2D[] colls=Physics2D.OverlapCircleAll(expPos, _radius);
        foreach(Collider2D hit in colls)
        {
            if (hit.GetComponent<Rigidbody2D>() != null)
            {
                var explodeDir=hit.GetComponent<Rigidbody2D>().position - expPos;
                hit.GetComponent<Rigidbody2D>().gravityScale = 1;
                hit.GetComponent<Rigidbody2D>().AddForce(explodeDir*_power,ForceMode2D.Impulse);
            }
            if (hit.tag == "Enemy")
                hit.tag = "Untagged";            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Bullet")
        {
            GameObject exp=Instantiate(exlopeObj);
            exp.transform.position =transform.position;
            Destroy(exp,.5f);
            Destroy(gameObject);
            Explode();
        }
    }

}
