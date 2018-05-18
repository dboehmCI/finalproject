using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MatchDot
{
    [RequireComponent(typeof(ConnectionSystem))]
    public class DotsGrid : MonoBehaviour
    {
        private const float DOT_PIXEL_SIZE = 32f;
        

        [SerializeField]
        private GameObject dotPrefab;
       
        [SerializeField]
        private Dot preview;

        [SerializeField]
        private byte columns = 4;
        [SerializeField]
        private byte rows = 4;
        [SerializeField]
        private float dotSpacing = 5f;
        [SerializeField]
        private float dotPPU = 100f;

        private List<Dot> dots = new List<Dot>();
        private List<Dot> GridDots = new List<Dot>();
        private float timeLeft;

        private ConnectionSystem connectionSystem;
        bool showPreview = true;
        
        public float respawnTimer = 5f; // Every 5 seconds, a new dot will spawn.
        public float delayPeriod = 8f; // Every 5 seconds, a new dot will spawn.
        public float dotSize { get { return DOT_PIXEL_SIZE / dotPPU; } }


        private void FixedUpdate()
        {

            if (delayPeriod != 0)
            {
                if (delayPeriod > 0)
                {
                    delayPeriod -= Time.deltaTime;
                }
                else { delayPeriod = 0 * Time.deltaTime; BeginGame(); }
            }
            else
            {
                respawnTimer -= Time.deltaTime;
                if (showPreview)
                {
                    var types = Enum.GetValues(typeof(DotType));
                    preview.dotType = (DotType)UnityEngine.Random.Range(1, types.Length - 1);
                    showPreview = false;
                }

                if (respawnTimer < 0)
                {
                    bool gameOver = true;
                    foreach (var d in dots)
                    {
                        if (d.dotType == DotType.Cleared)
                        {
                            gameOver = false;
                        }
                    }
                    if (gameOver == false)
                    {
                        var types = Enum.GetValues(typeof(DotType));
                        TimedDotSpawn(preview.dotType);
                        showPreview = true;

                    }
                    else
                    {
                       
                            Game.get.session.gameOver = true;
                        
                        
                    }
                    respawnTimer = 1f;
                }
            }
       

        }
        private void Awake()
        {
            timeLeft = 3f;
            connectionSystem = gameObject.GetComponent<ConnectionSystem>();
            DotTouchIO.SelectionEnded += ClearSelectedDots;
            CreateDotObjects();
        }
        void BeginGame()
        {
            
                respawnTimer = 0;
                ExecuteDotOperation((dot) =>
                {
                    var targetPosition = GetPositionForCoordinates(dot.coordinates);
                    dot.SpawnCreate(targetPosition, 0.5f);
                });
            
        }

        private void CreateDotObjects()
        {
           
                // Need to manually loop for dot creation
                for (byte row = 0; row < rows; row++)
                {
                    for (byte column = 0; column < columns; column++)
                    {
                        var dot = Instantiate(dotPrefab).GetComponent<Dot>();

                        dot.transform.parent = transform;
                        dot.dotType = DotType.DotG;
                        dot.coordinates = new GridCoordinates(column, row);
                        dots.Add(dot);
                    }
                }
            
        }

        private Vector2 GetPositionForCoordinates(GridCoordinates position)
        {
            var adjustedDotSize = dotSize + dotSpacing;
            var worldPosition = Vector2.zero;

            // Set to "zero position" (bottom left dot position)
            worldPosition.x = -adjustedDotSize * ((columns - 1) / 2f);
            worldPosition.y = -adjustedDotSize * ((rows - 1) / 2f);

            // Add offset from zero position via dot coordinate
            worldPosition.x += adjustedDotSize * position.column;
            worldPosition.y += adjustedDotSize * position.row;

            return worldPosition;
        }

        private void ClearSelectedDots()
        {
            if (connectionSystem.activeConnections.Count < 2)
            {
                return;
            }

            var dotsRemovedInColumn = new byte[columns];

            // Run square behavior
            if (connectionSystem.isSquare)
            {
                connectionSystem.activeConnections.Clear();
                foreach (var d in dots)
                {
                    if (d.dotType == connectionSystem.currentType)
                    {
                        connectionSystem.activeConnections.Add(d);
                    }
                }
            }

            Game.get.session.dotsCleared += connectionSystem.activeConnections.Count;

            // 1. Mark all connected dots
           // For every valid Dot connected through the connectionSystem, the dot coordinate will be flagged as "Cleared".
           // A "Cleared" status means the coordinate is valid for a dot to spawn. 

            foreach (var dot in connectionSystem.activeConnections)
            {
                var dotCoord = dot.coordinates;
                //dotsRemovedInColumn[dotCoord.column]++;
                dot.dotType = DotType.Cleared;
                dot.ClearDot(); // Clear dot status

            }


            // 2. Anaylzes each column to determine if there are missing gaps. 
            // If so, dots are moved down to a new position until the only gaps are at the top.
            //for (byte c = 0; c < columns; c++)
            //{
            //    if (dotsRemovedInColumn[c] == 0)
            //    {
            //        continue;
            //    }
                //ExecuteDotOperation(c, (dot) =>
                //{
                //    if (dot.coordinates.row != 0 && dot.dotType != DotType.Cleared)
                //    {
                //        var fallDist = GetBlankDotsUnderneath(dot);
                //        dot.coordinates = new GridCoordinates(c, (byte)(dot.coordinates.row - fallDist));
                //        dot.MoveToPosition(GetPositionForCoordinates(dot.coordinates), 0f);
                //    }
                //});
            //}

            // 3. For each column, recycle dots
            // Checks each column and determines which grid coordinates are available per row. 
            // Available locations per column are determined by the removed count.
            //for (byte c = 0; c < columns; c++)
            //{
            //    var removedCount = dotsRemovedInColumn[c];
            //    for (byte r = 0; r < removedCount; r++)
            //    {

            //        // The lowest empty row
            //        var row = (byte)(rows - (removedCount - r));
            //        var lastDotIndex = connectionSystem.activeConnections.Count - 1;
            //        var dot = connectionSystem.activeConnections[lastDotIndex];

            //        connectionSystem.activeConnections.RemoveAt(lastDotIndex);
            //        dot.coordinates = new GridCoordinates(c, row);
            //        dot.Spawn(GetPositionForCoordinates(dot.coordinates), 0f);
            //    }
            //}

            // Sanity check
            connectionSystem.activeConnections.Clear();

            // Populate 
               // TimedDotSpawn();
            
        }

        private void TimedDotSpawn(DotType color)
        {
            
            int r = UnityEngine.Random.Range(0,dots.Count);
            while (dots[r].dotType != DotType.Cleared)
            {
                r = UnityEngine.Random.Range(0, dots.Count);
            }
            // Displays the new dot type to spawn for the player
            dots[r].Spawn(GetPositionForCoordinates(dots[r].coordinates), 0f, color);

            
        }



        private byte GetBlankDotsUnderneath(Dot dot)
        {
            byte count = 0;
            ExecuteDotOperation(dot.coordinates.column, (other) =>
            {
                if (other.dotType == DotType.Cleared && other.coordinates.row < dot.coordinates.row)
                {
                    count++;
                }
            });
            return count;
        }


        /// <summary>
        /// Calls callback on all dots
        /// </summary>
        delegate void OnDotOperation(Dot dot);
        private void ExecuteDotOperation(OnDotOperation callback)
        {
            foreach (var d in dots)
            {
                callback(d);
            }
        }

        /// <summary>
        /// Calls callback on all dots in column
        /// </summary>
        private void ExecuteDotOperation(byte column, OnDotOperation callback)
        {
            foreach (var d in dots)
            {
                if (d.coordinates.column == column)
                {
                    callback(d);
                }
            }
        }
    }
}