using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(BedVitalSigns))]
public class BedVitalSignsEditor : Editor {
  BedVitalSigns Target { get => (BedVitalSigns) target; }

  public override void OnInspectorGUI () {
    DrawDefaultInspector();
    if (GUILayout.Button("roll")) {
      Target.RollNewValues();
    }
  }
}
