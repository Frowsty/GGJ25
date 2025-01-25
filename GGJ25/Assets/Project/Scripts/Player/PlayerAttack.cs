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

        if (InputSystem.actions["Charge"].WasPressedThisFrame() && !charge &&
            Time.time - lastCharge > PlayerStats.Instance.GetChargedFireRate())
        {
            chargeBubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            charge = true;
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
                    chargeBubble.damage = Mathf.RoundToInt(chargeBubble.transform.localScale.x * PlayerStats.Instance.GetDamage());
                    chargeBubble.spawnTime = Time.time;
                    chargeBubble.direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
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
                chargeBubble.damage = Mathf.RoundToInt(chargeBubble.transform.localScale.x * PlayerStats.Instance.GetDamage());
                chargeBubble.spawnTime = Time.time;
                chargeBubble.direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                bubbles.Add(chargeBubble);
                chargeBubble = null;
                lastCharge = Time.time;
                GetComponent<Animator>().SetBool("IsShooting", false);
            }

            chargeTimer = 0f;
        }
    }

    private void OnAttack(InputValue value)
    {
        var bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
        bubble.damage = PlayerStats.Instance.GetDamage();
        bubble.direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized; 
        bubble.spawnTime = Time.time;
        bubbles.Add(bubble);
    }
}
