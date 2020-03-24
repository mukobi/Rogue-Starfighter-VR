using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalReference : MonoBehaviour
{
    public Transform AheadOfPlayerTarget;

    public Transform shipRotationRoot;

    public ForwardEngine forwardEnginePlayerRef;

    public static PlayerGlobalReference I;

    private void Awake()
    {
        I = this;
    }
}
