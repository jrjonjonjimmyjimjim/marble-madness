using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
///     Define behaviour for the settings screen on the menu for adjusting resolutions, volume, etc.
/// </summary>
public class SettingsMenu : MonoBehaviour
{
    public Toggle fullscreenTog;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;

    // TODO: Implement the audio mixer or whatever to make the sound actually change
    // Right now, I think only the slider bar reacts, but doesn't actually do anything
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    private readonly List<ResItem> _resolutions = new()
    {
        new ResItem(1920, 1080),
        new ResItem(1280, 720),
        new ResItem(854, 480)
    };

    private float _currentVolume;

    // TODO: find a way to NOT hardcode these values
    // TODO: If we change the resolution, then everything fucks up because the
    // all of the panels, buttons, etc. were placed with absolute values, not relative so fix that
    private int _selectedResolution;

    /// <summary>
    ///     On start, adjust the volume of the game to whatever the value of the slider is,
    ///     and refresh the resolution dropdown because we are dynamically setting it here
    /// </summary>
    private void Start()
    {
        AdjustVolume(volumeSlider.value);

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(_resolutions.Select(x => $"{x.Width}x{x.Height}").ToList()
        );

        resolutionDropdown.value = 0;
        resolutionDropdown.RefreshShownValue();

        ApplyGraphics();
    }

    /// <summary>
    ///     Tweak the text next to the volume slider as the value changes, and
    ///     change the volume of the audio mixer
    /// </summary>
    /// <param name="value"></param>
    public void AdjustVolume(float value)
    {
        volumeText.text = value.ToString(CultureInfo.CurrentCulture);
        audioMixer.SetFloat("Volume", value);
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
        QualitySettings.SetQualityLevel(qualityDropdown.value);
    }

    /// <summary>
    ///     Apply the graphical changes when the button is pressed
    /// </summary>
    public void ApplyGraphics()
    {
        Screen.SetResolution(_resolutions[_selectedResolution].Width,
            _resolutions[_selectedResolution].Height,
            fullscreenTog.isOn);
    }
}

/// <summary>
///     An object that encapsulates resolutions in pixel
/// </summary>
[Serializable]
public class ResItem
{
    public ResItem(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Height { get; set; }
    public int Width { get; set; }
}