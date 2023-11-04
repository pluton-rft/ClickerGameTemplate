using Clicker.Architecture;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(EnemyListPresent))]
public class EnemyTemplatesEditor : Editor {

    private EnemyListPresent listPresent;

    public void OnEnable() {
        listPresent = (EnemyListPresent)target;
    }

    public override void OnInspectorGUI() {
        if (listPresent.enemyTemplatesList.Count > 0) {
            foreach (var enemyPreset  in listPresent.enemyTemplatesList) {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("x", GUILayout.Width(20), GUILayout.Height(20))) {
                    listPresent.enemyTemplatesList.Remove(enemyPreset);
                    break;
                }
                EditorGUILayout.EndHorizontal();
                enemyPreset.level = EditorGUILayout.IntField("Level spawn enemy:", enemyPreset.level);
                enemyPreset.name = EditorGUILayout.TextField("Enemy name:", enemyPreset.name);
                enemyPreset.image = (Sprite)EditorGUILayout.ObjectField("Sprite:", enemyPreset.image, typeof(Sprite), false);
                EditorGUILayout.EndVertical();
            }
        }
        
        else EditorGUILayout.LabelField("Empty list");

        if (GUILayout.Button("Add new enemy sprite", GUILayout.Height(30))) listPresent.enemyTemplatesList.Add(new EnemyTemplate());
        if (GUI.changed) SetObjectDirty(listPresent.gameObject);
    }

    public void SetObjectDirty(GameObject dirtObj) {
        EditorUtility.SetDirty(dirtObj);
        EditorSceneManager.MarkSceneDirty(dirtObj.scene);
    }
}
