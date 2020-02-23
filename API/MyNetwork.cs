using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Torn_Assistant.API
{
    class MyNetwork : IDisposable
    {
        WebClient myClient = new WebClient();
        TimeSpan timeSpan = new TimeSpan();
        DateTimeOffset lastUpdateTime;
        private const int interval = 600;
        private uint burst = 0;

        public async Task<string> DownloadString(Uri _uri)
        {
            string data;

            //if first time ran, setup time
            if (lastUpdateTime.CompareTo(DateTimeOffset.Now) < 0) { lastUpdateTime = DateTimeOffset.Now; }

            //check how long since last download
            timeSpan = TimeSpan.FromMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastUpdateTime.ToUnixTimeMilliseconds());

            if (timeSpan.TotalMilliseconds > interval && timeSpan.TotalMilliseconds < 60000)
            {
                burst += Convert.ToUInt32((timeSpan.TotalMilliseconds / interval));
            }
            else if (timeSpan.Milliseconds > 60000 || burst > 100) { burst = 0; }
            else { }

            if (burst > 0) { burst--; }
            else { await Task.Delay(interval); }

            try
            {
                data = await myClient.DownloadStringTaskAsync(_uri);
                lastUpdateTime = DateTimeOffset.Now;
            }
            catch { return string.Empty; }

            return data;
        }

        public void Dispose()
        {
            myClient.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
