using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager __instance__ = null;
    public static SoundManager INSTANCE { get => __instance__; }

    private Dictionary<string, AudioClip> items;
    private AudioSource[] sources = new AudioSource[(int)AudioType.count];

    private void Start()
    {
        items = new Dictionary<string, AudioClip>();

        Debug.Log("Finding Sound Clips");
        InitLoad("Assets\\Resources\\Sound");
        Debug.Log("Done!");

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < sources.Length; i++)
        {
            string _name_ = "empty";

            if (i == 0) _name_ = "BGM";
            else if (i == 1) _name_ = "EFFECT";

            GameObject _inst_ = new GameObject { name = _name_ };

            _inst_.transform.SetParent(transform);

            sources[i] = _inst_.AddComponent<AudioSource>();
        }

        __instance__ = this;
    }

    private void InitLoad(string cd /*current directory*/)
    {
        foreach (string file in Directory.GetFiles(cd))
        {
            if (!file.EndsWith(".mp3")) continue;

            string fileLocation = file.Split('.')[0].Substring(17);
            string key = fileLocation.Substring(6);

            items[key] = Resources.Load<AudioClip>(fileLocation);

            if (items[key] != null) Debug.Log($"{key} is Loaded");
            else Debug.Log($"tryed to load {key}({fileLocation}) but has error");
        }

        foreach (string next in Directory.GetDirectories(cd))
        {
            InitLoad(next);
        }
    }

    public enum AudioType { BGM, EFFECT, count }

    public void Play(string name, AudioType type)
    {
        AudioSource source = sources[(int)type];
        AudioClip clip = items[name];

        if (clip == null) { Debug.Log($"{name} is NotFound"); return; }
        if (source.isPlaying) source.Stop();

        source.clip = clip;
        source.Play();
    }
}