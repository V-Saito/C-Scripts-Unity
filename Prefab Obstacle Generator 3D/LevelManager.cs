using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { set; get; }

    public bool SHOW_COLLIDER = true;

    private const float DISTANCE_BEFORE_SPAWN = 350f;
    private const int INITIAL_SEGMENTS = 10;
    private const int MAX_SEGMENTS_ON_SCREEN = 15;
    private Transform cameraContainer;
    private int amoutOfActiveSegments;
    private int continiousSegments;
    private int currentSpawnZ;
    private int currentLevel;
    private int y1, y2, y3;

    public List<Piece> rocks = new List<Piece>();
    public List<Piece> traps = new List<Piece>();
    public List<Piece> enemys = new List<Piece>();
    public List<Piece> woodlogs = new List<Piece>();
    public List<Piece> walls = new List<Piece>();
    [HideInInspector]
    public List<Piece> pieces = new List<Piece>();
    public List<Piece> barriers = new List<Piece>();
    public List<Piece> ramps = new List<Piece>();

    public List<Segment> availableSegments = new List<Segment>();
    public List<Segment> availableTransitions = new List<Segment>();
    [HideInInspector]
    public List<Segment> segments = new List<Segment>();

    private bool IsMoving = false;

    private void Awake()
    {
        Instance = this;
        cameraContainer = Camera.main.transform;
        currentSpawnZ = 0;
        currentLevel = 0;
    }

    private void Start()
    {
        for (int i = 0; i < INITIAL_SEGMENTS; i++)
            GenerateSegment();
    }

    private void Update()
    {
        if (currentSpawnZ - cameraContainer.position.z < DISTANCE_BEFORE_SPAWN)
            GenerateSegment();
        if (amoutOfActiveSegments >= MAX_SEGMENTS_ON_SCREEN)
        {
            segments[amoutOfActiveSegments - 1].DeSpawn();
            amoutOfActiveSegments--;
        }
    }

    private void GenerateSegment()
    {
        SpawnSegment();
        if(Random.Range(0f, 1f) < (continiousSegments * 0.25f))
        {
            continiousSegments = 0;
            SpawnTransition();
        }
        else
        {
            continiousSegments++;
        }
        
    }

    private void SpawnSegment()
    {
        List<Segment> possibleSeg = availableSegments.FindAll(x => x.beginY1 == y1 || x.beginY2 == y2 ||x.beginY3 == y3);
        int id = Random.Range(0, possibleSeg.Count);

        Segment s = GetSegment(id, false);

        y1 = s.endY1;
        y2 = s.endY2;
        y3 = s.endY3;

        s.transform.SetParent(transform);
        s.transform.localPosition = Vector3.forward * currentSpawnZ;

        currentSpawnZ += s.lenght;
        amoutOfActiveSegments++;
        s.Spawn();
    }
    private void SpawnTransition()
    {
        List<Segment> possibleTransition = availableTransitions.FindAll(x => x.beginY1 == y1 || x.beginY2 == y2 || x.beginY3 == y3);
        int id = Random.Range(0, possibleTransition.Count);

        Segment s = GetSegment(id, true);

        y1 = s.endY1;
        y2 = s.endY2;
        y3 = s.endY3;

        s.transform.SetParent(transform);
        s.transform.localPosition = Vector3.forward * currentSpawnZ;

        currentSpawnZ += s.lenght;
        amoutOfActiveSegments++;
        s.Spawn();
    }

    public Segment GetSegment(int id, bool transition)
    {
        Segment s = null;
        s = segments.Find(x => x.SegId == id && x.transition == transition && !x.gameObject.activeSelf);

        if(s == null)
        {
            GameObject go = Instantiate((transition) ? availableTransitions[id].gameObject : availableSegments[id].gameObject) as GameObject;
            s = go.GetComponent<Segment>();

            s.SegId = id;
            s.transition = transition;

            segments.Insert(0, s);
        }
        else
        {
            segments.Remove(s);
            segments.Insert(0, s);
        }
        return s;
        
    }
    public Piece GetPiece(PieceType pt, int visualIndex)
    {
        Piece p = pieces.Find(x => x.type == pt && x.visualIndex == visualIndex && !x.gameObject.activeSelf);
        
        if (p == null)
        {
            GameObject go = null;
            if (pt == PieceType.rock)
                go = rocks[visualIndex].gameObject;
            else if (pt == PieceType.trap)
                go = traps[visualIndex].gameObject;
            else if (pt == PieceType.enemy)
                go = enemys[visualIndex].gameObject;
            else if (pt == PieceType.woodlog)
                go = woodlogs[visualIndex].gameObject;
            else if (pt == PieceType.wall)
                go = walls[visualIndex].gameObject;
            else if (pt == PieceType.barrier)
                go = barriers[visualIndex].gameObject;
            else if (pt == PieceType.ramp)
                go = ramps[visualIndex].gameObject;

            go = Instantiate(go);
            p = go.GetComponent<Piece>();
            pieces.Add(p);

        }
        
        return p;
    }
}
