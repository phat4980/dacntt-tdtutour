using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneCoroutine(sceneIndex));
    }

    IEnumerator GoToSceneCoroutine(int sceneIndex)
    {
        yield return new WaitForSeconds(2.5f);
        // Load selected scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

        public void GoToSceneAsync(int sceneIndex)
    {
        StartCoroutine(GoToSceneAsyncCoroutine(sceneIndex));
    }

    IEnumerator GoToSceneAsyncCoroutine(int sceneIndex)
    {
        yield return new WaitForSeconds(2.5f);
        // Load selected scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        while(timer < 2.5f && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        operation.allowSceneActivation = true;

    }
}
