using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPlayer : MonoBehaviour
{
    private ArrowKeeper _arrowKeeper;
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
        _arrowKeeper = GetComponent<ArrowKeeper>();
        GetComponent<InputPlayer>().OnAttack += Shot;
    }

    public void Shot()
    {
        Debug.Log("ьссссссср акърэ 1 ");
        _arrowKeeper.GetArrow(ShootArrow);
    }

    private void ShootArrow(Arrow arrow)
    {
        Debug.Log("ьссссссср акърэ 2 ");
        arrow.Flight(_player.SideGaze);
    }
}
