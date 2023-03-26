using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Menus
{
    public class SettingsMenuOptions : MonoBehaviour
    {
        public static SettingsMenuOptions instance;

        // TODO: Connect the audio source to make the volume slider responsive
        // public AudioSource AudioSource { get; set; }
        public float CurrentVolume { get; set; }
        public List<string> QualityOptions { get; private set; }
        public int QualityIndex { get; set; }
        public Resolution[] Resolutions { get; private set; }
        public List<string> ResolutionsString { get; private set; }
        public int SelectedResolution { get; set; }

        /// <summary>
        ///     Enforce a singleton pattern for the settings menu
        ///     <see>
        ///         <cref>https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#634f8281edbc2a65c86270cb</cref>
        ///     </see>
        /// </summary>
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            // Set all resolutions and find the current resolution
            Resolutions = Screen.resolutions;
            Array.Reverse(Resolutions);
            ResolutionsString = Resolutions.Select(resolution =>
                $"{resolution.width}x{resolution.height} @{resolution.refreshRate}hz").ToList();

            foreach (var (current, i) in
                     Resolutions.Select((current, i) => (current, i)))
                if (Screen.currentResolution.width == current.width &&
                    Screen.currentResolution.height == current.height &&
                    Screen.currentResolution.refreshRate == current.refreshRate)
                {
                    SelectedResolution = i;
                    break;
                }

            Screen.SetResolution(Resolutions[SelectedResolution].width, Resolutions[SelectedResolution].height, true);

            // Set all quality options
            QualityOptions = new List<string> { "Ultra", "Very High", "High", "Medium", "Low" };
            QualityIndex = 0;

            // Set the default volume to 100
            CurrentVolume = 100;

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}