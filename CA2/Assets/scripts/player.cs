using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : character
{
    float hor, ver;
    protected override void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        velocity.x = hor * movementSpeed;
        velocity.y = ver * movementSpeed;
        body.velocity = velocity;
        //call update method in the character class                                                            
        base.Update();
        
        
        
    }

}
