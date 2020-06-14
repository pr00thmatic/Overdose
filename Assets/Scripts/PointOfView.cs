using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointOfView : NonPersistantSingleton<PointOfView> {
  public static Vector3 Right { get => Instance.transform.right; }
  public static Vector3 Forward { get => Instance.transform.forward; }
}
