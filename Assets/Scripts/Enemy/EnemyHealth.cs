using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float Health = 100.0f;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    // Start is called before the first frame update

    public void DecreaseHealth(float amount){
        Health -= amount;
        if(Health <=0){
            Health = 0;
            GetComponent<MeshCollider>().enabled = false;
            Die();

        }
    }

    public void Die(){
        //destory();
        Debug.Log("The enemy is dead");
        _animator.SetBool("isDead", true);
    }


    // Update is called once per frame
    void Update()
    {
                
    }
}
