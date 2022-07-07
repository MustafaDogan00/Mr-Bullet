using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tnt : MonoBehaviour
{
    public GameObject exlopeObj;

    private float _radius = 1;
    private float _power = 10;

    [SerializeField] private AudioClip _tntHit;

    void Explode()
    {
        Vector2 expPos=transform.position;
        if (SceneManager.GetActiveScene().buildIndex == 8)
            _radius = 2;
        else
            _radius = 1;

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
        if (other.gameObject.tag == "Bullet" || GetComponent<Rigidbody2D>().velocity.magnitude > 1.5f) 
        {
            GameObject exp=Instantiate(exlopeObj);
            exp.transform.position =transform.position;
            Destroy(exp,.5f);
            Destroy(gameObject);
            SoundManager.Instance.PlaySoundFX(_tntHit,1);
            Explode();
        }
    }

}
