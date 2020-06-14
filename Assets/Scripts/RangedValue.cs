using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RangedValue {
  public float Normalized { get => (current - min) / (max - min); }

  public float max;
  public float min;

  [SerializeField]
  float _current = 0;
  public float current {
    get => _current;
    set {
      _current = Mathf.Max(min, Mathf.Min(value, max));
    }
  }

  public float Lerp (float t) { return (max - min) * t + min; }
}
