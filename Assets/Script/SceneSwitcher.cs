using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    public int sceneIndexDestination;

    public void OnPointerClick(PointerEventData e)
    {
        changeScene();
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneIndexDestination);
    }
}
