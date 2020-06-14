using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {
  public float DeltaLastPush { get => Time.time - _lastPush; }

  public InputAction motion;
  public InputAction run;
  public Vector3 inputMotion;
  public float currentSpeed;
  public float bonusTapsPerSecond = 5;

  public RangedValue speed;
  public RangedValue pushAcceleration;
  public RangedValue deceleration;

  public RangedValue bonusSpeed;
  public RangedValue bonusDeceleration;
  public Vector3 deltaMotion;

  float _lastPush = -1;

  void OnEnable () {
    motion.Enable();
    run.Enable();
    run.performed += Run;
  }

  void OnDisable () {
    run.performed -= Run;
  }

  void FixedUpdate () {
    inputMotion = motion.ReadValue<Vector2>();
    deltaMotion = (PointOfView.Right * inputMotion.x +
                   PointOfView.Forward * inputMotion.y) *
      Time.deltaTime * currentSpeed;

    transform.position += deltaMotion;

    if (DeltaLastPush <= (1/bonusTapsPerSecond)) {
      bonusSpeed.current -= bonusDeceleration.Lerp(bonusSpeed.Normalized) *
        Time.deltaTime;
      currentSpeed = bonusSpeed.current;
    } else {
      speed.current -= deceleration.Lerp(speed.Normalized) * Time.deltaTime;
      currentSpeed = speed.current;
    }

    if (deltaMotion != Vector3.zero) {
      transform.forward = deltaMotion;
    }
  }

  public void Run (InputAction.CallbackContext asdf) {
    if (DeltaLastPush > (1/bonusTapsPerSecond)) {
      speed.current += pushAcceleration.Lerp(1 - speed.Normalized);
      bonusSpeed.current = bonusSpeed.min;
    } else {
      speed.current = speed.max;
      bonusSpeed.current += pushAcceleration.Lerp(1 - speed.Normalized);
    }
    _lastPush = Time.time;
  }
}
