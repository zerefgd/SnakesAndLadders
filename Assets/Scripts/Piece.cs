using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    [SerializeField]
    List<Color> colors;

    bool canMove;
    int moveIndex;
    List<int> movePos;
    float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        moveIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        float step = speed * Time.deltaTime;
        Vector3 targetPos = GameManager.instance.positions[movePos[moveIndex]];
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if(Vector3.Distance(transform.position,targetPos) < 0.001f)
        {
            moveIndex++;
            if(moveIndex == movePos.Count)
            {
                moveIndex = 0;
                canMove = false;
            }
        }
    }

    public void SetColors(Player player)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = colors[(int)player];
    }

    public void SetMovement(List<int> result)
    {
        movePos = result;
        canMove = true;
    }
}
