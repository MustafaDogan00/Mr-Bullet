using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _enemyCount=1;

    [HideInInspector] public bool gameOver;

    public int blackBullets = 3;
    public int goldenBullets = 1;
    private int levelNumber;

    public GameObject blackBullet, goldenBullet;

    public bool canTouch;


    private void Awake()
    {
        gameOver=false;
        levelNumber = PlayerPrefs.GetInt("Level", 1);

        FindObjectOfType<PlayerController>().ammo=blackBullets+goldenBullets;
        for (int i = 0; i < blackBullets; i++)
        {
            GameObject blackBul = Instantiate(blackBullet);
            blackBul.transform.SetParent(GameObject.Find("Bullets").transform);
            blackBul.transform.localScale = new Vector3(1, 1, 1);
        }
      
        for (int i = 0; i < goldenBullets; i++)
        {
            GameObject goldenBul = Instantiate(goldenBullet);
            goldenBul.transform.SetParent(GameObject.Find("Bullets").transform);
            goldenBul.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void Update()
    {
        if (!gameOver && FindObjectOfType<PlayerController>().ammo<=0 && _enemyCount>0 && 
            GameObject.FindGameObjectsWithTag("Bullet").Length<=0)
        {        
            UI.Instance.GameOverPanel();
        }
    }


    public void EnemyCountCheck()
    {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (_enemyCount <=0)
        {
            gameOver = true;
            UI.Instance.WinScreen();
            if (levelNumber == SceneManager.GetActiveScene().buildIndex)
            {
                PlayerPrefs.SetInt("Level", levelNumber + 1);
            }          
        }
    }

    public void BulletImage()
    {
        if (goldenBullets > 0)
        {
            goldenBullets--;
            GameObject.FindGameObjectWithTag("GoldenBullet").SetActive(false);
        }
       else if (blackBullets>0)
        {
            blackBullets--;
            GameObject.FindGameObjectWithTag("BlackBullet").SetActive(false);
        }
    }

    public void NextLevel()
    {      
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));

    }
    public void Restart()
    {
        canTouch = true;
        gameOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
       
    }
    public void Quit()
    {
        canTouch = true;
        gameOver = true;
        SceneManager.LoadScene(0);       
    }

    

}
