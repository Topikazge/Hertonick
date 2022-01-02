using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionArrowState : ArrowState
{
    public AttractionArrowState(GameObject gameObject) : base(gameObject)
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
