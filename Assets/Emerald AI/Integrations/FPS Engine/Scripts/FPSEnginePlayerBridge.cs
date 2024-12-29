using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI;
using cowsins;

public class FPSEnginePlayerBridge : EmeraldPlayerBridge
{
    PlayerStats m_PlayerStats;

    public override void Start()
    {
        //You should set the StartHealth and Health variables equal to that of your character controller here.
        base.Start();
        m_PlayerStats = GetComponent<PlayerStats>();
        StartHealth = (int)m_PlayerStats.maxHealth;
        Health = (int)m_PlayerStats.maxHealth;
    }

    public override void DamageCharacterController(int DamageAmount, Transform Target)
    {
        //The code for damaging your character controller should go here.
        m_PlayerStats.Damage(DamageAmount, false);

        Health = (int)m_PlayerStats.health;

        base.DamageCharacterController(DamageAmount, Target);
    }

    public override bool IsAttacking()
    {
        //Used for detecting when this target is attacking.
        return false;
    }

    public override bool IsBlocking()
    {
        //Used for detecting when this target is blocking.
        return false;
    }

    public override bool IsDodging()
    {
        //Used for detecting when this target is dodging.
        return false;
    }

    public override void TriggerStun(float StunLength)
    {
        //Custom trigger mechanics can go here, but are not required
    }
}
