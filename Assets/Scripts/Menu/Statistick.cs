using UnityEngine;
using System;
using System.IO;


public class Statistick : MonoBehaviour
{
    public int dm = 1;

    public int Hp = 3;

    public float speed = 150;

    public float braking = 5f;

    public float musickVolume;
    public float effectVolume;

    public bool stick;

    static public string path;
    private SaveData data = new SaveData();
    private void Awake()
    {
        int numStaticsPlayer = FindObjectsOfType<Statistick>().Length;
        if (numStaticsPlayer != 1)
        {
            Destroy(this.gameObject);
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    private void Start()
    {
        Load();
    }

    public void Load()
    {
        string key = "t1";

        if (PlayerPrefs.HasKey(key))
        {
            string value = PlayerPrefs.GetString(key);

            SaveData data = JsonUtility.FromJson<SaveData>(value);

            this.dm = data.dm;
            this.Hp = data.Hp;
            this.speed = data.speed;
            this.braking = data.braking;
        }
    }

    public void Save()
    {
        string key = "t1";

        data.dm = this.dm;
        data.Hp = this.Hp;
        data.speed = this.speed;
        data.braking = this.braking;

        string value = JsonUtility.ToJson(data);

        PlayerPrefs.Save();

        PlayerPrefs.SetString(key, value);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
        }
    }
}
