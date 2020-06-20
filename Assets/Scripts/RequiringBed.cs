using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequiringBed : MonoBehaviour {
  public bool IsDead { get => requirement == Requirements.Instance.dead; }

  public InputAction asdf;
  public BedRequirement requirement;
  public SpriteRenderer indicator;
  public Image timeIndicator;
  public int currentIndex;
  public float elapsed = 0;
  public int cryticalTimes = 0;

  void OnEnable () {
    asdf.Enable();
    indicator.gameObject.SetActive(true);
    elapsed = 0;
    requirement = Requirements.Instance.bucle[currentIndex];
  }

  void OnDisable () {
    indicator.gameObject.SetActive(false);
  }

  void Update () {
    if (IsDead) return;

    elapsed += Time.deltaTime;
    timeIndicator.fillAmount = (elapsed / requirement.time);

    if (!IsDead && elapsed >= requirement.time) {
      if (requirement == Requirements.Instance.crytical) {
        requirement = Requirements.Instance.dead;
        currentIndex = -1;
      } else {
        requirement = Requirements.Instance.crytical;
        elapsed = 0;
      }
    }

    indicator.sprite = requirement.icon;
    if (asdf.triggered) Meet();
  }

  public void Meet () {
    if (requirement == Requirements.Instance.crytical) {
      requirement = Requirements.Instance.bucle[currentIndex];
      elapsed = requirement.time -
        requirement.time / (float) (++cryticalTimes+1);
    } else if (currentIndex >= Requirements.Instance.bucle.Length-1) {
      this.enabled = false;
    } else {
      requirement = Requirements.Instance.bucle[++currentIndex];
      elapsed = 0;
    }
    print("meet");
  }
}
