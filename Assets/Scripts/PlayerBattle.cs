using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    public GameObject Marker;
    public GameObject action;
    private BattleManager sbm;
    public bool playerEndTurn;

    private void Awake()
    {
        sbm = FindObjectOfType<BattleManager>();
    }
    void Update()
    {
        PlayerEndTurn();
    }
    private void OnMouseDown()
    {

        if (playerEndTurn == false)
        {
            if (sbm.PlayerActive != gameObject && sbm.PlayerActive != null)
            {
                sbm.PlayerDeSelect();
            }

            PlayerSelect();
            sbm.PlayerSelect(gameObject);
        }

    }
    public void PlayerSelect()
    {
        Marker.SetActive(true);
    }
    public void PlayerDeSelect()
    {
        Marker.SetActive(false);
        action.SetActive(false);
        sbm.enemyTarget.GetComponent<EnemyController>().EnemyDeSelect();
    }

    public void ActionButton()
    {
        print("attak to " + sbm.enemyTarget.name);
        playerEndTurn = true;
    }

    public  void PlayerEndTurn()
    {
        if (playerEndTurn)
        {
            Marker.SetActive(false);
            action.SetActive(false);
        }
    }
    public void EnemyDamage()
    {

    }
}

