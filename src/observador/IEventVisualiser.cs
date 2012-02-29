using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace observador
{
    public interface IEventVisualiser
    {
        void SetDimensions(int left, int top, int width, int height);
        void Start(DateTime dateTime);
        void Stop(DateTime dateTime);
        void Clear();
        void UpdateInterval(long milliseconds);
        void AddRunEvent(RunEvent runEvent);
    }
}
