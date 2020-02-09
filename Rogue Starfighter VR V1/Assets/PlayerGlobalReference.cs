using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalReference : MonoBehaviour
{
    public Transform rotationRoot;

    public ForwardEnginePlayerRef forwardEnginePlayerRef;

    public static PlayerGlobalReference Instance;

    private void Awake()
    {
        Instance = this;
    }
}
