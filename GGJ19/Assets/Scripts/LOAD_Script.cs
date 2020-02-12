using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LOAD_Script : MonoBehaviour {
    

    public void StartLoading(Slider slider, Text progressText, int scene) {
        StartCoroutine(LoadAsync(slider, progressText, scene));
        slider.value = 0;
        progressText.text = "0 %";
    }

    IEnumerator LoadAsync(Slider slider, Text progressText, int scene) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        operation.allowSceneActivation = false;

        Debug.Log("Vou carragar o ... " + scene);

        float loadPercent = 0;

        while (loadPercent < 100) {
            //slider.value = loadPercent;

            slider.DOValue(loadPercent, 0.5f);
            progressText.text = loadPercent.ToString("0") + " %";
            loadPercent += Random.Range(6.80f, 15.5f);
            //loadPercent = operation.progress;
            yield return new WaitForSeconds(0.35f);
        }

        slider.DOValue(100, 0.5f);
        progressText.text = "100 %";
        yield return new WaitForSeconds(0.5f);
        operation.allowSceneActivation = true;
        //SceneManager.LoadScene(LOAD_SCENE.sceneToLoad);

        yield return null;
    }
}
