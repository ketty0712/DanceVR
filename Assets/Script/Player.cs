using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int StageIndex = 0;
    public static int LightingIndex = 0;
    public static int MusicIndex = 0;
    public static int ModeIndex = 0;

    public static float MusicVolume = 1.0f;
    public static float SoundEffectVolume = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetIndex(int index)
    {
        switch(index)
        {
            case 0:
                return LightingIndex;
            case 1:
                return StageIndex;
            case 2:
                return MusicIndex;
            case 3:
                return ModeIndex;
            default:
                return -1;
        }
    }

}
