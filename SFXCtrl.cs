using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour
{
    public static SFXCtrl instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ShowAttackParticle(Vector3 pos, GameObject sfxType)
    {
        GameObject sfx = Instantiate(sfxType, pos, Quaternion.identity);
        ParticleSystem parts = sfx.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetimeMultiplier;
        Destroy(sfx, totalDuration);
    }

}
