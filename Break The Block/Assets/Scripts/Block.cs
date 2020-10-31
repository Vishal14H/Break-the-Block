using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;



    Level level;

    private void Start()
    {
       level = FindObjectOfType<Level>();
       if(tag == "Breakable")
       {
          level.countBreakableBlocks();
       }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit -1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Block Sprite Missing From Array" + gameObject.name);
        }

    }


   private void OnCollisionEnter2D(Collision2D Collision)
   {
       if(tag == "Breakable")
       {
           timesHit++;
           int maxHits = hitSprites.Length +1;
           if(timesHit >= maxHits)
           {
               DestroyBlock();
           }
           else
           {
               ShowNextHitSprite();
           }
       }
   }

   private void DestroyBlock()
   {
      PlayBlockDestroySFX();
       Destroy(gameObject);
       level.BlockDestroyed();
       TriggerSparklesVFX();
   }

   private void PlayBlockDestroySFX()
   {
        FindObjectOfType<GameStatus>().AddToScore();
       AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
       
   }

   private void TriggerSparklesVFX()
   {
       GameObject sparkles = Instantiate(blockSparklesVFX , transform.position , transform.rotation);
       Destroy(sparkles , 1f);

   }
}
