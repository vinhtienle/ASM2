using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class voliu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField]  Slider slider;


    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void changvolue()
    {
        AudioListener.volume = slider.value;
        save();
    }
    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void save ()
    {
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }
}
