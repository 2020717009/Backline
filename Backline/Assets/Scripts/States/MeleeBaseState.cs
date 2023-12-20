using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    //how long should this state last before moving on
    public float _duration;
    //reference to our animator
    protected Animator _animator;
    //dictates which attack animation is trigerred
    protected int _attackIndex;
    //dictates the attack should be able to combo
    protected bool _shouldCombo;

    
}
