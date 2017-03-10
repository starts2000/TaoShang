using Starts2000.TaoBao.Views;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBao.Core
{
    class GlobalApplicationData : IGlobalApplicationData
    {
        #region IGlobalApplicationData 成员

        public ApplicationData ApplicationData
        {
            get { return Global.ApplicationData; }
        }

        #endregion
    }
}
