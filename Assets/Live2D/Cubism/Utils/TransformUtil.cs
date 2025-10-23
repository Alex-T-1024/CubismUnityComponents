using UnityEngine;

namespace Live2D.Cubism.Utils
{
    static class TransformUtil
    {
        /// <summary>
        /// Converts a world vector to a normalized 0 ~ (+-)1 coordinate relative to the camera's view.
        /// </summary>
        /// <param name="cam">An orthographic camera used as the reference for conversion.</param>
        /// <param name="vector">The world-space vector to convert.</param>
        /// <param name="shrinkFactorX">float value for shrinking the max value of camera's width</param>
        /// <param name="shrinkFactorY">float value for shrinking the max value of camera's height</param>
        /// <returns>A Vector2 where (0,0) represents the center and (1,1) the top-right and (-1,-1) the bottom-left of the camera's view.</returns>
        public static Vector2 WorldToCameraRelativeNormalizedPos(Camera cam, Vector2 vector, float shrinkFactorX = 1, float shrinkFactorY = 1)
        {
            float maxY = cam.orthographicSize; // half of height
            float maxX = cam.aspect * cam.orthographicSize;
            vector.x /= maxX * shrinkFactorX;
            vector.y /= maxY * shrinkFactorY;
            return vector;
        }
    }
}
