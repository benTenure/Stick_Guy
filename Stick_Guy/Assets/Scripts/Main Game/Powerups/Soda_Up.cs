using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda_Up : MonoBehaviour
{
    private PlayerInteractions player;
    public HealthBarScript hb;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            player = col.gameObject.GetComponent<PlayerInteractions>();
            
            if(player.playerLives < 4)
            {
                player.playerLives++;
                hb.ChangeHealth(player.playerLives);
            }
        }
       this.gameObject.SetActive(false);
    }
}
