using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMainMenu : MonoBehaviour
{

    [SerializeField] private RectTransform panelRectTransform;



    private void Awake()
    {

        // Load Audio Settings from PlayerPrefs and add it to an object of type AudioSettings.
        AudioHandler.AudioSettings myAudioSettings = new AudioHandler.AudioSettings();

        myAudioSettings = SaveHandler<AudioHandler.AudioSettings>.Load(SaveHandler<AudioHandler.AudioSettings>.SaveFileName.audioSettings);





        // Checks if there's an audiosettings at all in playerprefs. if there isnt, set all volume to 100% and saves that to PlayerPrefs

        if (myAudioSettings == null)
        {
            myAudioSettings = new AudioHandler.AudioSettings { vfxVolume = 1f };



            SaveHandler<AudioHandler.AudioSettings>.Save(myAudioSettings, SaveHandler<AudioHandler.AudioSettings>.SaveFileName.audioSettings);


        }

        if (myAudioSettings.vfxVolume == 1f)
        {


            GameObject.Find("VolumeToggleBtn").GetComponent<Image>().sprite = GameObject.Find("VolumeToggleBtn").GetComponent<Button>().spriteState.selectedSprite;

        }
        else
        {
           
            
            GameObject.Find("VolumeToggleBtn").GetComponent<Image>().sprite = GameObject.Find("VolumeToggleBtn").GetComponent<Button>().spriteState.disabledSprite;

        }


    }

    private void Start()
    {
        //panelTransform.position = new Vector2(0, 0);
        //panelRectTransform.offsetMin = new Vector2(Screen.width / SettingsHandler.horizontalRows, Screen.width / SettingsHandler.horizontalRows);
        //panelRectTransform.offsetMax = new Vector2(-Screen.width / SettingsHandler.horizontalRows, -Screen.width / SettingsHandler.horizontalRows);
        //Debug.Log(panelRectTransform.offsetMax);
    }

    public void LoadMainGame()
    {
        SceneHandler.Load(SceneHandler.Scene.GameScene);
    }

    public void LoadHighScoreMenu()
    {
        SceneHandler.Load(SceneHandler.Scene.HighScoreMenu);
       
    }

    public void ToggleSound()
    {


        
        // Load Audio Settings from PlayerPrefs and add it to an object of type AudioSettings.
        AudioHandler.AudioSettings myAudioSettings = new AudioHandler.AudioSettings();

        myAudioSettings = SaveHandler<AudioHandler.AudioSettings>.Load(SaveHandler<AudioHandler.AudioSettings>.SaveFileName.audioSettings);


        


        // Checks if there's an audiosettings at all in playerprefs. if there isnt, set all volume to 100% and saves that to PlayerPrefs

        if (myAudioSettings == null)
        {
            myAudioSettings = new AudioHandler.AudioSettings { vfxVolume = 1f };



            SaveHandler<AudioHandler.AudioSettings>.Save(myAudioSettings, SaveHandler<AudioHandler.AudioSettings>.SaveFileName.audioSettings);
            

        }

        if (myAudioSettings.vfxVolume == 1f)
        {
            myAudioSettings.vfxVolume = 0f;
            SaveHandler<AudioHandler.AudioSettings>.Save(myAudioSettings, SaveHandler<AudioHandler.AudioSettings>.SaveFileName.audioSettings);
            GameObject.Find("VolumeToggleBtn").GetComponent<Image>().sprite = GameObject.Find("VolumeToggleBtn").GetComponent<Button>().spriteState.disabledSprite;
            Debug.Log("vfx volume set to " + myAudioSettings.vfxVolume);
        }
        else
        {
            myAudioSettings.vfxVolume = 1f;
            
            SaveHandler<AudioHandler.AudioSettings>.Save(myAudioSettings, SaveHandler<AudioHandler.AudioSettings>.SaveFileName.audioSettings);
            GameObject.Find("VolumeToggleBtn").GetComponent<Image>().sprite = GameObject.Find("VolumeToggleBtn").GetComponent<Button>().spriteState.selectedSprite;
            Debug.Log("vfx volume set to " + myAudioSettings.vfxVolume);
        }



    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();

        }

    }



}
