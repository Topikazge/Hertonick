using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightArrowState : ArrowState
{
    public FlightArrowState(GameObject gameObject) : base(gameObject)
    {
    }

    public override void End()
    {
        Debug.LogWarning("����� ��������� ����� state �� �����");
    }

    public override void Start()
    {
        Debug.LogWarning("����� ��������� ����� state �� �����");
    }

    public override void Update()
    {
        Debug.LogWarning("����� ��������� ����� state �� �����");
    }
}
