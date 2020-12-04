using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private Statistick _statistick;

    public List<AudioSource> audioS;
    // Start is called before the first frame update
    void Start()
    {
        _statistick = GameObject.Find("Statistick").GetComponent<Statistick>();
    }

    // Update is called once per frame
    void Update()
    {
        /*audioS[0].volume = _statistick.musickVolume;*/


       /* audioS[1].volume = _statistick.effectVolume;
        audioS[2].volume = _statistick.effectVolume;*/
        
    }
}
