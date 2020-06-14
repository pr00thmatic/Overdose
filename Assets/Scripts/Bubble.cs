using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bubble : MonoBehaviour {
  public GameObject model;

  public void SetVisibility (bool value) {
    model.SetActive(value);
  }
}
