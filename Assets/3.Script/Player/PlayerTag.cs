using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class PlayerTag : MonoBehaviour
{
    public Tilemap tilemap;        
    public int wallHealth = 4;//타일 체력
    private Dictionary<Vector3Int, int> tileHealths;//타일맵 정보
    Animator animator;

    bool gameOver = GameManager.isGameOver;

    //타일 이미지
    [SerializeField] private Tile[] TileImage;

    //타일에게 주는 데미지 딜레이
    public float fristDelay = 0.25f;
    private float lastDelay = 0f;   
    
    public static bool isdrill = false;
    public static bool isdrillDown = false;        
    private void Start()
    {
        tileHealths = new Dictionary<Vector3Int, int>();
        animator = GetComponent<Animator>();    
    }    

    private void Update()
    {        
            playerGround();        
    }

    public void playerGround()
    {        
        Vector2 ray = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, ray, 0.2f);
        Debug.DrawRay(transform.position, ray * 0.2f, Color.red);
        
        if (hit.collider !=null && hit.collider.CompareTag("Tile"))
        {
            playerDrill();
        }
    }
    public void playerDrill()
    {
        isdrill = false;
        isdrillDown = false;
        
        if (lastDelay >= fristDelay)
        {
            Vector2 ray = Vector2.zero;

            if (Input.GetKey(KeyCode.DownArrow))
            {                
                ray = Vector2.down;                 
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {                
                ray = Vector2.left;                   
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                ray = Vector2.right;                    
            }
            if (ray != Vector2.zero)
            {                    
                Vector2 playerPosition = transform.position;                    
                
                Debug.DrawRay(playerPosition, ray * 0.2f, Color.green, 1f);                                   
                
                RaycastHit2D hit = Physics2D.Raycast(playerPosition, ray, 0.2f);
                

                if (hit.collider != null && hit.collider.CompareTag("Tile"))
                {
                    if (ray== Vector2.down)
                    {
                        isdrillDown = true;
                        Vector3Int cellposition = tilemap.WorldToCell(hit.point+ new Vector2(0,-0.1f));                            
                        DamageTile(cellposition);                        
                    }
                    else if(ray==Vector2.left)
                    {
                        isdrill = true;
                        Vector3Int cellposition = tilemap.WorldToCell(hit.point + new Vector2(-0.1f, -0.1f));
                        DamageTile(cellposition);                        
                    }
                    else if (ray==Vector2.right)
                    {
                        isdrill = true;
                        Vector3Int cellposition = tilemap.WorldToCell(hit.point);
                        DamageTile(cellposition);
                    }                            
                }
            }
            lastDelay = 0f;
            animator.SetBool("is drill", isdrill);
            animator.SetBool("is drill down", isdrillDown);            
        }
        lastDelay += Time.deltaTime;
    }
    private void DamageTile(Vector3Int cellPosition)
    {                  
        if (tilemap.HasTile(cellPosition))
        {
            if (!tileHealths.ContainsKey(cellPosition))
            {
                tileHealths[cellPosition] = wallHealth;
            }

            tileHealths[cellPosition]--;

            if (tileHealths[cellPosition] > 0)
            {
                tilemap.SetTile(cellPosition, TileImage[tileHealths[cellPosition]-1]);
            }
            else 
            {
                tilemap.SetTile(cellPosition, null);
                tileHealths.Remove(cellPosition);
            }
        }        
    }
}
