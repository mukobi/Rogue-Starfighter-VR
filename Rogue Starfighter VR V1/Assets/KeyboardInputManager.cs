using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardInputManager : MonoBehaviour
{
    public UnityEvent OnRKeyPressed;
    public UnityEvent OnSKeyPressed;
    public UnityEvent OnDKeyPressed;
    public UnityEvent OnLKeyPressed;
    public UnityEvent OnMKeyPressed;
    public UnityEvent OnAKeyPressed;
    public UnityEvent OnFKeyPressed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            OnRKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.S))
            OnSKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.D))
            OnDKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.L))
            OnLKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.M))
            OnMKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.A))
            OnAKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.F))
            OnFKeyPressed.Invoke();
    }
}
