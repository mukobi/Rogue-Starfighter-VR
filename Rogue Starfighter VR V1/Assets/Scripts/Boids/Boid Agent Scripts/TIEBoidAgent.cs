using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIEBoidAgent : BoidAgent
{
    protected override void Start()
    {
        base.Start();
        Initialize(TIEBoidFlock.Instance);
        TIEBoidFlock.Instance.agents.Add(this);
    }

    private void OnDestroy()
    {
        TIEBoidFlock.Instance.agents.Remove(this);
    }
}
