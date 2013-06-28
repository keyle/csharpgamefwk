namespace keyle
{
    /** Usage
     * 
     * where listening:
     * Bus<UnitAddedMessage>.Register(this); // in an IBussable entity
     * 
     * where sending:
     * Bus<UnitAddedMessage>.Broadcast(new UnitAddedMessage());
     * 
     **/
    public class Bus<T>
        where T : class
    {
        public static List<IBussable<T>> listeners = new List<IBussable<T>>();

        public static void Register(IBussable<T> dude)
        {
            if (listeners.Contains(dude))
                return;

            listeners.Add(dude);
        }

        public static void Broadcast(T m)
        {
            foreach (var item in listeners)
            {
                item.OnMessage(m);
            }
        }

        public static void Unregister(IBussable<T> dude)
        {
            if (listeners.Contains(dude))
                listeners.Remove(dude);
        }
    }

    public interface IBussable<T>
        where T : class
    {
        void OnMessage(T message);
    }
}
