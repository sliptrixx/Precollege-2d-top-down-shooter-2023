using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] ScoreManager scoreManager;

    private void Awake()
    {
        string json_string = File.ReadAllText($"{Application.persistentDataPath}/savedata.json");
        var data = JsonUtility.FromJson<SaveData>(json_string);

        player.position = data.PlayerPosition;
        scoreManager.SetScore(data.currentScore);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            // save code
            SaveData data = new SaveData();
            data.PlayerPosition = player.position;
            data.currentScore = scoreManager.currentScore;

            // serialize into JSON
            string json_string = JsonUtility.ToJson(data);
            File.WriteAllText($"{Application.persistentDataPath}/savedata.json", json_string);
        }
    }
}

[System.Serializable]
public class SaveData
{
    public Vector3 PlayerPosition;
    public int currentScore;
}
