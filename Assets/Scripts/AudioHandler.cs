using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioHandler : MonoBehaviour
{

    [SerializeField] Sound[] sounds;

    



    private void Awake()
    {

        // Load Audio Settings from PlayerPrefs and add it to an object of type AudioSettings.
        AudioSettings myAudioSettings = new AudioSettings();

        myAudioSettings = SaveHandler<AudioSettings>.Load(SaveHandler<AudioSettings>.SaveFileName.audioSettings);
        

        // Checks if there's an audiosettings at all in playerprefs. if there isnt, set all volume to 100% and saves that to PlayerPrefs

        if (myAudioSettings == null)
        {
            myAudioSettings = new AudioSettings { vfxVolume = 1f };



            SaveHandler<AudioSettings>.Save(myAudioSettings, SaveHandler<AudioSettings>.SaveFileName.audioSettings);

        }


        

        //Debug.Log("vfx volume " + myAudioSettings.vfxVolume);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * myAudioSettings.vfxVolume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    internal void Play(SoundName name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name.ToString());
        s.source.Play();
    }

    public enum SoundName {
        SnakeDeath,
        SnakeAte,


    }


    [System.Serializable]
    private class Sound
    {

        [SerializeField] internal AudioClip clip;

        [SerializeField] internal string name;



        [SerializeField] [Range(0f, 1f)] internal float volume;
        [SerializeField] [Range(0.1f, 3f)] internal float pitch;

        internal AudioSource source;

        [SerializeField] internal bool loop;

       
    }




    public class AudioSettings {

         public float mainVolume;
         public float vfxVolume;
         public float musicVolume;
         public float dialogueVolume;

       
    }



















}
