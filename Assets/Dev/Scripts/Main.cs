using UnityEngine;

namespace com.noCompany.Bot_Controller {

    #region Enums

    public enum DriveModes { ManualScreen, ManualWorld, Auto, PointClick, GPS } //TODO: Unused options: 1, 2, 3, 4, 5 

    #endregion

    //TODO: Execute all backcode and control the remote car
    public class Main : MonoBehaviour {

        #region Singleton

        public static Main Instance { get; private set; }

        #endregion

        #region Class Variables

        #region Inspector

        [Header("Settings")]
        public DriveModes controlMode = DriveModes.ManualScreen; //unused
        public bool avoidCollisions = false; //unused

        [Tooltip("Avoid rc to lost signal by drespassing the signal range")]
        public bool avoidSignalBarrier = true; //unused

        [Header("Connection Settings")]
        public bool autoConnect = false; //unused

        [Tooltip("Connect to rc periodicaly for checking status of rc battery (can consumes more battery of device)")]
        public bool rcBackgroundBatteryCheck = false; //unused

        [Tooltip("if true, refleshRate will be auto adjusted acordly to battery of device or/and rc")]
        public bool adaptiveRefleshRate = false; //unused

        [Tooltip("Number of updates per seconds, high values make commands more responsible at a cost of battery")]
        public float refleshRate = 30; //unused //TODO: Need Tests

        [Tooltip("Max response delay (seconds), if no response are received in that time, the rc will start 'panic' mode")]
        public float maxDelay = 0.300f; //unused

        [Tooltip("Max connection delay (seconds), if the connection timed exceeds that time, the connection will be dropped")]
        public float maxConnectionDelay = 0.750f; //unused

        #endregion

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake() {
            
            if(Instance == null) {

                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else {

                Debug.LogError("Multiple Main instances detected, use only one!");
                Destroy(this);
            }
        }

        private void Start() {
            
            //App Start...
            //TODO: Bluetooth connection, discover and comunication
        }

        #endregion

        #region Other Methods

        //...

        #endregion
    }
}