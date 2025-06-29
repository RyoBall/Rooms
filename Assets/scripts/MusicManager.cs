using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> bgms;
    public AudioSource BgmPlayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyGeneratorController.instance.EnterAction += ChangeFightBgm;
        enemyGeneratorController.instance.ExitAction += ChangeExploreBgm;
        BgmPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeFightBgm() 
    {
        BgmPlayer.clip = bgms[1];
        BgmPlayer.Play();
    }    
    void ChangeExploreBgm() 
    {
        BgmPlayer.clip = bgms[0];   
        BgmPlayer.Play();
    }
}
