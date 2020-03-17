using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalReference : MonoBehaviour
{
    public Transform shipRotationRoot;

    public ForwardEnginePlayerRef forwardEnginePlayerRef;

    public static PlayerGlobalReference I;

    private void Awake()
    {
        I = this;
    }
}
