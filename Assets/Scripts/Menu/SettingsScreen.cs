using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;

public class SettingsScreen : MenuScreen {

    public SaveFileName SaveFileName;
    [SerializeField] private Dropdown _resolutionDropdown;
    [SerializeField] private Slider _volumeSlider;
    private Resolution[] _resolutions;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _audioSource;

    void Start() {
        PopulateResolutions();
        LoadSettings();
    }

    public void PopulateResolutions() {
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        List<string> resolutionOptions = new List<string>();

        int currentResIndex = SaveData.Current.ResolutionIndex;

        for (int i = 0; i < _resolutions.Length; i++) {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            resolutionOptions.Add(option);

            if (i == currentResIndex) {
                currentResIndex = i;
            }
        }

        _resolutionDropdown.AddOptions(resolutionOptions);
        _resolutionDropdown.value = currentResIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        SaveData.Current.ResolutionIndex = resolutionIndex;
    }

    public void DeleteSave() {
        string saveFileName = SaveFileName.saveFileName;
        Debug.Log("Save file name: " + saveFileName);
        SerializationManager.Delete(Application.persistentDataPath + "/saves/" + saveFileName + ".save");
    }

    public void SetVolume(float volume) {
        _audioMixer.SetFloat("volume", volume);
        SaveData.Current.Volume = volume;
        Debug.Log(SaveData.Current.Volume);
    }

    public void SetFullscreen(bool isFullscreen) {
        _audioSource.Play();
        Screen.fullScreen = !Screen.fullScreen;
        isFullscreen = Screen.fullScreen;
        SaveData.Current.IsFullscreen = isFullscreen;
        Debug.Log(SaveData.Current.IsFullscreen);
    }

    public void SaveChanges() {
        _audioSource.Play();
        string saveFileName = SaveFileName.saveFileName;
        SerializationManager.Save(saveFileName, SaveData.Current);
    }

    public void LoadSettings() {
        string saveFileName = SaveFileName.saveFileName;

        if (SerializationManager.Load(Application.persistentDataPath + "/saves/" + saveFileName + ".save") is SaveData savedData) {
            _resolutionDropdown.value = savedData.ResolutionIndex;
            SetResolution(savedData.ResolutionIndex);
            SetVolume(savedData.Volume);
            _volumeSlider.value = savedData.Volume;
            
            //SetFullscreen(savedData.IsFullscreen);
        }
    }

    new void OnShow() {

    }

    new void OnHide() {

    }
}
