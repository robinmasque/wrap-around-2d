using UnityEngine;

namespace Assets
{
    public class Player
    {
        private Vector3 logicalPosition;
        public Vector3 RenderPosition;
        private Bounds WorldBounds;
        private Vector3 WorldScreenSize;
        
        
        public static bool OnXBorder;
        public static bool OnZBorder;

        public void Init(Vector3 originalPos, Bounds worldBounds, Vector3 worldScreenSize)
        {
            logicalPosition = originalPos;
            WorldBounds = worldBounds;
            WorldScreenSize = worldScreenSize;

            float clampedPosX = logicalPosition.x;
            if (logicalPosition.x > WorldBounds.max.x || logicalPosition.x < (WorldBounds.min.x + WorldScreenSize.x))
            {
                clampedPosX = WorldBounds.min.x + WorldScreenSize.x;
            }
            
            float clampedPosZ = logicalPosition.z;
            if (logicalPosition.z > WorldBounds.max.z || logicalPosition.z < (WorldBounds.min.z + WorldScreenSize.z))
            {
                clampedPosZ = WorldBounds.min.z + WorldScreenSize.z;
            }

            logicalPosition = new Vector3(clampedPosX, logicalPosition.y, clampedPosZ);
            
            OnXBorder = false;
            OnZBorder = false;
        }

        public void Move(Vector3 displacement)
        {
            logicalPosition += displacement;
            float wrappedPosX = logicalPosition.x;
            if (logicalPosition.x < WorldBounds.min.x)
                wrappedPosX += WorldBounds.size.x;
            else if (logicalPosition.x > WorldBounds.max.x)
                wrappedPosX -= WorldBounds.size.x;
            
            float wrappedPosZ = logicalPosition.z;
            if (logicalPosition.z < WorldBounds.min.z)
                wrappedPosZ += WorldBounds.size.z;
            else if (logicalPosition.z > WorldBounds.max.z)
                wrappedPosZ -= WorldBounds.size.z;

            logicalPosition = new Vector3(wrappedPosX, logicalPosition.y, wrappedPosZ);

            AdjustRenderPosition();

            
        }

        public void AdjustRenderPosition()
        {
            float screenXHalf = WorldScreenSize.x * 0.5f;
            float screenZHalf = WorldScreenSize.z * 0.5f;
            OnXBorder = logicalPosition.x < (WorldBounds.min.x + screenXHalf) || logicalPosition.x > (WorldBounds.max.x - screenXHalf);
            OnZBorder = logicalPosition.z < (WorldBounds.min.z + screenZHalf) || logicalPosition.z > (WorldBounds.max.z - screenZHalf);

            float renderX = logicalPosition.x;
            if (logicalPosition.x < (WorldBounds.min.x + screenXHalf))
                renderX = logicalPosition.x + WorldBounds.size.x;

            float renderZ = logicalPosition.z;
            if (logicalPosition.z < (WorldBounds.min.z + screenZHalf))
                renderZ = logicalPosition.z + WorldBounds.size.z;
            
            RenderPosition = new Vector3(renderX, logicalPosition.y, renderZ);

        }
    }
    
}