using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
   
   private static SoundManager instance;

   private void Awake() {
   
        if (instance == null) {

            instance = this;
            // for giving the instance, not destroying on load
            DontDestroyOnLoad(instance);

        } else {

            Destroy(gameObject);

        }
   }

}
