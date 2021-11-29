using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.noCompany.Bot_Controller {

    #region Enums

    public enum Colors { Blue, Green, Purple, Red, Silver, Yellow } //TODO: Unused options: 1, 2, 3, 4, 5, 6
    public enum DriveModes { ManualScreen, ManualWorld, Auto, PointClick, GPS } //TODO: Unused options: 1, 2, 3, 4, 5
    public enum CameraModes { TopView, Backwards, Free, AR } //TODO: Unused options: 1, 2, 3, 4

    #endregion

    //TODO: Finish this:
    public class CarController : MonoBehaviour {

        #region Class Variables

        #region Inspector

        [Header("Vehicle Components")]
        public GameObject headLights;
        public GameObject breakLights;
        //TODO: public GameObject buzzer;
        //public GameObject engine; //TODO: For Engine sounds**

        [Header("Shaders")]
        public Material lights;
        public Material chassis; //unused
        public Texture[] pallets = new Texture[6]; //unused

        [Header("Wheels")]
        [Tooltip("Front Left Wheel")]
        public GameObject FLW;
        [Tooltip("Front Right Wheel")]
        public GameObject FRW;
        [Tooltip("Rear Left Wheel")]
        public GameObject RLW;
        [Tooltip("Rear Right Wheel")]
        public GameObject RRW;

        [Header("Driver")]
        [Range(-1, 1)]
        public float steering = 0; //-1 = Left, 1 = Right
        public float direction = 0; //+forward, -backward

        [Header("Settings")]
        public bool lightsOn = false;
        public bool breaking = false;
        [Tooltip("Dont change that value directly! use ToggleEngine instead")]
        public bool engineOn = false;
        public Colors chassiColor = Colors.Red; //unused
        public DriveModes controlMode = DriveModes.ManualScreen; //unused //TODO: will be moved to Main
        public CameraModes cameraMode = CameraModes.Free; //unused //TODO: will be moved to CameraController

        #endregion

        Vector3 wheelsRotation;
        float speed = 0;

        #endregion

        #region MonoBehaviour Callbacks

        //...

        #endregion

        #region Coroutines

        IEnumerator EngineRunning() {

            lights.EnableKeyword("_EMISSION");

            while(engineOn) {

                //Lights
                headLights.SetActive(lightsOn);
                breakLights.SetActive(breaking);

                //Steering
                wheelsRotation.y = Mathf.Lerp(wheelsRotation.y, steering * 30, 0.020f);

                //Movement
                speed = Mathf.Lerp(speed, direction * -1, 0.020f);
                wheelsRotation.z += speed;

                //Wheels Rotation Apply
                FLW.transform.rotation = Quaternion.Euler(wheelsRotation);
                FRW.transform.rotation = Quaternion.Euler(wheelsRotation);
                RLW.transform.rotation = Quaternion.Euler(0, 0, wheelsRotation.z);
                RRW.transform.rotation = Quaternion.Euler(0, 0, wheelsRotation.z);

                yield return null;
            }

            lights.DisableKeyword("_EMISSION");
            headLights.SetActive(false);
            breakLights.SetActive(false);
        }

        #endregion

        #region Other Methods

        [ContextMenu("ToggleEngine")]
        public void ToggleEngine() { //unused

            engineOn = !engineOn;

            if(engineOn) {

                StartCoroutine(EngineRunning());
            }
        }

        public void ToggleBreak() { //unused

            breaking = !breaking;
        }

        public void ToggleHeadLights() { //unused

            lightsOn = !lightsOn;
        }

        /// <summary>
        /// Turn wheels to targetDirection
        /// </summary>
        /// <param name="targetDirection"> -1 for left, 1 for right </param>
        public void Steer(float targetDirection) { //unused

            steering = targetDirection;
        }

        /// <summary>
        /// Spin wheels to targetDirection
        /// </summary>
        /// <param name="targetDirection"> + for forward, - for backward </param>
        public void Move(float targetDirection) { //unused

            direction = targetDirection;
        }

        #endregion
    }
}