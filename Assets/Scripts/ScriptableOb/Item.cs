using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    public ItemFunction type;
    public Suitpiece piece;
    public SuitState state;
    public AudioClip pickupVoicline;
    public float volume = 1f;

    public void PlayVoiceline(AudioSource audioSource)
    {
        audioSource.PlayOneShot(pickupVoicline, volume);
    }
}




public enum ItemFunction
{
    Tool,
    Suit
}

public enum Suitpiece
{
    Tool,
    Cloth,
    Boots,
    Bottles,
    Helmet
}

public enum SuitState
{
    Broken,
    Fixed
}
