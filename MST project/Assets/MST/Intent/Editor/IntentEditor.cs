using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Intent))]
public class IntentEditor : Editor
{
    Intent intent { get { return (Intent)target; } }

    [MenuItem("MST/Create/intent")]
    public static void CreateItem()
    {
        var asset  = ScriptableObject.CreateInstance(typeof(Intent));
        var path = "Assets/intent.asset";
        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }


    public override void OnInspectorGUI()
    {
        GUILayout.Label("identifire : ");
        GUIStyle errorStyle = new GUIStyle();
        errorStyle.normal.textColor = Color.red;
        GUIStyle gerrnStyle = new GUIStyle();
        gerrnStyle.normal.textColor = Color.green;
        if (string.IsNullOrEmpty(Application.identifier))
        {
            
            GUILayout.Label("error",errorStyle);
        }
        else
        {
            
            GUILayout.Label(Application.identifier, gerrnStyle);

        }
        GUILayout.Space(10);
        DrawDefaultInspector();

        GUILayout.Space(5);
        if (intent.market == Intent.Market.Cafebazaar)
        {
            

            intent.developerName = EditorGUILayout.TextField("Developer Name", intent.developerName);
            if (string.IsNullOrEmpty(intent.developerName))
            {
                GUILayout.Label("This field is required"/* + "\nThis name is needed in the 'cafeBazzar' to open the 'developer page'"*/,errorStyle);
            }
            
        }
    }
}
