using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Meta.Panels
{

    public class RestartScene : MonoBehaviour
    {

        [SerializeField] private string sceneName;
        [SerializeField] private ButtonWrapper button;

        private void OnEnable()
        {
            button.AddListener(Restart);
        }

        private void OnDisable()
        {
            button.RemoveListener();
        }

        private void Restart()
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            }
        }

    }

}