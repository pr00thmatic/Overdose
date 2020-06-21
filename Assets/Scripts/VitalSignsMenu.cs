using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VitalSignsMenu : MonoBehaviour {
  public List<Sprite> tools;
  public ContextualMenu menu;
  public CharBedDetector bedDetector;

  void Awake () {
    // menu.onBuild += HandleBuild;
  }
}
