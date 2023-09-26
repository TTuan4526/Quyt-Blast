using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutoScroll : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] ScrollRect autoScrollRect;

    [SerializeField] bool ableToAutoScroll = true;

    [SerializeField] float autoScrollSpeed = 1f;

    [SerializeField] float setTimeToAutoScroll = 3;

    private float timeToAutoScroll;

    [SerializeField] float setTimeToReturnToStart = 3;
    private float timeToReturnToStart;

    // Start is called before the first frame update
    void Start()
    {
        if (autoScrollRect == null) autoScrollRect = GetComponent<ScrollRect>();
        timeToAutoScroll = setTimeToAutoScroll;
        timeToReturnToStart = setTimeToReturnToStart;
    }

    // Update is called once per frame
    void Update()
    {
        AutoScrollUpdate();
    }

    void AutoScrollUpdate()
    {
        if (ableToAutoScroll)
        {
            if (ReachedEnd())
            {
                if (timeToReturnToStart > 0)
                {
                    timeToReturnToStart -= Time.deltaTime;
                }
                else
                {
                    autoScrollRect.verticalScrollbar.value = 1;
                    timeToReturnToStart = setTimeToReturnToStart;
                }
            }
            else
            {
                if(timeToAutoScroll > 0)
                {
                    timeToAutoScroll -= Time.deltaTime;
                }
                else
                {
                    autoScrollRect.verticalScrollbar.value -= autoScrollSpeed * Time.deltaTime;
                }
            }
        }
        else
        {
            timeToAutoScroll = setTimeToAutoScroll;
        }
    }

    bool ReachedEnd()
    {
        return autoScrollRect.verticalScrollbar.value <= 0;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ableToAutoScroll = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ableToAutoScroll = true;
    }
}
