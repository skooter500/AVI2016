@script ExecuteInEditMode()
#pragma strict

public var controlPoints : GameObject[] = new GameObject[3];
public var color : Color = Color.white;
public var width : float = 0.2;
public var numberOfPoints : int = 20;

function Start() 
{
   // initialize line renderer component
   var lineRenderer : LineRenderer = 
      GetComponent(LineRenderer);
   if (null == lineRenderer)
   {
      gameObject.AddComponent(LineRenderer);
   }
   lineRenderer = GetComponent(LineRenderer);
   lineRenderer.useWorldSpace = true;
   lineRenderer.material = new Material(
      Shader.Find("Particles/Additive"));
}

function Update() 
{
   // check parameters and components
   var lineRenderer : LineRenderer = 
      GetComponent(LineRenderer);
   if (null == lineRenderer || controlPoints == null 
      || controlPoints.length < 3)
   {
      return; // not enough points specified
   } 
   
   // update line renderer
   lineRenderer.SetColors(color, color);
   lineRenderer.SetWidth(width, width);
   if (numberOfPoints < 2)
   {
      numberOfPoints = 2;
   }
   lineRenderer.SetVertexCount(numberOfPoints * 
      (controlPoints.length - 2));

   // loop over segments of spline
   var p0 : Vector3;
   var p1 : Vector3;
   var p2 : Vector3;
   for (var j : int = 0; j < controlPoints.length - 2; j++)
   {
      // check control points
      if (controlPoints[j] == null || 
         controlPoints[j + 1] == null ||
         controlPoints[j + 2] == null)
      {
         return;  
      }
      // determine control points of segment
      p0 = 0.5 * (controlPoints[j].transform.position 
         + controlPoints[j + 1].transform.position);
      p1 = controlPoints[j + 1].transform.position;
      p2 = 0.5 * (controlPoints[j + 1].transform.position 
         + controlPoints[j + 2].transform.position);
      
      // set points of quadratic Bezier curve
      var position : Vector3;
      var t : float; 
      var pointStep : float = 1.0 / numberOfPoints;
      if (j == controlPoints.length - 3)
      {
         pointStep = 1.0 / (numberOfPoints - 1.0);
         // last point of last segment should reach p2
      }  
      for(var i : int = 0; i < numberOfPoints; i++) 
      {
         t = i * pointStep;
         position = (1.0 - t) * (1.0 - t) * p0 
            + 2.0 * (1.0 - t) * t * p1
            + t * t * p2;
         lineRenderer.SetPosition(i + j * numberOfPoints, 
            position);
      }
   }
}