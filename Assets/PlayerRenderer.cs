using Assets;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public float speed = 0.5f;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = new Player();
        player.Init(transform.position, GameplayHelper.WorldBounds, GameplayHelper.WorldScreenSize);
    }

    // Update is called once per frame
    void Update()
    {
        float displacementX = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            displacementX = -speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            displacementX = speed * Time.deltaTime;
        }

        float displacementZ = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            displacementZ = speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            displacementZ = -speed * Time.deltaTime;
        }
        
        player.Move(new Vector3(displacementX, 0.0f, displacementZ));

        transform.position = player.RenderPosition;
    }
}
