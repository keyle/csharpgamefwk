namespace keyle
{
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
