using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine.EventSystems;

public class Worm : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image hole;
    [SerializeField] RectTransform worm;
    [SerializeField] float startPos;
    [SerializeField] float endPos;
    [SerializeField] GameObject bubble;
    [SerializeField] TextMeshProUGUI wordText;
    [SerializeField] Collider2D wormCollider;
    Action OnHit;
    Action OnMiss;
    Coroutine anim;

    private void Start()
    {
        hole.DOFade(0, 0);
        worm.DOAnchorPosY(startPos, 0);
        bubble.SetActive(false);
    }

    public void SetWord(string word, bool isGood, Action onHit, Action onMiss = null)
    {
        wordText.text = word;
        wormCollider.enabled = false;
        OnHit = onHit;
        OnMiss = onMiss;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Appear();
    }

    public void Appear(float holeTime = 0.1f, float showTime = 1, float waitTime = 1f)
    {
        hole.DOFade(1, holeTime).OnComplete(() => SlideUp());

        void SlideUp()
        {
            worm.DOAnchorPosY(endPos, showTime).OnComplete(() => OnEndSide());
        }

        void OnEndSide()
        {
            wormCollider.enabled = true;
            bubble.SetActive(true);
            anim = StartCoroutine(WaitForHit(waitTime));
        }
    }

    IEnumerator WaitForHit(float waitTime = 1f) 
    { 
        yield return new WaitForSeconds(waitTime);
        bubble.SetActive(false);
        GoAway(waitTime / 2);
        OnMiss?.Invoke();
    }

    //got hit
    public void GoAway(float disappearTime = 0.2f)
    {
        wormCollider.enabled = false;
        worm.DOAnchorPosY(startPos, disappearTime).OnComplete(() => Destroy(this.gameObject, 0.1f));

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (anim != null)
            StopCoroutine(anim);
        OnHit?.Invoke();
        GoAway();
    }
}
