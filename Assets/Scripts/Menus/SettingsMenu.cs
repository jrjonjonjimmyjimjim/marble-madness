using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menus
{
    /// <summary>
    ///     Define behaviour for the settings screen on the menu for adjusting
    ///     resolutions, volume, etc.
    /// </summary>
    public class SettingsMenu : MonoBehaviour
    {
        public Toggle fullscreenTog;
        public TMP_Dropdown qualityDropdown;

        // TODO: Implement the audio mixer or whatever to make the sound actually
        // change
        // Right now, I think only the slider bar reacts, but doesn't actually do
        // anything
        public AudioMixer audioMixer;
        public Slider volumeSlider;
        public TextMeshProUGUI volumeText;

        public TMP_Dropdown resolutionDropdown;

        public GameObject settingsPanel;
        private float _currentVolume;
        private int _qualityIndex;
        private Resolution[] _resolutions;
        private int _selectedResolution;

        public static SettingsMenu Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        ///     On start, adjust the volume of the game to whatever the value of the slider is,
        ///     and refresh the resolution dropdown
        /// </summary>
        private void Start()
        {
            if (SettingsMenu.Instance == null) return;
            
            UpdateVolume();
            UpdateResolutions();
            UpdateQuality();
        }

        private void UpdateVolume()
        {
            AdjustVolume(volumeSlider.value);
        }

        private void UpdateResolutions()
        {
            // Get the resolutions from the screen and add them to the dropdown
            _resolutions = Screen.resolutions;
            Array.Reverse(_resolutions);
            resolutionDropdown.ClearOptions();
            resolutionDropdown.AddOptions(_resolutions
                .Select(resolution => $"{resolution.width} x {resolution.height} @ {resolution.refreshRate}Hz")
                .ToList()
            );
            resolutionDropdown.RefreshShownValue();

            // Set the current value of the dropdown to whatever resolution we currently have
            for (var i = 0; i < _resolutions.Length; i++)
            {
                if (Screen.currentResolution.width == _resolutions[i].width &&
                    Screen.currentResolution.height == _resolutions[i].height &&
                    Screen.currentResolution.refreshRate == _resolutions[i].refreshRate)
                {
                    resolutionDropdown.value = i;
                }
            }
        }

        private void UpdateQuality()
        {
            // Set the values in the quality dropdown
            var qualityOptions = new List<string> { "Low", "Medium", "High", "Very High", "Ultra" };
            qualityDropdown.AddOptions(qualityOptions);
        }

        /// <summary>
        ///     Give the player the option to click escape to unfocus the settings menu
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) settingsPanel.SetActive(false);
        }

        /// <summary>
        ///     Tweak the text next to the volume slider as the value changes, and
        ///     change the volume of the audio mixer
        /// </summary>
        /// <param name="value"></param>
        public void AdjustVolume(float value)
        {
            volumeText.text = value.ToString(CultureInfo.CurrentCulture);
            // audioMixer.SetFloat("Volume", value);
        }

        /// <summary>
        ///     Change the index of the selected resolution
        /// </summary>
        /// <param name="value"></param>
        public void ChangeSelectedResolution(int value)
        {
            _selectedResolution = value;
        }

        /// <summary>
        ///     Change the quality of the textures based on the selected value
        /// </summary>
        public void ChangeQuality()
        {
            _qualityIndex = qualityDropdown.value;
        }

        /// <summary>
        ///     Apply the graphical changes when the button is pressed
        /// </summary>
        public void ApplyGraphics()
        {
            QualitySettings.SetQualityLevel(_qualityIndex);
            Screen.SetResolution(
                _resolutions[_selectedResolution].width,
                _resolutions[_selectedResolution].height,
                fullscreenTog.isOn
            );
        }
    }
}