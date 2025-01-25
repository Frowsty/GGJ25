using UnityEngine;

public class HealthBar : MonoBehaviour, IPlayerComponent
{
    public MonoBehaviour Component => this;

    private Transform player;
    private LineRenderer lineRendererHealth;
    private LineRenderer lineRendererHealthBackground;

    private float offset = 1f;

    private void Start()
    {
        player = Player.Instance.transform;
        
        lineRendererHealth = GameObject.Find("HealthBar").GetComponent<LineRenderer>();
        lineRendererHealthBackground = GameObject.Find("HealthBar - Background").GetComponent<LineRenderer>();

        lineRendererHealth.positionCount = 2;
        lineRendererHealthBackground.positionCount = 2;
        lineRendererHealth.SetPositions(new[] { new Vector3(player.position.x - offset, player.position.y + -(offset + 0.2f), 0),
                                                new Vector3(player.position.x + offset, player.position.y + -(offset + 0.2f), 0) });
        lineRendererHealthBackground.SetPositions(new[] { new Vector3(player.position.x - offset, player.position.y + -(offset + 0.2f), 0),
                                                          new Vector3(player.position.x + offset, player.position.y + -(offset + 0.2f), 0) });
        
        lineRendererHealth.startWidth = 0.1f;
        lineRendererHealth.endWidth = 0.1f;
        lineRendererHealthBackground.startWidth = 0.1f;
        lineRendererHealthBackground.endWidth = 0.1f;
        
        lineRendererHealth.material = new Material(Shader.Find("Sprites/Default"));
        lineRendererHealth.startColor = new Color(0f, 1f, 0f, 1f);
        lineRendererHealth.endColor = new Color(0f, 1f, 0f, 1f);
        
        lineRendererHealthBackground.material = new Material(Shader.Find("Sprites/Default"));
        lineRendererHealthBackground.startColor = new Color(0.1f, 0.1f, 0.1f, 1f);
        lineRendererHealthBackground.endColor = new Color(0.1f, 0.1f, 0.1f, 1f);
    }

    public void UpdateComponent()
    {
        float healthPercent = (float)PlayerStats.Instance.GetHealth() / (float)PlayerStats.Instance.GetMaxHealth();
        healthPercent = healthPercent < 0 ? 0 : healthPercent;
        
        lineRendererHealth.SetPositions(new[] { new Vector3(player.position.x - offset, player.position.y + -(offset + 0.2f) , 0),
                                                new Vector3(player.position.x - offset + (healthPercent * 2), player.position.y + -(offset + 0.2f), 0) });
        lineRendererHealthBackground.SetPositions(new[] { new Vector3(player.position.x - offset, player.position.y + -(offset + 0.2f), 0),
                                                          new Vector3(player.position.x + offset, player.position.y + -(offset + 0.2f), 0) });
    }
}