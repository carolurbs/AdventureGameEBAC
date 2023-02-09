using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public List<GameObject> endGameObjects;
    private bool _endgame = false;
    public int currentlevel = 1;
    private void Awake()
    {
        endGameObjects.ForEach(i=>i.SetActive(false));
    }
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (!_endgame && p != null)
        {
            ShowEndGame();
        }
        
    }
    private void ShowEndGame()
    {
        _endgame = true;
        endGameObjects.ForEach(i => i.SetActive(true));
        foreach (var i in endGameObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0, 2f).SetEase(Ease.OutBack).From();
            SaveManager.Instance.SaveLastLevel(1);
            Time.timeScale = 0;
        }
    }
}
