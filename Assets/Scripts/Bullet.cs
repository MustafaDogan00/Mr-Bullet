using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioClip _boxHit,_plankHit,_tntHit,_groundHit ;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Box")
        {
            Destroy(other.gameObject);
            SoundManager.Instance.PlaySoundFX(_boxHit, .5f);
        }

        if (other.gameObject.tag == "Ground")
        {
            SoundManager.Instance.PlaySoundFX(_groundHit,.5f);
        }
        if (other.gameObject.tag == "Plank")
        {
            SoundManager.Instance.PlaySoundFX(_plankHit, .7f);
        }
        if (other.gameObject.tag == "Tnt")
        {
            SoundManager.Instance.PlaySoundFX(_tntHit,1);
        }

        if (other.gameObject.tag=="LevelCollider")
        {
            FindObjectOfType<GameManager>().Levels();
        }

        if (other.gameObject.tag=="PlayCollider")
        {
            FindObjectOfType<GameManager>().NextLevel();
        }
    }
   

}
