using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern2_tornado : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    ParticleSystem ps;
    List<ParticleSystem.Particle> inside_ = new List<ParticleSystem.Particle>();

    public GameObject PlayerObject;
    public Vector3 offset;
    public float smoothSpeed = 0.5f;

    public float minDelay = 1f;
    public float maxDelay = 3f;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(ToggoleObjectRoutine());
    }

    private void OnParticleTrigger()
    {
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside_);
        for (int i = 0; i < inside_.Count; i++)
        {
            Vector3 hitPos = inside_[i].position;
            float detectradius = 0.2f;
            Collider2D[] hits = Physics2D.OverlapCircleAll(hitPos, detectradius);
            foreach(var hit in hits)
            {
                if(hit.gameObject.name == "player")
                {
                    Debug.Log("ÆÄÆ¼Å¬" + hit.gameObject.name);
                    hit.gameObject.GetComponent<player_control>().HP_valueCHange(-0.05f);
                }
                if (hit.gameObject.CompareTag("Boss"))
                {
                    hit.gameObject.GetComponent<BossAttackManager>().Boss_Hp_valueChange(-0.01f);
                }
            }
        }
        Debug.Log("Effect Trigger");
        
    }
    void FixedUpdate()
    {
        Vector3 desirePos = PlayerObject.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desirePos, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPos;
    }

    IEnumerator ToggoleObjectRoutine()
    {
        while (true)
        {
            var collision = ps.collision;
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            collision.enabled = !collision.enabled;

            if (collision.enabled)
            {
                ps.Play();
            }
            else
            {
                ps.Stop();
            }
        }
    }
    // Update is called once per frame
}
