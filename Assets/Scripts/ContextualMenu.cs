using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ContextualMenu : MonoBehaviour {
  public event System.Action onBuild;
  public event System.Action<Sprite> onSelectionConfirmed;

  public InputAction pointer;
  public InputAction confirmSelection;

  public bool Enabled { get => gameObject.activeSelf; }
  public List<Sprite> options;
  public float radius;
  public SpriteRenderer prototype;
  public float input;
  public Transform selectedOption;
  public Character owner;

  float _degrees;

  void Reset () {
    owner = GetComponentInParent<Character>();
  }

  void OnEnable () {
    Build();
  }

  void OnDisable () {
    Clear();
    pointer.Disable();
    confirmSelection.Disable();
    owner.enabled = true;
  }

  void Update () {
    UpdateConfirmSelection();
    UpdateRadialSelection();
  }

  public void UpdateRadialSelection () {
    Vector3 rawInput = (Vector3) pointer.ReadValue<Vector2>();
    rawInput = (PointOfView.Right * rawInput.x +
                PointOfView.Forward * rawInput.y);
    if (rawInput.magnitude == 0) return;

    if (selectedOption) {
      selectedOption.GetComponent<Animator>().SetBool("highlight", false);
    }
    input = 360 - (Vector3.SignedAngle(new Vector3(0,0,1),
                                       rawInput, Vector3.up) -
                   _degrees/2f + 360) % 360;
    selectedOption = transform.GetChild(((int) Mathf.Floor(input / _degrees)) %
                                        options.Count);
    selectedOption.GetComponent<Animator>().SetBool("highlight", true);
  }

  public void UpdateConfirmSelection () {
    if (confirmSelection.triggered) {
      owner.GetComponent<CharBedDetector>().Unselect();
      this.gameObject.SetActive(false);
      if (onSelectionConfirmed != null)
        onSelectionConfirmed(selectedOption
                             .GetComponent<SpriteRenderer>().sprite);
    }
  }

  public void Build () {
    confirmSelection.Enable();
    pointer.Enable();
    owner.enabled = false;
    this.gameObject.SetActive(true);
    Clear();

    _degrees = 360/(float) options.Count;
    for (int i=0; i<options.Count; i++) {
      SpriteRenderer option = Instantiate(prototype);
      option.sprite = options[i];
      option.transform.parent = transform;
      Vector3 pos =
        Quaternion.AngleAxis(_degrees * i, Vector3.forward) * Vector3.up;
      option.transform.localPosition = pos * radius;
      option.transform.localScale = Vector3.one;
      option.transform.localRotation = Quaternion.identity;
    }

    if (onBuild != null) onBuild();
  }

  public void Clear () {
    for (int i=transform.childCount-1; i>=0; i--) {
      Destroy(transform.GetChild(i).gameObject);
    }
  }
}
