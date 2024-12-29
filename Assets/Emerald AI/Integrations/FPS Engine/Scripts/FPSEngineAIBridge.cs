using UnityEngine;
using EmeraldAI;

namespace EmeraldAI
{
    /// <summary>
    /// This script bridges damage between FPS Engine and Emerald AI.
    /// </summary>
    public class FPSEngineAIBridge : MonoBehaviour, cowsins.IDamageable
    {
        EmeraldAI.IDamageable m_IDamageable; //Emerald AI's IDamageable
        EmeraldSystem EmeraldComponent;

        void Start()
        {
            m_IDamageable = GetComponent<EmeraldAI.IDamageable>();
            EmeraldComponent = GetComponent<EmeraldSystem>();
            Invoke(nameof(InitializeLBDBridge), 0.1f);
        }

        /// <summary>
        /// Add a FPSEngineLBDBridge to each collider within the AI's LBD Component collider list.
        /// This will allow the LBD areas to detect FPS Engine's damage and apply it to the hit collider.
        /// </summary>
        void InitializeLBDBridge ()
        {
            if (EmeraldComponent.LBDComponent != null)
            {
                for (int i = 0; i < EmeraldComponent.LBDComponent.ColliderList.Count; i++)
                {
                    EmeraldComponent.LBDComponent.ColliderList[i].ColliderObject.gameObject.AddComponent<FPSEngineLBDBridge>();
                }
            }
        }

        /// <summary>
        /// Receive the damage from FPS Engine's IDamageable and apply it to Emerald AI's IDamageable.
        /// Death logic is automatically handled through Emerald AI's Health script.
        /// </summary>
        /// <param name="damage"></param>
        public void Damage(float damage)
        {
            m_IDamageable.Damage((int)damage, null, 40);
        }

        public void Damage(float damage, bool isHeadshot)
        {
            m_IDamageable.Damage((int)damage, null, 40, isHeadshot);
        }
    }
}