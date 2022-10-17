using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Meta.Global;

namespace Meta.VR
{

    public class EditorModeSetup : MonoBehaviour
    {

        [SerializeField] private GameObject ovrCameraRig;
        [SerializeField] private StandaloneInputModule standaloneInputModule;
        [SerializeField] private bool addEditorController = false;

        private SimpleCameraController cameraController;

        private IEnumerator Start()
        {
            bool isEditor = !OVRManager.isHmdPresent;
            standaloneInputModule.enabled = isEditor;
            yield return new WaitForEndOfFrame();
            if (isEditor && addEditorController)
                cameraController = ovrCameraRig.AddComponent<SimpleCameraController>();
        }

        public void SetActive(bool isActive)
        {
            if (cameraController != null)
                cameraController.enabled = isActive;
        }

    }

}