using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private Button _levelButton;

    [SerializeField] private int _levelReq;
    void Start()
    {
        _levelButton = GetComponent<Button>();

        if (PlayerPrefs.GetInt("Level", 1) >= _levelReq)        
            _levelButton.onClick.AddListener(() => LoadLevel());        
        else
            gameObject.GetComponent<CanvasGroup>().alpha = .5f;    
    }

   
     public void LoadLevel()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
