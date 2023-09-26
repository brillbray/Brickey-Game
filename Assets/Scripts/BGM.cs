using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private static BGM BgmMusic;

    void Awake()
    {
        if (BgmMusic == null )
        {
            BgmMusic = this;
            DontDestroyOnLoad(BgmMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

  
}
