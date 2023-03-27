using System.Globalization;
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
        public AudioMixer audioMixer; // TODO connect this
        public Slider volumeSlider;
        public TextMeshProUGUI volumeText;
        public TMP_Dropdown resolutionDropdown;
        public GameObject settingsPanel;

        /// <summary>
        ///     On start, adjust the volume of the game to whatever the value of the slider is,
        ///     and refresh the resolution dropdown
        /// </summary>
        private void Start()
        {
            UpdateVolume();
            UpdateResolutions();
            UpdateQuality();
        }

        /// <summary>
        ///     Give the player the option to click escape to unfocus the settings menu
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) settingsPanel.SetActive(false);
        }

        /// <summary>
        ///     Adjust the slider when the settings menu is created
        /// </summary>
        private void UpdateVolume()
        {
            AdjustVolume(SettingsMenuOptions.instance.CurrentVolume);
        }

        /// <summary>
        ///     Fill in the resolution dropdown box
        /// </summary>
        private void UpdateResolutions()
        {
            // Get the resolutions from the screen and add them to the dropdown
            resolutionDropdown.ClearOptions();
            resolutionDropdown.AddOptions(
                SettingsMenuOptions.instance.ResolutionsString
            );

            // Set the current value of the dropdown to whatever resolution we currently have
            resolutionDropdown.value = SettingsMenuOptions.instance.SelectedResolution;
        }

        /// <summary>
        ///     Fill in the quality dropdown box
        /// </summary>
        private void UpdateQuality()
        {
            // Set the values in the quality dropdown
            qualityDropdown.AddOptions(SettingsMenuOptions.instance.QualityOptions);
            qualityDropdown.value = SettingsMenuOptions.instance.QualityIndex;
        }

        /// <summary>
        ///     Tweak the text next to the volume slider as the value changes, and
        ///     change the volume of the audio mixer
        /// </summary>
        /// <param name="value"></param>
        public void AdjustVolume(float value)
        {
            volumeText.text = value.ToString(CultureInfo.CurrentCulture);
            SettingsMenuOptions.instance.CurrentVolume = volumeSlider.value = value;
        }

        /// <summary>
        ///     Change the index of the selected resolution
        /// </summary>
        /// <param name="value"></param>
        public void ChangeSelectedResolution(int value)
        {
            SettingsMenuOptions.instance.SelectedResolution = value;
        }

        /// <summary>
        ///     Change the quality of the textures based on the selected value
        /// </summary>
        public void ChangeQuality(int value)
        {
            SettingsMenuOptions.instance.QualityIndex = value;
        }

        /// <summary>
        ///     Apply the graphical changes when the button is pressed
        /// </summary>
        public void ApplyGraphics()
        {
            QualitySettings.SetQualityLevel(SettingsMenuOptions.instance.QualityIndex);
            Screen.SetResolution(
                SettingsMenuOptions.instance.Resolutions[SettingsMenuOptions.instance.SelectedResolution].width,
                SettingsMenuOptions.instance.Resolutions[SettingsMenuOptions.instance.SelectedResolution].height,
                fullscreenTog.isOn
            );
            Application.targetFrameRate = SettingsMenuOptions.instance
                .Resolutions[SettingsMenuOptions.instance.SelectedResolution].refreshRate;
        }
    }
}