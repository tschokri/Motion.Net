using Notion.Client;

namespace Motion.Net.Notion;

public static class NotionClientManager
{
    private static NotionClient? _client;
    private static readonly object Lock = new object();

    public static NotionClient? Instance
    {
        get
        {
            lock (Lock)
            {
                return _client ??= NotionClientFactory.Create(new ClientOptions
                {
                    AuthToken = Config.GetVariable("MotionDotNetSecret")
                });
            }
        }
    }
}