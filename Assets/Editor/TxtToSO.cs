using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class TxtToSO : EditorWindow
{
    [MenuItem("Tools/CSV to ScriptableObject Converter")]
    public static void ShowWindow()
    {
        GetWindow(typeof(TxtToSO), false, "CSV to ScriptableObject Converter");
    }

    private TextAsset txtFile;
    private bool isResponse;
    private List<MessageSO> messageDataList = new List<MessageSO>();

    private void OnGUI()
    {
        GUILayout.Label("Select a .txt file:", EditorStyles.boldLabel);
        txtFile = EditorGUILayout.ObjectField(txtFile, typeof(TextAsset), false) as TextAsset;
        isResponse = EditorGUILayout.Toggle("Is Response", isResponse);

        if (GUILayout.Button("Convert"))
        {
            ConvertTxtToScriptableObjects();
        }
    }

    private void ConvertTxtToScriptableObjects()
    {
        if (txtFile == null)
        {
            Debug.LogError("No .txt file selected!");
            return;
        }

        string[] lines = txtFile.text.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(';');
            MessageSO messageData = ScriptableObject.CreateInstance<MessageSO>();
            messageData.message = fields[0];
            messageData.category = fields[1];
            string assetPath;
            if (isResponse)
            {
                assetPath = "Assets/Messages/Responses/" + i + ".asset";
            }
            else
            {
                assetPath = "Assets/Messages/Questions/" + i + ".asset";
            }
            AssetDatabase.CreateAsset(messageData, assetPath);
            messageDataList.Add(messageData);
        }


        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("txt file converted to ScriptableObjects successfully!");
    }
}
#endif
