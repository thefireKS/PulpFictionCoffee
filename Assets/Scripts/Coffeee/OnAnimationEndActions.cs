using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationEndActions : MonoBehaviour
{
    [SerializeField] private SpriteRenderer downPart;
    [SerializeField] private SpriteRenderer cupPart;
    [Space(5)]
    [SerializeField] private Sprite downPartWithWater;
    [SerializeField] private Sprite downPartWithCoffee;
    [Space(5)] 
    [SerializeField] private Sprite cupWithCoffee;
    [SerializeField] private Sprite cupWithCream;
    [SerializeField] private Sprite cupWithMilk;
    [Space(5)] 
    [SerializeField] private Transform cup;
    [SerializeField] private Vector3 cupPosition;
    [Space(5)] 
    [SerializeField] private Transform milk;
    [SerializeField] private SpriteRenderer milkSpriteRenderer;
    [SerializeField] private Sprite emptyMilk;
    [SerializeField] private Vector3 milkPosition;
    [SerializeField] private Vector3 milkScale;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void pourWater()
    {
        downPart.sprite = downPartWithWater;
        _animator.enabled = false;
    }

    public void addCoffee()
    {
        downPart.sprite = downPartWithCoffee;
        _animator.enabled = false;
    }

    public void setCupPosition()
    {
        cup.position = cupPosition;
        _animator.enabled = false;
    }

    public void pourCoffee()
    {
        cupPart.sprite = cupWithCoffee;
        _animator.enabled = false;
    }

    public void pourCream()
    {
        cupPart.sprite = cupWithCream;
        _animator.enabled = false;
    }

    public void pourMilk()
    {
        cupPart.sprite = cupWithMilk;
        _animator.enabled = false;
    }

    public void setEmptyMilkOnPlace()
    {
        milk.position = milkPosition;
        milk.localScale = milkScale;
        milkSpriteRenderer.sprite = emptyMilk;
        milkSpriteRenderer.sortingOrder = -1;
    }

    public void doneOnAnythingElse()
    {
        _animator.enabled = false;
    }
}
