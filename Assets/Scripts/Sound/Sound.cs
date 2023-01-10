using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _final;
    [SerializeField] private AudioSource _givenAwayItem;
    [SerializeField] private AudioSource _pickUpItem;
    [SerializeField] private AudioSource _upgrade;

    private void Start()
    {
        _music.Play();
    }

    public void PlayGivenAwayItem()
    {
        _givenAwayItem.Play();
    }

    public void PlayFinal()
    {
        _music.Stop();
        _final.Play();
    }

    public void PlayUpgrade()
    {
        _upgrade.Play();
    }

    public void PlayPickUpItem()
    {
        _pickUpItem.Play();
    }
}
