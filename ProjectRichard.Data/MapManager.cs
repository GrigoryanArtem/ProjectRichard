using System.Collections.Generic;
using System.Linq;

namespace ProjectRichard.Data
{
    public static class MapManager
    {
        public static List<Map> GetMapsByEvaluation(int evaluation)
        {
            ProjectRichardDBEntities context = new ProjectRichardDBEntities();

            return context.Maps
                .Where(map => map.Evaluation == evaluation)
                .ToList();
        }
    }
}
