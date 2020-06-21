using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class CharBedDetector : MonoBehaviour {
  public InputAction selectBed;
  public Bed selectedBed;
  public SelectableDetector detector;

  void OnEnable () {
    selectBed.Enable();
    selectBed.started += HandleAction;
    detector.onSelectionChange += HandleSelection;
  }

  void OnDisable () {
    selectBed.Disable();
    selectBed.started -= HandleAction;
    detector.onSelectionChange -= HandleSelection;
  }

  public void HandleSelection (ISelectable changed) {
    if (!selectedBed) return;
    MonoBehaviour b = changed as MonoBehaviour;
    if (!b || b.GetComponent<Bed>() != selectedBed) Unselect();
  }

  public void HandleAction (InputAction.CallbackContext asdf) {
    MonoBehaviour b = detector.selected as MonoBehaviour;
    if (!b || !b.GetComponent<Bed>() ||
        b.GetComponent<Bed>() == selectedBed) return;

    Bed bed = b.GetComponent<Bed>();
    if (selectedBed) Unselect();
    Select(bed);
  }

  public void Select (Bed bed) {
    if (selectedBed) {
      Unselect();
    }
    this.selectedBed = bed;
    bed.Select(this);
  }

  public void Unselect () {
    selectedBed.Unselect(this);
    this.selectedBed = null;
  }
}
