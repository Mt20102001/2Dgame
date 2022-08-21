using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    public static MainMusic mainmusic;
    // Start is called before the first frame update
    private void Awake(){
        if(mainmusic != null && mainmusic != this){
            Destroy(this.gameObject);
            return;
        }
        mainmusic = this;
        DontDestroyOnLoad(this);
    }
}
