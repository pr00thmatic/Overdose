using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class CharVitalSignsTaker : MonoBehaviour {
  public ContextualMenu vitalSignsMenu;
  public CharBedDetector detector;
  public Character motion;
  public Sprite vitalSignsIcon;

  void Update () {
    if (!detector.selectedBed ||
        detector.selectedBed.requirement.requirement.icon != vitalSignsIcon) return;
    if (!vitalSignsMenu.Enabled) vitalSignsMenu.gameObject.SetActive(true);
  }
}
