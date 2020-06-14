using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bed : MonoBehaviour, ISelectable {
  public bool Blocked { get => this.user; set {} }
  public bool usable;
  public bool Usable { get => usable; set => usable = value; }

  public Bubble bubble;
  public CharBedDetector user;
  public GameObject actionIndicator;

  public void Select (CharBedDetector user) {
    if (this.user) return;
    this.user = user;
  }

  public void Unselect (CharBedDetector user) {
    if (this.user == user) {
      this.user = null;
    }
  }

  void Update () {
    bubble.SetVisibility(user);
    actionIndicator.SetActive(Usable && !Blocked);
  }
}
