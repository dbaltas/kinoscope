using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace kinoscope
{
    public interface IEventVisualiser
    {
        void Start(DateTime dateTime);
        void Stop(DateTime dateTime);
        void Clear();
        void UpdateInterval(long milliseconds);
        void AddRunEvent(RunEvent runEvent);
        void SetBehaviors(List<Behavior> behaviors);
        void SetDurationMilliseconds(long milliseconds);
        void SetBehaviorColorAssigner(BehaviorColorAssigner behaviorColorAssigner);
    }
}
