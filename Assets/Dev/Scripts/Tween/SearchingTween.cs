using System;
using UnityEngine;
using UnityEngine.UI;

namespace com.noCompany.Bot_Controller {

    //TODO: Connection events handle before this
    public class SearchingTween : MonoBehaviour {

        #region Class Variables

        #region Inspector

        [Header("Tween Components")]
        public GameObject obj1; //unused
        public GameObject obj2; //unused

        #endregion

        float scale1 = 0;
        float scale2 = 0;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        private void Start() {

            if(obj1 == null || obj2 == null)
                throw new NullReferenceException("Missing tween objects in SearchingTween.cs");
        }

        // Update is called once per frame
        private void Update() {

            if(scale2 < 1) {

                float delta = Time.deltaTime;

                scale1 = (scale1 < 1) ? scale1 + delta * 2 : 1;
                scale2 += delta * 1.5f;
            }
            else {

                scale1 = 0;
                scale2 = 0;
            }

            obj1.transform.localScale = new Vector2(scale1, scale1);
            obj2.transform.localScale = new Vector2(scale2, scale2);
        }

        #endregion

        #region Other Functions

        //...

        #endregion
    }
}
