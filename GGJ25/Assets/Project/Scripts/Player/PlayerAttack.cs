using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour, IPlayerComponent
{
    [SerializeField]
    private BubbleMovement bubblePrefab;

    public List<BubbleMovement> bubbles;

    private bool charge = false;
    private BubbleMovement chargeBubble;
    
    private float chargeTimer = 0f;
    private float lastCharge = 0f;
    private float lastAttack = 0f;
    
    private Vector2 mousePosition;
    
    public void UpdateComponent()
    {
        for (int i = bubbles.Count - 1; i >= 0; i--)
        {
            bubbles[i].UpdateBubble();
            if (bubbles[i].shouldDestroy)
            {
                Destroy(bubbles[i].gameObject);
                bubbles.RemoveAt(i);
            }
        }

        if (InputSystem.actions["Attack"].IsPressed())
        {
            if (Time.time - lastAttack >= PlayerStats.Instance.GetFireRate())
            {
                var bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
                bubble.damage = PlayerStats.Instance.GetDamage();
                bubble.direction = (Camera.main.ScreenToWorldPoint(mousePosition) - transform.position).normalized;
                bubble.spawnTime = Time.time;
                bubbles.Add(bubble);

                lastAttack = Time.time;
            }
        }

        if (InputSystem.actions["Charge"].WasPressedThisFrame() && !charge &&
            Time.time - lastCharge > PlayerStats.Instance.GetChargedFireRate())
        {
            chargeBubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            charge = true;
            chargeBubble.bubbleCollider = chargeBubble.GetComponent<CircleCollider2D>();
            chargeBubble.bubbleCollider.enabled = false;
            GetComponent<Animator>().SetBool("IsShooting", true);
        }

        if (charge)
        {
            if (chargeBubble != null)
            {
                chargeTimer += Time.deltaTime;
                chargeBubble.transform.localScale +=
                    new Vector3(PlayerStats.Instance.GetChargeRate(), PlayerStats.Instance.GetChargeRate(), 0) * Time.deltaTime;
                chargeBubble.transform.position = transform.position;

                if (chargeTimer >= PlayerStats.Instance.GetChargeTime())
                {
                    chargeBubble.bubbleCollider.enabled = true;
                    chargeBubble.damage = Mathf.RoundToInt(chargeBubble.transform.localScale.x * PlayerStats.Instance.GetDamage());
                    chargeBubble.spawnTime = Time.time;
                    chargeBubble.direction = (Camera.main.ScreenToWorldPoint(mousePosition) - transform.position).normalized;
                    bubbles.Add(chargeBubble);
                    chargeBubble = null;
                    charge = false;
                    lastCharge = Time.time;
                    GetComponent<Animator>().SetBool("IsShooting", false);
                }
            }
        }

        if (InputSystem.actions["Charge"].WasReleasedThisFrame())
        {
            charge = false;
            if (chargeBubble != null)
            {
                chargeBubble.bubbleCollider.enabled = true;
                chargeBubble.damage = Mathf.RoundToInt(chargeBubble.transform.localScale.x * PlayerStats.Instance.GetDamage());
                chargeBubble.spawnTime = Time.time;
                chargeBubble.direction = (Camera.main.ScreenToWorldPoint(mousePosition) - transform.position).normalized;
                bubbles.Add(chargeBubble);
                chargeBubble = null;
                lastCharge = Time.time;
                GetComponent<Animator>().SetBool("IsShooting", false);
            }

            chargeTimer = 0f;
        }
    }

    public void OnLook(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }
}
