using System.Collections.Generic;

namespace KDS.Infraestructure.Data.Infraestructure
{
    public abstract class TrackableEntity
    {
        public Dictionary<string, object> OriginalValues { get; set; }
    }
}
