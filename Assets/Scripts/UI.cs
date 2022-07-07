using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
   public static UI Instance;  
   
    private GameManager _gameManager;

    private int startBB;

    [SerializeField] private Text _goodJobText;

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private GameObject _goldenStar1,_goldenStar2,_goldenStar3;



    void Awake()
    {
        Instance = this;
        _gameManager = FindObjectOfType<GameManager>();      

        startBB = _gameManager.blackBullets;
        _gameOverPanel.SetActive(false);
    }

   
    public void GameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void WinScreen()
    {
        _winPanel.SetActive(true);
        if (_gameManager.blackBullets>=startBB)
        {
            _goodJobText.text = "FANTASTIC!";
            StartCoroutine(Star(3));
        }
        else if (_gameManager.blackBullets >= startBB-(_gameManager.blackBullets/2))
        {
            _goodJobText.text = "AWESOME!";
            StartCoroutine(Star(2));
        }
        else if (_gameManager.blackBullets >0)
        {
            _goodJobText.text = "WELL DONE!";
            StartCoroutine(Star(1));
        }
        else
        {
            _goodJobText.text = "GOOD";
        }
    }

    IEnumerator Star(int goldenStar)
    {
        yield return new WaitForSeconds(.5f);
        switch(goldenStar)
        {
            case 3:
                yield return new WaitForSeconds(.25f);
                _goldenStar1.SetActive(true);
                yield return new WaitForSeconds(.25f);
                _goldenStar2.SetActive(true);
                yield return new WaitForSeconds(.25f);
                _goldenStar3.SetActive(true);
                break;
            case 2:
                yield return new WaitForSeconds(.25f);
                _goldenStar1.SetActive(true);
                yield return new WaitForSeconds(.25f);
                _goldenStar2.SetActive(true);
                break;
            case 1:
                yield return new WaitForSeconds(.25f);
                _goldenStar1.SetActive(true);
                break;
        }

    }
}
