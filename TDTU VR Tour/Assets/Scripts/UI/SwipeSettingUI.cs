using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeSettingUI : MonoBehaviour, IEndDragHandler
{
    private Vector3 tagretPos;
    private int currentPage;
    private  int dragThreshold;
    [SerializeField] private int maxPage;
    [SerializeField] private Vector3 pageStep;
    [SerializeField] private RectTransform buildingPagesRect;
    [SerializeField] private float timeScroll;
    [SerializeField] private LeanTweenType animType;
    [SerializeField] private Button leftButton, rightButton;

    private void Awake() {
        currentPage = 1;
        tagretPos = buildingPagesRect.localPosition;
        dragThreshold = Screen.width /20;
        blurButton();
    }
    public void ScrollLeft() {
        if (currentPage > 1) {
            currentPage--;
            tagretPos -= pageStep;
            movePage();
        }
    }
    public void ScrollRight() {
        if (currentPage < maxPage) {
            currentPage++;
            tagretPos +=  pageStep;
            movePage();
        }
    }
    private void movePage() {
        buildingPagesRect.LeanMoveLocal(tagretPos, timeScroll).setEase(animType);
        blurButton();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshold) {
            if(eventData.position.x > eventData.pressPosition.x) {
                ScrollLeft();
            } else {
                ScrollRight();
            }
        } else {
            movePage();
        }
    }

    private void blurButton() {
        leftButton.interactable = true;
        rightButton.interactable = true;
        if(currentPage == 1) {
            leftButton.interactable = false;
        } else if(currentPage == maxPage) {
            rightButton.interactable = false;
        }
    }
}
