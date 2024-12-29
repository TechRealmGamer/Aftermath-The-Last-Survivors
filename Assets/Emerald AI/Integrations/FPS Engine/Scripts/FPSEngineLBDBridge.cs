using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmeraldAI
{
    /// <summary>
    /// This script bridges damage between FPS Engine and Emerald AI's Location Based Damage colliders.
    /// This allows FPS Engine to work with Location Based Damage. Note: This component is automatically added to Location Based Damage colliders (if an AI has a LBD component) so it does not need to be added manually.
    /// </summary>
    public class FPSEngineLBDBridge : MonoBehaviour, cowsins.IDamageable
    {
        LocationBasedDamageArea m_LocationBasedDamageArea;

        void Start ()
        {
            m_LocationBasedDamageArea = GetComponent<LocationBasedDamageArea>();
        }

        public void Damage(float damage)
        {
            m_LocationBasedDamageArea.DamageArea((int)damage, null, 40, false);
        }

        public void Damage(float damage, bool isHeadshot)
        {
            m_LocationBasedDamageArea.DamageArea((int)damage, null, 40, isHeadshot);
        }
    }
}