using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CanvasGroup blackPanel;
    public CanvasGroup Ptext;
    public GameObject PausePanel;
    public GameObject Basses;
    public GameObject parenting;
    public Image MusicUI;
    public Image SoundUI;
    public Sprite MusicOff;
    public Sprite MusicOn;
    public Sprite SoundOff;
    public Sprite SoundOn;

    bool inside;
    public void BfadeIn(float time)
    {
        blackPanel.DOFade(1, time);
    }
    public void BfadeOut(float time)
    {
        blackPanel.DOFade(0, time);
    }
    public void PfadeIn(float time)
    {
        Ptext.DOFade(.4f, time);
    }
    public void PfadeOut(float time)
    {
        Ptext.DOFade(.15f, time);
    }
    public void Start()
    {
        PlayerPrefs.SetInt("Music", 0);
        PlayerPrefs.SetInt("Sound", 0);
        if(MusicUI != null)
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                MusicUI.sprite = MusicOff;
            }
            else if (PlayerPrefs.GetInt("Music") == 1)
            {
                MusicUI.sprite = MusicOn;
            }
        }
        if(SoundUI != null)
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                SoundUI.sprite = SoundOff;
            }
            else if (PlayerPrefs.GetInt("Sound") == 1)
            {
                SoundUI.sprite = SoundOn;
            }
        }

        if (PausePanel != null)
        {
            foreach (RectTransform t in PausePanel.transform)
            {
                t.DOScale(Vector3.zero, .01f);
                t.gameObject.SetActive(false);
            }
        }
        
        inside = false;

        if (Basses != null)
        {
            foreach (Transform tt in Basses.transform)
            {
                tt.DOScale(Vector3.zero, .01f);
                tt.gameObject.SetActive(false);
            }
        }

        
        StartCoroutine(wait());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inside)
            {
                Time.timeScale = 1;
                foreach (RectTransform t in PausePanel.transform)
                {
                    t.DOScale(Vector3.zero, .3f);
                }
                inside = false;
            }
            else
            {
                foreach (RectTransform t in PausePanel.transform)
                {
                    t.gameObject.SetActive(true);
                    t.DOScale(Vector3.one,.3f);
                }
                StartCoroutine(WaitT());
            }

        }
    }
    public void GoToBase()
    {
        Basses.transform.SetParent(parenting.transform);
        foreach (Transform t in Basses.transform)
        {
            StartCoroutine(waitb(t.gameObject));
        }
    }
    public void Restart()
    {
        StartCoroutine(waitR());
    }
    public void Music()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            MusicUI.sprite = MusicOn;
            PlayerPrefs.SetInt("Music", 1);
        }
        else if (PlayerPrefs.GetInt("Music") == 1)
        {
            MusicUI.sprite = MusicOff;
            PlayerPrefs.SetInt("Music", 0);
        }
    }
    public void Sound()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            SoundUI.sprite = SoundOn;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else if (PlayerPrefs.GetInt("Sound") == 1)
        {
            SoundUI.sprite = SoundOff;
            PlayerPrefs.SetInt("Sound", 0);
        }
    }
    IEnumerator wait()
    {
        PfadeIn(.4f);
        yield return new WaitForSeconds(.4f);
        PfadeOut(.4f);
        yield return new WaitForSeconds(.4f);
        StartCoroutine(wait());
    }
    IEnumerator WaitT()
    {
        yield return new WaitForSeconds(.3f);
        Time.timeScale = 0;
        inside = true;
    }
    IEnumerator waitb(GameObject t)
    {
        Time.timeScale = 1;
        t.gameObject.SetActive(true);
        t.transform.DOScale(new Vector3(2, .7f), .2f);
        yield return new WaitForSeconds(.2f);
    }
    IEnumerator waitR()
    {
        Time.timeScale = 1;
        BfadeIn(.4f);
        yield return new WaitForSeconds(.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
