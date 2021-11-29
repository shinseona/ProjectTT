using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeManager : MonoBehaviour
{

    public void FadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(fadeOutTime, nextEvent));
    }

    public void FadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeOutTime, nextEvent));
    }

    // 투명 -> 불투명
    IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        Image sr = this.gameObject.transform.GetChild(0).GetComponent<Image>();
        Color tempColor = sr.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;

            yield return null;
        }

        sr.color = tempColor;
        if (nextEvent != null) nextEvent();
    }

    // 불투명 -> 투명
    IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        Image sr = this.gameObject.transform.GetChild(0).GetComponent<Image>();
        Color tempColor = sr.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return new WaitForSecondsRealtime(0);
        }
        sr.color = tempColor;
        if (nextEvent != null) nextEvent();
    }
    public IEnumerator FadeInActiveate(FadeManager fader,string SceneName)
    {
        fader.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        fader.FadeIn(0.6f, () => { SceneManager.LoadScene(SceneName); });
        yield return null;
    }
    public IEnumerator FadeOutActiveate(FadeManager fader)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = 1;
        fader.FadeOut(1f);
        yield return new WaitForSeconds(1.0f);
        fader.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //float elapsedTime = 0f;
        //float duration = 3f;

        //while (elapsedTime < duration)
        //{
        //    yield return 0;
        //    elapsedTime += Time.unscaledDeltaTime;
        //}

    }
}