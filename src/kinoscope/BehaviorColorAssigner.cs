using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using ObLib.Domain;

namespace kinoscope
{
    public class BehaviorColorAssigner
    {
        List<Behavior> _allBehaviors;
        Color[] _colorPool;

        public BehaviorColorAssigner(List<Behavior> allBehaviors, Color[] colorPool)
        {
            _allBehaviors = allBehaviors;
            _colorPool = colorPool;
        }

        public Color GetBehaviorColor(Behavior behavior)
        {
            return _colorPool[_allBehaviors.IndexOf(behavior) % _colorPool.Length];
        }
    }
}
