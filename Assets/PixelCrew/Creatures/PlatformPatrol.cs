using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelCrew.Creatures
{
    public class PlatformPatrol : Patrol
    {
        public override IEnumerator DoPatrol()
        {
            yield return null;
        }
    }
}
