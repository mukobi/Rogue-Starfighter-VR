using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOndestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log($"{name} destroyed.");
    }
}
