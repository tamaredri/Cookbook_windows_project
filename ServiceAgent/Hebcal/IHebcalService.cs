using ServiceAgent.Spoonacular.REntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Hebcal
{
    public interface IHebcalService
    {
        Task<DateInformation> GetHebrewEvent(DateTime start, DateTime end);

    }
}
