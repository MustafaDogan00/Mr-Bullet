using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
   
  
    public void Levels()
    {
        _levelsPanel.SetActive(true);
    }
}
