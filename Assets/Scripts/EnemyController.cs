using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Marker;
    private BattleManager sbm;
    public bool enemyEndTurn;
    public GameObject playerTarget;

    private void Awake()
    {
        sbm = FindObjectOfType<BattleManager>();
    }

    private void OnMouseDown()
    {
        if (sbm.enemyTarget != gameObject && sbm.enemyTarget != null)
        {
            sbm.EnemyDeSelect();
        }

        EnemySelect();
        sbm.EnemySelect(gameObject);
    }
    public void EnemySelect()
    {
        Marker.SetActive(true);
        sbm.PlayerActive.GetComponent<PlayerBattle>().action.SetActive(true);
    }
    public void EnemyDeSelect()
    {
        Marker.SetActive(false);
    }
    public void EnemyAtk()
    {
        playerTarget = sbm.players[Random.Range(0, sbm.players.Length)];
        transform.LookAt(playerTarget.transform);
        print("atak " + playerTarget.name);
        enemyEndTurn = true;
    }
}
