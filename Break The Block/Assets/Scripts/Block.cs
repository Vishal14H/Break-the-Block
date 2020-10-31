using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    Level level;

    private void Start()
    {
       level = FindObjectOfType<Level>();
       level.countBreakableBlocks();
    }


   private void OnCollisionEnter2D(Collision2D Collision)
   {
      DestroyBlock();
   }

   private void DestroyBlock()
   {
       FindObjectOfType<GameStatus>().AddToScore();
       AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
       Destroy(gameObject);
       level.BlockDestroyed();
   }
}
