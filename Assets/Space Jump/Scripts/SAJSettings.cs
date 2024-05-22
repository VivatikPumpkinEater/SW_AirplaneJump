using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SAJ.Scripts
{
    public class SAJSettings : MonoBehaviour
    {
        [SerializeField] private Button SAJOpen;
        [SerializeField] private Button SAJClose;
        [SerializeField] private CanvasGroup SAJSettingsPanel;
        [SerializeField] private CanvasGroup SAJRules;
        [SerializeField] private CanvasGroup SAJMenu;
        [SerializeField] private Button SAJExit;
        [SerializeField] private Button SAJOpenRules;
        [SerializeField] private Button SAJCloseRules;

        [SerializeField] private AudioSource SajSource;
        
        public Button SAjMusic;
        public TMP_Text SAjMusicTxt;
        public Button SAjSound;
        public TMP_Text SAjSoundTxt;
        
        private void Awake()
        {
            SajSource = FindObjectOfType<AudioSource>();
            
            SAJOpen.onClick.AddListener(() =>
            {
                SAJStatic.SAJIgnore = true;
                SAJMenu.SAJRep(false);
                SAJSettingsPanel.SAJRep(true);
            });
            SAJClose.onClick.AddListener(Cloas);
            SAJOpenRules.onClick.AddListener(() =>
            {
                SAJStatic.SAJIgnore = true;
                SAJMenu.SAJRep(false);
                SAJRules.SAJRep(true);
            });
            SAJCloseRules.onClick.AddListener(Cloas);
            
            Cloas();

            SAJExit.onClick.AddListener(Application.Quit);
            
            SAjMusic.onClick.AddListener(ChangeMusic);
            SAjSound.onClick.AddListener(ChangeSound);
            
            var msc = PlayerPrefs.GetInt("SAJMusic", 1);
            if (msc < 0)
            {
                SAjMusicTxt.text = "Music <color=red>OFF</color>";
                SajSource.loop = false;
                SajSource.Stop();
            }
            else
            {
                SAjMusicTxt.text = "Music <color=green>ON</color>";
                SajSource.loop = true;
                SajSource.Play();
            }
            
            var snd = PlayerPrefs.GetInt("SAJSound", 1);
            SAJStatic.SAJSound = snd > 0;
            SAjSoundTxt.text = snd > 0 ? "Sound <color=green>ON</color>" : "Sound <color=red>OFF</color>";

            return;
            
            void Cloas()
            {
                SAJStatic.SAJIgnore = false;
                SAJSettingsPanel.SAJRep(false);
                SAJRules.SAJRep(false);
                SAJMenu.SAJRep(true);
            }

            void ChangeMusic()
            {
                var msc = PlayerPrefs.GetInt("SAJMusic", 1);
                msc *= -1;
                PlayerPrefs.SetInt("SAJMusic", msc);

                if (msc < 0)
                {
                    SAjMusicTxt.text = "Music <color=red>OFF</color>";
                    SajSource.loop = false;
                    SajSource.Stop();
                }
                else
                {
                    SAjMusicTxt.text = "Music <color=green>ON</color>";
                    SajSource.loop = true;
                    SajSource.Play();
                }
            }
            
            void ChangeSound()
            {
                var snd = PlayerPrefs.GetInt("SAJSound", 1);
                snd *= -1;
                PlayerPrefs.SetInt("SAJSound", snd);
                
                SAJStatic.SAJSound = snd > 0;
                
                SAjSoundTxt.text = snd > 0 ? "Sound <color=green>ON</color>" : "Sound <color=red>OFF</color>";
            }
        }
    }

    public static class SAJStatic
    {
        public static bool SAJSound;
        public static bool SAJIgnore;

        public static void SAJRep(this CanvasGroup saj, bool sajval)
        {
            saj.interactable = sajval;
            saj.blocksRaycasts = sajval;
            saj.alpha = sajval ? 1 : 0;
        }
    }
}