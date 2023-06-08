using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    BoxCollider2D _knifeHitbox;
    public int _knifeDamage = 10;
    public int _knifeComboDamage = 25;

    void Awake(){
        _knifeHitbox = GetComponent<BoxCollider2D>();
    }

    void Start(){
        _knifeHitbox.enabled = false;
    }

    public void EnableKnifeHitbox(){
        _knifeHitbox.enabled = true;
    }

    public void DisableKnifeHitBox(){
        _knifeHitbox.enabled = false;
    }
    
}
