using Assets;
using UnityEngine;

public class NPCRenderer : MonoBehaviour
{
    public float speed = 0.5f;

    private NPC npc;

    private float moveTimer;

    private Vector3 moveVector;
    
    // Start is called before the first frame update
    void Start()
    {
        npc = new NPC();
        npc.Init(transform.position, GameplayHelper.WorldBounds, GameplayHelper.WorldScreenSize);
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer < 0.0f)  //time to change trajectory
        {
            float displacementX = 0.0f;
            float displacementZ = 0.0f;

            int moveDirection = Random.Range(1, 5);

            switch (moveDirection)
            {
                case 1:
                    displacementX = speed * Time.deltaTime;
                    break;
                case 2:
                    displacementX = -speed * Time.deltaTime;
                    break;
                case 3:
                    displacementZ = speed * Time.deltaTime;
                    break;
                case 4:
                    displacementZ = -speed * Time.deltaTime;
                    break;
            }
            
            moveVector = new Vector3(displacementX, 0.0f, displacementZ);
            moveTimer = Random.Range(3.0f, 5.0f);
        }
        
        npc.Move(moveVector);

        transform.position = npc.RenderPosition;
    }
    
    
}