using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public delegate void OnKeyDownEvent(KeyCode keycode);
    public static event OnKeyDownEvent OnKeyDown;
    private void Update()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                OnKeyDown?.Invoke(keyCode);
            }
        }
    }

}
