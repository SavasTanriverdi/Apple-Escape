using System;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public Player Player; // Bu, oyun yöneticisinin oyuncuya erişmesine yardımcı olur
    [Header("Managers")] // Bu, oyun yöneticisinin yöneticilere erişmesine yardımcı olur
    public EnemyManager enemyManager; // Bu, oyun yöneticisinin düşman yöneticisine erişmesine yardımcı olur
    public LevelManager levelManager; // Bu, oyun yöneticisinin seviye yöneticisine erişmesine yardımcı olur

    private void Start()
    {
        RestartLevel();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemyManager();
        Player.RestartPlayer();
    }

    public void LevelCompleted() // Bu, oyun yöneticisinin seviyenin tamamlandığını belirtmesine yardımcı olur
    {
        Debug.Log("Level completed!"); // Bu, oyun yöneticisinin seviyenin tamamlandığını belirtmesine yardımcı olur
        enemyManager.StopEnmies(); // Bu, düşman yöneticisinin düşmanların hareketini durdurmasına yardımcı olur
        
    }
}
