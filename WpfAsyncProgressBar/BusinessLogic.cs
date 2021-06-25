using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAsyncProgressBar
{
    public class BusinessLogic
    {

        public async Task<string> DoSomething(IProgress<int> progress)
        {
            int currentProgress = 0;

            while (currentProgress < 100)
            {
                currentProgress += 10;
                progress?.Report(currentProgress);
                await Task.Delay(500);
            }

            return "BusinessLogic ist fertig ;-)!";
        }
    }
}
