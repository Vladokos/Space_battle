using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private PlayerControllers _playerControllers;
    private Statistick _statistick;
    private MusicManager _musicManager;


    public List<Button> _Buttons;

    public RawImage pauseImage;

    public GameObject settings;

    public List<Slider> sliders;
    private float musVolume;
    private float effectsVolume;

    public List<GameObject> controls;
    public bool _controls = true;
    void Start()
    {
        _playerControllers = GameObject.Find("Player").GetComponent<PlayerControllers>();
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();
        _musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();

        sliders[0].value = _statistick.musickVolume;
        sliders[1].value = _statistick.effectVolume;

        Control();
    }
    //делает не активной кнопку паузы и активными кнопки меню паузы
    public void PauseButton()
    {
        _playerControllers.restartButton.gameObject.SetActive(true);
        _playerControllers._gameOver = true;

        _Buttons[1].gameObject.SetActive(false);

        pauseImage.gameObject.SetActive(true);

        _Buttons[0].gameObject.SetActive(true);
        _Buttons[3].gameObject.SetActive(true);
        _Buttons[4].gameObject.SetActive(true);
    }
    //Делает не активными кнопки меню паузы и активным кнопку меню
    public void Resum()
    {
        _playerControllers.restartButton.gameObject.SetActive(false);
        _playerControllers._gameOver = false;

        _Buttons[1].gameObject.SetActive(true);

        pauseImage.gameObject.SetActive(false);

        _Buttons[0].gameObject.SetActive(false);
        _Buttons[3].gameObject.SetActive(false);
        _Buttons[4].gameObject.SetActive(false);
    
    }
    //Загружает сцену меню
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    //Делает активным настройки
    public void SettingsBtn()
    {
        settings.gameObject.SetActive(true);
        foreach(Button sB in _Buttons )
        {
            sB.gameObject.SetActive(false);
        }
    }
    //Слайдер музыки
    public void MusicSlider()
    {
        musVolume = sliders[0].value;
        _musicManager.audioS[0].volume = musVolume;
        _statistick.musickVolume = musVolume;
    }
    //Слайдер эффектов
    public void EffectSlider()
    {
        effectsVolume = sliders[1].value;
        _musicManager.audioS[1].volume = effectsVolume;
        _musicManager.audioS[2].volume = effectsVolume;
        _statistick.effectVolume = effectsVolume;
    }


    //Кнопка закрытия настроек 
    public void closeBtn()
    {
        settings.gameObject.SetActive(false);
        foreach (Button sB in _Buttons)
        {
            sB.gameObject.SetActive(true);
        }
        _Buttons[1].gameObject.SetActive(false);
    } 

    private void Control()
    {
        if(_statistick.stick == true)
        {
            GameObject.Find("Arrow").gameObject.SetActive(false);
        }
        else
        {
            GameObject.Find("Fixed Joystick").gameObject.SetActive(false);
        }
    }
    public void Stick()
    {
        controls[0].gameObject.SetActive(false);
        controls[1].gameObject.SetActive(true);
        _controls = true;
        _statistick.stick = true;
    }
    public void Arrow()
    {
        controls[0].gameObject.SetActive(true);
        controls[1].gameObject.SetActive(false);
        _controls = false;
        _statistick.stick = false;
    }
    public void VisibleButton()
    {

    }
}
