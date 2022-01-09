using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IEnter 
{
    public void StartEnter(InputAction.CallbackContext callbackContext);
    public void EndEnter(InputAction.CallbackContext callbackContext);
}
