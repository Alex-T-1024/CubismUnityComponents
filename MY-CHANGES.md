# Live2D SDK Changes

## "Look at" Mechanism

class `CubismLookController` field `GoalPosition` should be set between -1 ~ +1 for all X and Y axes.  
Original calculation is not correct and should be changed in method `OnLateUpdate()`:

```c#
// original
            // Update position.
            var position = LastPosition;
            GoalPosition = transform.InverseTransformPoint(target.GetPosition()) - Center.localPosition;

// new
//... in class
        // Modified by alex
        private Camera _mainCamera;
//... in OnLateUpdate()

                    // Modified by alex
            // Update position.
            var position = LastPosition;
            GoalPosition = target.GetPosition() - Center.position;
            GoalPosition = Utils.TransformUtil.WorldToCameraRelativeNormalizedPos(_mainCamera, GoalPosition, 0.8f);
//... in Start()
    _mainCamera = Camera.main;
```
