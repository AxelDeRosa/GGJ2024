using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject options;
    bool paused;

    AudioSource buttonSound;

    [SerializeField] FadeInFadeOut fade;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        buttonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused) 
                UnPause();
            else
                Pause();
        }
    }

    public void Pause()
    {
        paused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void UnPause()
    {
        paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        options.SetActive(false);
    }

    public void ChangeLevel(string sceneName)
    {
        Time.timeScale = 1;
        fade.HacerFade(0, 1, 1);
        SceneManager.LoadScene(sceneName);
    }

    public void PlaySound()
    {
        buttonSound.Play();
    }
}
