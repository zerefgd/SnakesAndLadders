using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    int roll;

    [SerializeField]
    List<Sprite> die;

    public void RandomImage()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = die[Random.Range(0, die.Count)];
    }

    public void SetImage()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = die[roll - 1];
        GameManager.instance.MovePiece();
    }

    public void Roll(int temp)
    {
        roll = temp;
        Animator animator = GetComponent<Animator>();
        animator.Play("Roll", -1, 0f);
    }

}
