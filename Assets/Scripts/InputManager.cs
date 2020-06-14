using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : NonPersistantSingleton<InputManager> {
  public static TheInput input;

  void Awake () {
    input = new TheInput();
    input.Enable();
    input.actions.Enable();
  }
}
