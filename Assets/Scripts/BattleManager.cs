using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject PlayerActive;
    public GameObject enemyTarget;
    public GameObject[] players;
    public bool playerEndTurn;
    public GameObject[] enemies;
    public bool enemyEndTurn;
    public int time;
    public float timeTrans;

    public void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        PlayerEndTurn();
        EnemyAtk();
    }

    public  void PlayerEndTurn()
    {
        int x = 0;
        for(int i =  0;i < players.Length; i++)
        {
           if (players[i].GetComponent<PlayerBattle>().playerEndTurn)
            {
                x++;
            }
        }
        if (x == players.Length)
        {
            playerEndTurn = true;
        }
    }

    public void PlayerSelect (GameObject playerSelect)
    {
        PlayerActive = playerSelect;
    }
    public void PlayerDeSelect()
    {
        PlayerActive.GetComponent<PlayerBattle>().PlayerDeSelect();
        PlayerActive = null;
    }
    public void EnemySelect(GameObject enemySelect)
    {
        enemyTarget = enemySelect;
    }
    public void EnemyDeSelect()
    {
        enemyTarget.GetComponent<EnemyController>().EnemyDeSelect();
        enemyTarget = null;
    }

    public void EnemyAtk()
    {
        if (playerEndTurn)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<EnemyController>().enemyEndTurn == false)
                {
                    timeTrans += Time.deltaTime;
                    time = Mathf.RoundToInt(timeTrans);
                    if (time == 3)
                    {
                        enemies[i].GetComponent<EnemyController>().EnemyAtk();
                        timeTrans = 0;
                        time = 0;
                    }
                    
                }
            }
        }
    }
}
