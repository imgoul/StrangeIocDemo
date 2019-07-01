using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class AudioManagerWindow:EditorWindow{
    [MenuItem("Manager/AudioManager")]
    static void CreateWindow()
    {
        AudioManagerWindow window = EditorWindow.GetWindow<AudioManagerWindow>("音效管理");
        window.Show();
    }

    void OnInspectorUpdate()
    {
        //SavaAudios();
    }

    private string audioName;
    private string audioPath;
    private Dictionary<string, string> audioDictionary = new Dictionary<string, string>();
    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名称");
        GUILayout.Label("音效路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();

        foreach (var key in audioDictionary.Keys)
        {
            string value;
            audioDictionary.TryGetValue(key, out value);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);
            if (GUILayout.Button("删除"))
            {
                audioDictionary.Remove(key);
                return;
            }
            GUILayout.EndHorizontal();
        }

        audioName = EditorGUILayout.TextField("音效名称", audioName);
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);
        if (GUILayout.Button("添加"))
        {
            if (audioDictionary.ContainsKey(audioName))
            {
                Debug.LogWarning("音效已存在");
            }
            if (Resources.Load<AudioClip>(audioPath) == null)
            {
                Debug.LogWarning("音效不存在于"+audioPath);
            }
            audioDictionary.Add(audioName,audioPath);
            //SavaAudios();
        }
    }

    //void SavaAudios()
    //{
        
    //    string filePath = Application.dataPath + "\\Demo\\Resources\\audioList.txt";
    //    StringBuilder sb = new StringBuilder();
    //    foreach (var key in audioDictionary.Keys)
    //    {
    //        string value;
    //        audioDictionary.TryGetValue(key, out value);
    //        sb.Append(key + "," + value+"\n");
    //    }

        
    //    File.WriteAllText(filePath,sb.ToString());
    //}

    //void loadAudios()
    //{
    //    //TODO
    //    if (File.Exists(Application.dataPath + "\\Demo\\Resources\\audioList.txt") == false)
    //    {
    //        return;
    //    }
    //}
}
