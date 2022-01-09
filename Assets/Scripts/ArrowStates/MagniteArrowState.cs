using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagniteArrowState : ArrowState
{
    public MagniteArrowState(GameObject gameObject, Player player) : base(gameObject, player)
    {
    }

    public override void End()
    {
        Debug.LogWarning("Метод жизненого цикла state не задан");
    }

    public override void Start()
    {
        Debug.LogWarning("Метод жизненого цикла state не задан");
    }

    public override void Update()
    {
        Debug.LogWarning("Метод жизненого цикла state не задан");
    }
}
