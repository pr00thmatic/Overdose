using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectableDetector : MonoBehaviour {
  public event System.Action<ISelectable> onSelectionChange;

  public ISelectable selected;
  float _angle = Mathf.Infinity;
  ISelectable _last;

  void Update () {
    if (selected != _last) {
      if (onSelectionChange != null) onSelectionChange(selected);
    }

    _last = selected;

    if (selected as MonoBehaviour) {
      selected.Usable = true;
    }
  }

  void OnTriggerStay (Collider c) {
    ISelectable possible = c.GetComponentInParent<ISelectable>();
    if (!(possible as MonoBehaviour) ||
        selected == possible || possible.Blocked) return;
    float angle =
      Vector3.Angle((possible as MonoBehaviour).transform.position -
                    transform.position, transform.forward);
    if (angle <= _angle) {
      if (selected as MonoBehaviour) selected.Usable = false;
      selected = possible;
      selected.Usable = true;
      _angle = angle;
    }
  }

  void OnTriggerExit (Collider c) {
    ISelectable exit = c.GetComponentInParent<ISelectable>();
    if (!(exit as MonoBehaviour) ||
        exit != selected) return;

    selected.Usable = false;
    _angle = Mathf.Infinity;
    selected = null;
  }
}
