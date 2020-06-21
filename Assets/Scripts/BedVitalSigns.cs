using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BedVitalSigns : MonoBehaviour {
  public VitalSignValue[] real;
  public VitalSignValue[] registered;

  public void RollNewValues () {
    VitalSign[] available = Resources.LoadAll<VitalSign>("vital signs");
    print(available.Length);
    real = new VitalSignValue[available.Length];
    registered = new VitalSignValue[available.Length];

    for (int i=0; i<available.Length; i++) {
      real[i] = new VitalSignValue() {
        sign = available[i],
        value = (VitalSignMeasure) Random.Range(1,4)
      };

      registered[i] = new VitalSignValue() {
        sign = available[i],
        value = VitalSignMeasure.Unknown
      };
    }
  }

  public bool IsKnown (Sprite vitalSignSprite) {
    foreach (VitalSignValue value in registered) {
      if (value.sign.sprite == vitalSignSprite) {
        return value.value != VitalSignMeasure.Unknown;
      }
    }

    Debug.Log("couldn't find " + vitalSignSprite, vitalSignSprite);
    return false;
  }
}
