
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth; 
    public float currentHealth{get; private set;}
    private Animator anim;
    private bool dead;
    
    private void Awake(){
        currentHealth = startingHealth;
        anim = GetComponent<Animator>(); 
    }
    public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if(currentHealth > 0){
            //Damage player
            anim.SetTrigger("hurt");
        }
        else{
            //player dead
            if(!dead){
                anim.SetTrigger("dead");
                GetComponent<playerMovement>().enabled = false;
                dead = true;
            }
            
        }
   }
  
}
