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
    private List<AudioSource> fxSources = new List<AudioSource>();

    [SerializeField]
    private AudioSource bgmSource;

    [SerializeField]
    private int MaxNumberOfSound;

    private void Awake()
    {
        if (__instance__ != null) { Destroy(gameObject); return; }
        
        audioClipDict = new Dictionary<string, AudioClip>();

        InitLoad();

        DontDestroyOnLoad(gameObject);


        for (int i = 0; i <= MaxNumberOfSound; i++)
        {
            GameObject inst = new GameObject { name = $"EFFECT{i}" };
            inst.transform.SetParent(transform);

            if (i == 0)
            {
                inst.name = "BGM";
                bgmSource = inst.AddComponent<AudioSource>();
                bgmSource.loop = true;
            }
            else
            {
                fxSources.Add(inst.AddComponent<AudioSource>());
            }
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

    public enum AudioType { BGM, EFFECT }

    private AudioSource getIdleSource(AudioType type)
    {
        if (type == AudioType.BGM) return bgmSource;

        AudioSource result = null;

        foreach (AudioSource source in fxSources)
        {
            if (!source.isPlaying)
            {
                result = source;
                break;
            }

            if (result == null) result = source;
            else if (source.time < result.time) result = source;
        }

        return result;
    }

    public void Play(string name, AudioType type)
    {
        if (audioClipDict.ContainsKey(name) == false)
        {
            Debug.Log($"{name} is NotFound");
            return;
        }

        AudioSource source = getIdleSource(type);
        AudioClip clip = audioClipDict[name];

        if (source.isPlaying) source.Stop();

        source.clip = clip;
        source.Play();
    }
}