using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager __instance__ = null;
    public static SoundManager INSTANCE { get => __instance__; }

    [SerializeField]
    private AudioClip[] Clips;

    private Dictionary<string, AudioClip> audioClipDict;

    [SerializeField]
    private AudioSource[] sources = new AudioSource[(int)AudioType.count];

    private void Awake()
    {
        audioClipDict = new Dictionary<string, AudioClip>();

        InitLoad();

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < sources.Length; i++)
        {
            string _name_ = "Unknown";

            if (i == 0) _name_ = "BGM";
            else if (i == 1) _name_ = "EFFECT";

            GameObject _inst_ = new GameObject { name = _name_ };

            _inst_.transform.SetParent(transform);
            sources[i] = _inst_.AddComponent<AudioSource>();
        }

        __instance__ = this;
    }

    private void InitLoad()
    {
        Debug.Log("Loading Sound Clips");

        foreach (AudioClip clip in Clips)
        {
            Debug.Log($"Loaded {clip.name}");
            audioClipDict[clip.name] = clip;
        }

        Debug.Log("Done!");
    }

    public enum AudioType { BGM, EFFECT, count }

    public void Play(string name, AudioType type)
    {
        if (audioClipDict.ContainsKey(name) == false)
        {
            Debug.Log($"{name} is NotFound");
            return;
        }

        AudioSource source = sources[(int)type];
        AudioClip clip = audioClipDict[name];

        if (source.isPlaying) source.Stop();

        if (type == AudioType.BGM)
        {
            source.loop = true;
        }

        source.clip = clip;
        source.Play();
    }
}