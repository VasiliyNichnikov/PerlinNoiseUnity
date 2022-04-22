using UnityEngine;

namespace View
{
    [RequireComponent(typeof(NoiseDraughtsman))]
    public class GradientsDraughtsman : MonoBehaviour
    {
        private Transform _thisTransform;
        private RectTransform _thisRectTransform;
        private NoiseDraughtsman _noise;
        
        private void OnDrawGizmos()
        {
            _thisTransform = transform;
            _thisRectTransform = GetComponent<RectTransform>();
            _noise = GetComponent<NoiseDraughtsman>();
            
            Gizmos.color = Color.black;
            Rect rect = _thisRectTransform.rect; 
            Vector3 halfSizeRender = new Vector3(rect.width, rect.height, 0) / 2;
            Vector3 center = _thisTransform.position;

            float multiplicationIn = 30;
            
            Vector3 positionLeftTopStart = center + new Vector3(-halfSizeRender.x, halfSizeRender.y, 0);
            Vector3 positionLeftTopEnd = positionLeftTopStart + new Vector3(_noise.LeftTop.x, _noise.LeftTop.y, 0) * multiplicationIn;
            
            Vector3 positionRightTopStart = center + halfSizeRender;
            Vector3 positionRightTopEnd = positionRightTopStart + new Vector3(_noise.RightTop.x, _noise.RightTop.y, 0) * multiplicationIn;
        
            Vector3 positionLeftBottomStart = center + new Vector3(halfSizeRender.x, -halfSizeRender.y, 0);
            Vector3 positionLeftBottomEnd = positionLeftBottomStart + new Vector3(_noise.LeftBottom.x, _noise.LeftBottom.y, 0) * multiplicationIn;
            
            Vector3 positionRightBottomStart = center - halfSizeRender;
            Vector3 positionRightBottomEnd = positionRightBottomStart + new Vector3(_noise.RightBottom.x, _noise.RightBottom.y, 0) * multiplicationIn;
            
            Gizmos.color = Color.red;
            Gizmos.DrawLine(positionLeftTopStart, positionLeftTopEnd);
            Gizmos.DrawLine(positionRightTopStart, positionRightTopEnd);
            Gizmos.DrawLine(positionLeftBottomStart, positionLeftBottomEnd);
            Gizmos.DrawLine(positionRightBottomStart, positionRightBottomEnd);
        }
    }
}