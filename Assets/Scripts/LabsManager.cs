using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LabsManager : MonoBehaviour, ISelectable {
  public bool Blocked { get => false; set {} }
  public bool usable;
  public bool Usable { get => usable; set => usable = value; }

  public GameObject actionIndicator;

  void Update () {
    actionIndicator.SetActive(Usable && !Blocked);
  }
}
