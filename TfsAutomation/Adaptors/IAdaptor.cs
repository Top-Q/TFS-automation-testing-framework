namespace TfsAutomation.Adaptors
{
    public interface IAdaptor : IAnalyzer
    {
        void Init();
	    void Close();
	    bool IsClosed();
        IAdaptor GetParent();
        void SetParent(IAdaptor parent);
    }
}
