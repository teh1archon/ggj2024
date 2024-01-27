using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndPlayer : MonoBehaviour
{
    public VideoPlayer player;
    public Animator animator;
    public AudioClip clip;

    IEnumerator Start()
    {
        player.Play();
        yield return new WaitForSeconds(20);
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        animator.SetTrigger("End");
    }
}
