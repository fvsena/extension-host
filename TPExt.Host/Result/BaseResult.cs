namespace TPExt.Host.Result
{
    public class BaseResult
    {
        public bool ProcessOk { get; set; }
        public bool MessageReceived { get; set; }
        public string Msg { get; set; }
        public string MsgCatch { get; set; }
    }
}
