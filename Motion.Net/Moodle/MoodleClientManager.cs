namespace Motion.Net.Moodle;

public abstract class MoodleClientManager
{
    private static MoodleClient? _client;
    private static readonly object Lock = new object();

    public static MoodleClient? Instance
    {
        get
        {
            lock (Lock)
            {
                return _client ??= new MoodleClient("https://moodle.oszimt.de/",
                    Config.GetVariable("MoodleToken") ?? throw new InvalidOperationException(),
                    "webservice/rest/server.php").WithService("mod_assign_get_assignments");
            }
        }
    }
}