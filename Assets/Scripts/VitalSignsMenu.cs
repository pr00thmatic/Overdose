using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VitalSignsMenu : MonoBehaviour {
  public ContextualMenu menu;
  public CharBedDetector bedDetector;

  void Awake () {
    menu.onBuild += HandleBuild;
  }

  public void HandleBuild () {
    foreach (Transform child in menu.transform) {
      SpriteRenderer option = child.GetComponent<SpriteRenderer>();

      option.transform.GetChild(0).gameObject
        .SetActive(bedDetector.selectedBed.GetComponent<BedVitalSigns>()
                   .IsKnown(option.sprite));
    }
  }
}
